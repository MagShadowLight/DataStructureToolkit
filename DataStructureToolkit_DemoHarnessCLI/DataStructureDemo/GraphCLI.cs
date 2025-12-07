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
    public class GraphCLI
    {
        private GraphHelpers<int> _graph = new GraphHelpers<int>();
        private static Random _rng = new Random();
        private Dictionary<int, List<int>> _graphList = new Dictionary<int, List<int>>
        {
            [10] = new List<int> { 100, 30 },
            [30] = new List<int> { 20, 10 },
            [20] = new List<int> { 50, 30 },
            [50] = new List<int> { 20 },
            [100] = new List<int> { 40 },
            [40] = new List<int> { 20 }
        };
        Stopwatch _stopwatch;

        public GraphCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("====================================================== Demo: Graphs ====================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. BFS                                            2. DFS");
                Console.WriteLine("                       0. Exit");
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
                    RunBFS();
                    break;
                case 2:
                    RunDFS();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunDFS()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running DFS", "Traverse through the graph by depth first", "O(V+E)", "O(V+E)", "O(V+E)", "O(V)", $"Number of data included: {_graphList.Count}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            string result = _graph.DFS(30, _graphList, new HashSet<int>(), "");
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"DFS done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunBFS()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running BFS", "Traverse through the graph by breadth first", "O(V+E)", "O(V+E)", "O(V+E)", "O(V)", $"Number of data included: {_graphList.Count}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            string result = _graph.BFS(30, _graphList);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"BFS done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }
    }
}
