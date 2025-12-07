using DataStructuresToolkit;
using DataStructureToolkitCLI.DataStructureDemo;
using DataStructureToolkitCLI.Utils;
using System.Diagnostics;

namespace DataStructureToolkitCLI
{
    internal class Program
    {
        private static DataStructureMainCLI CLI = new DataStructureMainCLI();
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Data Structure And Algorithm Demo");
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            CLI.Run();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine($"Exiting Data Structure and Algorithm Demo at {DateTime.Now}");
            Thread.Sleep(1000);
        }
    }
}
