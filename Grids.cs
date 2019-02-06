using System;

namespace Battleship_v3
{
    public class Grids
    {
        public enum PlayerType
        {
            Player, Computer
        }

        public static void UpdateGrid(PlayerType type, int seaWidth, int seaHeight) // Here the grid gets an update. After every move, this method is called.
        {
            int offset = type == PlayerType.Player ? 5 : 91; // Offset because of the collumns in the console. Player grid begins at 5 and computer at 91.

            for (int row = 0; row < seaHeight; row++)
            {
                for (int col = 0; col < seaWidth; col++)
                {
                    Console.SetCursorPosition(col * 4 + offset, row * 2 + 16);

                    Program.SeaState seaState = type == PlayerType.Player ? Program.seaFriendlyShips[col, row] : Program.seaEnemyShips[col, row];

                    switch (seaState)
                    { // Here is the grid. It describes, like the different "states" are shown on the grid.
                        case Program.SeaState.Battleship:
                            if (type == PlayerType.Player)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("O");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("~");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case Program.SeaState.EmptySea:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("~");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case Program.SeaState.Attacked:
                            if (type == PlayerType.Player)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("X");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("X");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case Program.SeaState.Miss:
                            if (type == PlayerType.Player)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("M");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("M");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                    }
                }
            }
        }

        public static void ClearSea(int seaWidth, int seaHeight) // Sets all spaces on board to "hidden".
        {
            for (int row = 0; row < seaHeight; row++)
            {
                for (int col = 0; col < seaWidth; col++)
                {
                    Program.seaFriendlyShips[row, col] = Program.SeaState.EmptySea;
                    Program.seaEnemyShips[row, col] = Program.SeaState.EmptySea;
                }
            }
        }
    }
}