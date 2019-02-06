using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v3
{
    // This class only writes the gui.
    class GUI
    {
        public static void Design()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                           ██████╗  █████╗ ████████╗████████╗██╗     ███████╗███████╗██╗  ██╗██╗██████╗ ");
            Console.WriteLine("                           ██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║     ██╔════╝██╔════╝██║  ██║██║██╔══██╗");
            Console.WriteLine("                           ██████╔╝███████║   ██║      ██║   ██║     █████╗  ███████╗███████║██║██████╔╝");
            Console.WriteLine("                           ██╔══██╗██╔══██║   ██║      ██║   ██║     ██╔══╝  ╚════██║██╔══██║██║██╔═══╝ ");
            Console.WriteLine("                           ██████╔╝██║  ██║   ██║      ██║   ███████╗███████╗███████║██║  ██║██║██║     ");
            Console.WriteLine("                           ╚═════╝ ╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝╚═╝╚═╝     ");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("   ╔═══════════════════════════════════════╗                                             ╔═══════════════════════════════════════╗");
            Console.WriteLine("   ║                 PLAYER                ║                                             ║               COMPUTER                ║");
            Console.WriteLine("   ╠═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╣                                             ╠═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╤═══╣");
            Console.WriteLine("   ║ 0 │ 1 │ 2 │ 3 │ 4 │ 5 │ 6 │ 7 │ 8 │ 9 ║                                             ║ 0 │ 1 │ 2 │ 3 │ 4 │ 5 │ 6 │ 7 │ 8 │ 9 ║");
            Console.WriteLine("   ╟───┼───┼───┼───┼───┼───┼───┼───┼───┼───╢                                             ╟───┼───┼───┼───┼───┼───┼───┼───┼───┼───╢");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + "  ║   │   │   │   │   │   │   │   │   │   ║                                          " + i +
                                  "  ║   │   │   │   │   │   │   │   │   │   ║");
                if (i + 1 < 10)
                {
                    Console.WriteLine("   ╟───┼───┼───┼───┼───┼───┼───┼───┼───┼───╢                                             ╟───┼───┼───┼───┼───┼───┼───┼───┼───┼───╢");
                }
            }

            Console.WriteLine("   ╚═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╝                                             ╚═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╝");
        }
    }
}