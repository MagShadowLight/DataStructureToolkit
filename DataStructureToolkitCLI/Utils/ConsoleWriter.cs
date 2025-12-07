using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureToolkitCLI.Utils
{
    public class ConsoleWriter
    {
        public static void BenchmarkStart(string method, string description, string bestCaseTimeComplexity, string averageCaseTimeComplexity, string worstCaseTimeComplexity, string spaceComplexity, string data)
        {
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine($"{method}");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Expected Time Complexity:");
            Console.WriteLine($"Best Case: {bestCaseTimeComplexity}");
            Console.WriteLine($"Average Case: {averageCaseTimeComplexity}");
            Console.WriteLine($"Worst Case: {worstCaseTimeComplexity}");
            Console.WriteLine($"Expected Space Complexity: {spaceComplexity}");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine($"{data}");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Benchmark:");
        }
        public static void BenchmarkEnd(string timeMethod)
        {
            Console.WriteLine($"{timeMethod}");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Press enter to go back");
            Console.ReadLine();
        }
    }
}
