using System;
using System.Threading;

namespace Battleship_v3 // This class is for placing the ships.
{
    public class Ships
    {
        private static readonly Random rnd = new Random();

        private enum PlayerType
        {
            Player, Computer
        }

        private enum ShipAlignment
        {
            Horizontal, Vertical
        }

        private static bool ShipCheck(int xCoor, int yCoor, int shipLength, ShipAlignment alignment, PlayerType type) // Checks if Enemy or Friendly, how long and if vertical or horizontal.
        {
            // Here is checked wheter the placed ship  sticks out beyond the grid or if there is already a ship. 
            // This method also gives the "allowed" coordinates the seaState "Battleship".
            if (alignment == ShipAlignment.Horizontal && xCoor + shipLength > Program.seaWidth)
            {
                return false;
            }

            if (alignment == ShipAlignment.Vertical && yCoor + shipLength > Program.seaHeight)
            {
                return false;
            }

            if (type == PlayerType.Player)
            {
                if (alignment == ShipAlignment.Horizontal)
                {
                    for (int i = 0; i < shipLength; i++)
                    {
                        if (Program.seaFriendlyShips[xCoor + i, yCoor] != Program.SeaState.EmptySea)
                        {
                            return false;
                        }
                    }

                    for (int i = 0; i < shipLength; i++)
                    {
                        Program.seaFriendlyShips[xCoor + i, yCoor] = Program.SeaState.Battleship;
                    }

                    return true;
                }

                for (int i = 0; i < shipLength; i++)
                {
                    if (Program.seaFriendlyShips[xCoor, yCoor + i] != Program.SeaState.EmptySea)
                    {
                        return false;
                    }
                }

                for (int i = 0; i < shipLength; i++)
                {
                    Program.seaFriendlyShips[xCoor, yCoor + i] = Program.SeaState.Battleship;
                }

                return true;
            }

            if (alignment == ShipAlignment.Horizontal)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    if (Program.seaEnemyShips[xCoor + i, yCoor] != Program.SeaState.EmptySea)
                    {
                        return false;
                    }
                }

                for (int i = 0; i < shipLength; i++)
                {
                    Program.seaEnemyShips[xCoor + i, yCoor] = Program.SeaState.Battleship;
                }

                return true;
            }

            for (int i = 0; i < shipLength; i++)
            {
                if (Program.seaEnemyShips[xCoor, yCoor + i] != Program.SeaState.EmptySea)
                {
                    return false;
                }
            }

            for (int i = 0; i < shipLength; i++)
            {
                Program.seaEnemyShips[xCoor, yCoor + i] = Program.SeaState.Battleship;
            }

            return true;
        }

        public static void EnemyShips() // Generate the computer's ships.
        {
            for (int i = 0; i < 2; i++)
            {
                int choice = rnd.Next(1); // It's random, if the computer places the ship horizontal or vertical.
                if (choice == 0)
                {
                    int xCoor = rnd.Next(10);
                    int yCoor = rnd.Next(10);

                    while (!ShipCheck(xCoor, yCoor, 4, ShipAlignment.Horizontal, PlayerType.Computer))
                    {
                        xCoor = rnd.Next(10);
                        yCoor = rnd.Next(10);
                    }
                }

                if (choice == 1)
                {
                    int xCoor = rnd.Next(10);
                    int yCoor = rnd.Next(10);

                    while (!ShipCheck(xCoor, yCoor, 4, ShipAlignment.Vertical, PlayerType.Computer))
                    {
                        xCoor = rnd.Next(10);
                        yCoor = rnd.Next(10);
                    }
                }
            }
        }

        public static void FriendlyShips(int seaWidth, int seaHeight) // Generate the player's ships randomly.
        {
            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    Cursors.ClearMoveInput();
                    Cursors.SetLongText("   Do you want to place it vertically or horizontally: ");
                    char state = Input.GetState();
                    if (state == char.ToLower('h'))
                    {
                        int xCoor = rnd.Next(10);
                        int yCoor = rnd.Next(10);

                        while (!ShipCheck(xCoor, yCoor, 4, ShipAlignment.Horizontal, PlayerType.Player))
                        {
                            xCoor = rnd.Next(10);
                            yCoor = rnd.Next(10);
                        }

                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight);

                        Thread.Sleep(300);
                        break;
                    }

                    if (state == char.ToLower('v'))
                    {
                        int xCoor = rnd.Next(10);
                        int yCoor = rnd.Next(10);

                        while (!ShipCheck(xCoor, yCoor, 4, ShipAlignment.Vertical, PlayerType.Player))
                        {
                            xCoor = rnd.Next(10);
                            yCoor = rnd.Next(10);
                        }

                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight);
                        Thread.Sleep(300);
                        break;
                    }
                }
            }
        }

        public static void PlaceShips(int seaWidth, int seaHeight) // Generate the player's ships manually.
        {
            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    Cursors.SetLongText("   Do you want to place it vertically or horizontally: ");
                    char state = Input.GetState();

                    if (state == char.ToLower('h'))
                    {
                        int xCoor = Input.GetInteger("    Place the Battleship. Please enter your x-coordinate: ");
                        int yCoor = Input.GetInteger("                Enter your y-coordinate:");

                        if (xCoor + 4 > 10)
                        {
                            Cursors.SetStatus("That's not possible. It sticks out beyond the grid.");
                            Thread.Sleep(1000);
                            Cursors.SetStatus("Try again!");
                            Thread.Sleep(400);
                            continue;
                        }

                        if (!ShipCheck(xCoor, yCoor, 4, ShipAlignment.Horizontal, PlayerType.Player))
                        {
                            Cursors.SetStatus("Your ship overlaps another");
                            Thread.Sleep(1000);
                            Cursors.SetStatus("Try again!");
                            Thread.Sleep(400);
                            continue;
                        }

                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight);
                        break;
                    }

                    if (state == char.ToLower('v'))
                    {
                        int xCoor = Input.GetInteger("    Place the Battleship. Please enter your x-coordinate: ");
                        int yCoor = Input.GetInteger("                Enter your y-coordinate: ");

                        if (yCoor + 4 > 10)
                        {
                            Cursors.SetStatus("That's not possible. It sticks out beyond the grid.");
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Cursors.SetStatus("         Try again!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(400);
                            continue;
                        }

                        if (!ShipCheck(xCoor, yCoor, 4, ShipAlignment.Vertical, PlayerType.Player))
                        {
                            Cursors.SetStatus("Your ship overlaps another");
                            Thread.Sleep(1000);
                            Cursors.SetStatus("Try again!");
                            Thread.Sleep(400);
                            continue;
                        }

                        Grids.UpdateGrid(Grids.PlayerType.Player, seaWidth, seaHeight);
                        break;
                    }
                }
            }
        }
    }
}