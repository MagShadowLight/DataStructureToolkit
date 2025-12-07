using DataStructuresToolkit;
using DataStructureToolkitCLI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureToolkitCLI.DataStructureDemo
{
    public class SetCLI
    {
        private SetHelpers<string> _set = new SetHelpers<string>();
        private HashSet<string> setA = new HashSet<string>();
        private HashSet<string> setB = new HashSet<string>();
        private static Random _rng = new Random();
        Stopwatch _stopwatch;
        private string[] _list = new string[1000];

        public SetCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void GenerateInput()
        {
            for (int i = 0; i < _list.Length; i++)
            {
                _list[i] = $"Test {i}";
            }
            for (int i = 0; i < _list.Length/2; i++)
            {
                setA.Add(_list[i]);
            }
            for (int i = _list.Length/4; i < _list.Length; i++)
            {
                setB.Add(_list[i]);
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("====================================================== Demo: Sets ======================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Union                                          2. Intersection");
                Console.WriteLine("                       3. Difference                                     0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenu(input);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0)
                    return;
            }
        }

        private void ChooseMenu(int input)
        {
            switch (input)
            {
                case 1:
                    RunUnion();
                    break;
                case 2:
                    RunIntersection();
                    break;
                case 3:
                    RunDifference();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunDifference()
        {
            _set = new();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Difference", "Get elements from just one sets but not other set", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {setA.Count} and {setB.Count}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            string result = _set.Difference(setA, setB);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result.Count()} characters");
            ConsoleWriter.BenchmarkEnd($"Difference done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunIntersection()
        {
            _set = new();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Intersection", "Get elements from both sets", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {setA.Count} and {setB.Count}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            string result = _set.Intersection(setA, setB);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result.Count()} characters");
            ConsoleWriter.BenchmarkEnd($"Intersection done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunUnion()
        {
            _set = new();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Union", "Combining both set into one", "O(n+m)", "O(n+m)", "O(n*m)", "O(n)", $"Number of data included: {setA.Count} and {setB.Count}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            string result = _set.Union(setA, setB);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result.Count()} characters");
            ConsoleWriter.BenchmarkEnd($"Union done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }
    }
}
