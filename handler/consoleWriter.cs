using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abuse.handler
{
    internal class consoleWriter
    {
        public static int options = 0;

        public static void writeLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            consoleManager.centerText("        __                                ");
            consoleManager.centerText(@"       /\ \                               ");
            consoleManager.centerText(@"   __  \ \ \____  __  __    ____     __   ");
            consoleManager.centerText(@" /'__`\ \ \ '__`\/\ \/\ \  /',__\  /'__`\ ");
            consoleManager.centerText(@"/\ \L\.\_\ \ \L\ \ \ \_\ \/\__, `\/\  __/ ");
            consoleManager.centerText(@"\ \__/.\_\\ \_,__/\ \____/\/\____/\ \____\");
            consoleManager.centerText(@" \/__/\/_/ \/___/  \/___/  \/___/  \/____/");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void optionsWriter(string text)
        {
            options++;
            Console.WriteLine($"{options}.) {text}");
        }

        public static void resetOptions()
        {
            options = 0;
        }
    }
}
