using System;

namespace Battleship_v3
{
    class Cursors
    { // These methods sets the cursor to the desired position. It's for the outputs. Like : "HIT!" or "Enter a coordinate".
        public static void Difficulty(string text)
        {
            Console.SetCursorPosition(55, 37);
            Console.Write(text);
        }
        public static void ClearMoveInput()
        {
            Console.SetCursorPosition(30, 37);
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                                ");
            Console.WriteLine("                                                                                                ");
        }
        public static void SetLongText(string text)
        {
            int x = 35;
            int y = 41;
            Console.SetCursorPosition(x, y);
            Console.Write("                                                                         ");
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void SetStatus(string text)
        {
            int x = 50;
            int y = 41;
            Console.SetCursorPosition(x, y);
            Console.Write("                                                                        ");
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void SetInput(string text)
        {
            int x = 40;
            int y = 41;
            Console.SetCursorPosition(x, y);
            Console.Write("                                                                        ");
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
