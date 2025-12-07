using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureToolkitCLI.Utils
{
    public class ConsoleUtils
    {
        public static void ClearLine()
        {
            int currentCursor = Console.CursorTop - 1;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentCursor);
        }
        public static void ErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("ERROR: ");
            Console.WriteLine(message);
            Console.WriteLine("Press Enter to select again");
            Console.ReadLine();
        }

        public static void ResetColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
