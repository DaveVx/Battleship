using System;
using System.Threading;

namespace Battleship_v3
{
    public class Program
    {
        public const int seaWidth = 10; // The grid is 10x10.
        public const int seaHeight = 10; // 10x10
        public const int numberOfShips = 8; // 2 Ships, length is 4. If you hit all 8 coordinates, you win/loose.
        private static readonly Random rnd = new Random();
        public static bool gameOver;
        public static readonly SeaState[,] seaEnemyShips = new SeaState[seaHeight, seaWidth]; // Here the computer ships are stored.
        public static readonly SeaState[,] seaFriendlyShips = new SeaState[seaHeight, seaWidth]; // Here the player ships are stored.

        public enum SeaState // Decides on the various types of the board state.
        {
            EmptySea, Miss, Attacked, Battleship, Battleshipenemy
        }

        public static void Main()
        {
            Console.SetWindowSize(135, 45);
            Console.SetBufferSize(135, 45);
            gameOver = false;
            bool check = true;
            int numberOfHits = 0; // Here, you store your successful hits.
            int compHits = 0; // Here, the computer hits are stored.
            while (true)
            {
                Cursors.ClearMoveInput();
                Grids.ClearSea(seaWidth, seaHeight);
                GUI.Design();
                Console.ForegroundColor = ConsoleColor.White;
                Cursors.Difficulty("Choose your difficulty: "); // Choose between 2 difficulties. 
                Console.SetCursorPosition(55, 39);
                Console.Write("      1. Normal");
                Console.SetCursorPosition(55, 41);
                Console.Write("      2. Hard");
                Console.WriteLine();
                int diffic = Input.GetDiffic();
                if (diffic == '2') // On Difficult "Hard", the enemy always attacks 2 coordinates at each turn.
                {
                    while (true)
                    {
                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight); // If you place your first ship, the grid gets an update with your placed ship.
                        Cursors.ClearMoveInput();                                       // And after your second ship, it's getting an update too ofc.
                        Console.ForegroundColor = ConsoleColor.White;
                        Cursors.SetLongText("Do you want to place your ships manually or randomly? m/r: ");
                        char choice = Input.GetPlaceType();
                        if (choice == char.ToLower('r'))
                        {
                            Ships.FriendlyShips(seaWidth, seaHeight);
                            break;
                        }
                        // Randomly or manually. Two different methods.
                        if (choice == char.ToLower('m'))
                        {
                            Ships.PlaceShips(seaWidth, seaHeight);
                            break;
                        }

                        Cursors.SetStatus("Invalid input! m/r");
                    }

                    Ships.EnemyShips(); // Now the enemy ships will be generated randomly.
                    Grids.UpdateGrid(Grids.PlayerType.Computer, seaWidth, seaHeight);

                    while (!gameOver)
                    { // This while-loop runs all the time, until someone wins.
                        GetPlayerMove(ref numberOfHits);
                        GetComputermove(ref compHits, ref diffic);
                        GetComputermove(ref compHits, ref diffic);
                    }

                    if (numberOfHits == numberOfShips)
                    {
                        Cursors.SetStatus("Congratulations you win."); // player wins
                    }
                    else
                    {
                        Cursors.SetStatus("You have lost the game."); // computer wins
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.SetLongText("Press 'y' if you want to play again. Press any key to exit: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string playAgain2 = Console.ReadLine();
                    if (playAgain2.ToUpper() == "Y") // If you want to play again, the Main method will be called and everything starts again.
                    {
                        Cursors.ClearMoveInput();
                        Main();
                    }
                }

                if (diffic == '1') // On difficult "normal", the enemy attacks 1 coordinate each turn.
                {
                    while (check) // The code is equal to difficult "hard". Except the method "Ships.EnemyShips" only gets called one time.
                    {
                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight);
                        Cursors.ClearMoveInput();
                        Console.ForegroundColor = ConsoleColor.White;
                        Cursors.SetLongText("Do you want to place your ships manually or randomly? m/r: ");
                        char choice = Input.GetPlaceType();
                        if (choice == char.ToLower('r'))
                        {
                            Ships.FriendlyShips(seaWidth, seaHeight);
                            break;
                        }

                        if (choice == char.ToLower('m'))
                        {
                            Ships.PlaceShips(seaWidth, seaHeight);
                            break;
                        }

                        Cursors.SetStatus("Invalid input! m/r");
                    }

                    Ships.EnemyShips();
                    Grids.UpdateGrid(Grids.PlayerType.Computer, seaWidth, seaHeight);

                    while (!gameOver)
                    {
                        GetPlayerMove(ref numberOfHits);
                        GetComputermove(ref compHits, ref diffic);
                    }

                    if (numberOfHits == numberOfShips)
                    {
                        Cursors.SetStatus("Congratulations you win."); // player wins
                    }
                    else
                    {
                        Cursors.SetStatus("You have lost the game."); // computer wins
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.SetLongText("Press 'y' if you want to play again. Press any key to exit: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string playAgain = Console.ReadLine();
                    if (playAgain.ToUpper() == "Y")
                    {
                        Cursors.ClearMoveInput();
                        Main();
                    }
                }
                else // Only "1" and "2" is a valid input. Else you get the errormessage and everything starts again.
                {
                    Cursors.ClearMoveInput();
                    Cursors.SetStatus("Invalid input. Try again!");
                    Thread.Sleep(500);
                    continue;
                }
            }
        }



        public static void GetPlayerMove(ref int numberOfHits) // Here the player gets his attack-coordinates.
        {
            int xCoordinate;
            int yCoordinate;
            bool invalid = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Cursors.SetLongText("     Please enter x-coordinates, you want to attack: ");
                xCoordinate = Input.GetIntAttack('x'); // Here the player has to enter the x-coodinate he wants to attack.
                Cursors.SetLongText("     Please enter y-coordinates, you want to attack: ");
                yCoordinate = Input.GetIntAttack('y'); // Here the player has to enter the y-coordinate he wants to attack.
                if (seaEnemyShips[xCoordinate, yCoordinate] == SeaState.EmptySea) // If the player doesn't hit a ship, the coordinates gets the seaState "EmptySea".
                {
                    Cursors.ClearMoveInput();
                    seaEnemyShips[xCoordinate, yCoordinate] = SeaState.Miss; // It also gets the seaState "Miss". So if he attacks it again, he will get the errormessage "wasted".
                    Grids.UpdateGrid(Grids.PlayerType.Computer, seaWidth, seaHeight); // Grid gets an update.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.SetStatus("           You missed!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                if (seaEnemyShips[xCoordinate, yCoordinate] == SeaState.Attacked || seaEnemyShips[xCoordinate, yCoordinate] == SeaState.Miss)
                {                                                                  // If the player attacks coordinates, he already shot on, he will jump into this if-statement.
                    Cursors.ClearMoveInput();
                    Grids.UpdateGrid(Grids.PlayerType.Computer, seaWidth, seaHeight); // Grid gets an update.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.SetStatus("          Shot wasted");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (seaEnemyShips[xCoordinate, yCoordinate] == SeaState.Battleship) // If he shoots on a ship, his "numberOfHits" increases by 1 and the coordinates are "seastate.attacked"
                {
                    numberOfHits++;
                    Cursors.ClearMoveInput();
                    seaEnemyShips[xCoordinate, yCoordinate] = SeaState.Attacked;
                    Grids.UpdateGrid(Grids.PlayerType.Computer, seaWidth, seaHeight); // Grid gets an update.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Cursors.SetStatus("             HIT!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (numberOfHits == numberOfShips) // If numberOfHits == 8, the game is over and the player wins the game.
                    {
                        gameOver = true;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            } while (invalid);
        }

        private static void GetComputermove(ref int compHits, ref int diffic) // This let's the computer attack the player.
        {
            if (diffic == 2) // This if-statement is for the difficult "hard".
            {
                for (int i = 0; i < 2; i++)
                {
                    int compX = rnd.Next(10); // Generate the first ship.
                    int compY = rnd.Next(10); // Generate the second ship.
                    Console.ForegroundColor = ConsoleColor.White;

                    if (seaFriendlyShips[compX, compY] == SeaState.Battleship) // If the enemy hits a ship, the coordinates will be "attacked".
                    {
                        seaFriendlyShips[compX, compY] = SeaState.Attacked;
                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight); // Grid gets an update.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Cursors.SetStatus("The enemy hit one of your ships!");
                        Console.ForegroundColor = ConsoleColor.White;
                        compHits++; // The successful hits of the computer increases by 1.
                        if (compHits == numberOfShips)
                        {
                            gameOver = true;
                        }
                    }
                    else // If the computer doesn't hit.
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Cursors.SetStatus("The enemy missed!");
                        Thread.Sleep(300);
                        seaFriendlyShips[compX, compY] = SeaState.Miss; // The coordinates are now "miss"
                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight); // Grid gets an update.
                    }
                }
            }
            else // If the player chooses difficult "normal"
            { // Everything is the same like on difficult "hard", except only one shot each turn.
                int compX = rnd.Next(10); // The computer only got one shot, each turn.
                int compY = rnd.Next(10); // Generate the coordinates.
                Console.ForegroundColor = ConsoleColor.White;

                if (seaFriendlyShips[compX, compY] == SeaState.Battleship)
                {
                    seaFriendlyShips[compX, compY] = SeaState.Attacked;
                    Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.SetStatus("The enemy got one of your ships!");
                    Console.ForegroundColor = ConsoleColor.White;
                    compHits++;
                    if (compHits == numberOfShips)
                    {
                        gameOver = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.SetStatus("The enemy missed!");
                    seaFriendlyShips[compX, compY] = SeaState.Miss;
                    Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight);
                }
            }
        }

    }
}