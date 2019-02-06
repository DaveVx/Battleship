using System;
using System.Threading;
namespace Battleship_v3
// The class "Input" takes over the task for the input of the player. Like if he types something wrong -> try/catch. 
{
    class Input
    {
        public static int GetDiffic()
        {
            bool isInt = false;

            while (!isInt)
            {
                char input = Console.ReadKey().KeyChar;
                int intInput = Convert.ToInt32(input);
                try
                {
                    if (!char.IsDigit(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Cursors.SetStatus("Please choose a difficulty!");
                        Thread.Sleep(500);
                        Program.Main();
                    }
                    isInt = true;
                    return intInput;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.ClearMoveInput();
                    Cursors.SetStatus("Input was no integer, try again!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(500);
                    Program.Main();
                }
            }
            throw new Exception("Unexpected program behaviour!");
        }
        public static char GetState()
        {
            bool isChar = false;

            while (!isChar)
            {
                char chInput = Console.ReadKey().KeyChar;

                try
                {
                    if (!char.IsLetter(chInput) || char.IsDigit(chInput))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Cursors.ClearMoveInput();
                        Cursors.SetStatus("Invalid input, only h/v allowed!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(500);
                        Cursors.ClearMoveInput();
                    }

                    isChar = true;

                    return chInput;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.ClearMoveInput();
                    Cursors.SetStatus("Input was no integer, try again!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            throw new FormatException("Unexpected program behavior");
        }
        public static char GetPlaceType()
        {
            bool isChar = false;

            while (!isChar)
            {
                char chInput = Console.ReadKey().KeyChar;

                try
                {
                    if (!char.IsLetter(chInput) || char.IsDigit(chInput))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Cursors.ClearMoveInput();
                        Cursors.SetStatus("Invalid input, only r/m allowed!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(500);
                        Cursors.ClearMoveInput();
                    }

                    isChar = true;

                    return chInput;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.ClearMoveInput();
                    Cursors.SetStatus("Input was no integer, try again!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(500);
                    Cursors.SetStatus("Please enter a valid input: ");
                }
            }

            throw new FormatException("Unexpected program behavior");
        }

        public static int GetInteger(string text)
        {
            bool isInt = false;
            int val;

            while (!isInt)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Cursors.SetLongText(text);
                string input = Console.ReadLine();

                try
                {
                    val = Convert.ToInt32(input);
                    if (val > 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Cursors.SetLongText("Invalid input, only 0-9 is valid! Try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    isInt = true;

                    return val;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cursors.SetLongText("Input was no integer, try again!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            throw new Exception("Unexpected program behavior");
        }
        public static int GetIntAttack(char coor)
        {
            bool isInt = false;
            int val;

            while (!isInt)
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    try
                    {
                        val = Convert.ToInt32(input);
                        if (val > 9)
                        {
                            if (coor == 'x')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Cursors.ClearMoveInput();
                                Cursors.SetStatus("Invalid input, only 0-9 is valid!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(300);
                                Cursors.SetLongText("     Please enter x-coordinates, you want to attack: ");
                                Thread.Sleep(500);
                                break;
                            }
                            else if (coor == 'y')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Cursors.ClearMoveInput();
                                Cursors.SetStatus("Invalid input, only 0-9 is valid!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(300);
                                Cursors.SetLongText("     Please enter y-coordinates, you want to attack: ");
                                Thread.Sleep(500);
                                break;
                            }

                        }
                        else if (val < 10)
                        {
                            return val;
                        }
                        isInt = true;
                    }
                    catch (Exception)
                    {
                        if (coor == 'x')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Cursors.ClearMoveInput();
                            Cursors.SetStatus("Invalid input, only 0-9 is valid!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(300);
                            Cursors.SetLongText("     Please enter x-coordinates, you want to attack: ");
                            Thread.Sleep(500);
                            continue;
                        }
                        else if (coor == 'y')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Cursors.ClearMoveInput();
                            Cursors.SetStatus("Invalid input, only 0-9 is valid!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(300);
                            Cursors.SetLongText("     Please enter y-coordinates, you want to attack: ");
                            Thread.Sleep(500);
                            continue;
                        }
                    }
                }
            }
            throw new Exception("Unexpected program behavior");
        }
    }
}
