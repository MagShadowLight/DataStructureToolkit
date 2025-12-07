using DataStructuresToolkit;
using DataStructureToolkitCLI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureToolkitCLI.DataStructureDemo
{
    public class BSTCLI
    {
        private Random _rng = new Random();
        public int[] _treeArray = new int[10000];
        private Stopwatch _stopwatch = new Stopwatch();
        private BST _helper = new BST();

        public BSTCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        private void GenerateInput()
        {
            for (int i = 0; i < _treeArray.Length; i++)
            {
                _treeArray[i] = _rng.Next(1, _treeArray.Length);
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: BST Trees ====================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Insert Value                                    2. IsContainValue");
                Console.WriteLine("                       3. Height                                          0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenu(input);
                } catch (Exception ex)
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
                    RunInsertValue();
                    break;
                case 2:
                    RunIsContainValue();
                    break;
                case 3:
                    RunHeight();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunHeight()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Height", "Calculate the height of the tree", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {_treeArray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            int result = _helper.Height(_helper.root);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Height done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            _stopwatch.Reset();
        }

        private void RunIsContainValue()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Is Contain Value", "Check the node of the tree if the value is in the node", "O(log(n))", "O(log(n))", "O(n)", "O(n)", $"Number of data included: {_treeArray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            bool result = _helper.IsContainValue(_rng.Next(0, _treeArray.Length));
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Is contain value done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            _stopwatch.Reset();
        }

        private void RunInsertValue()
        {
            _helper = new BST();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Insert Value", "Insert the value into the tree", "O(log(n))", "O(log(n))", "O(n)", "O(n)", $"Number of data included: {_treeArray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            foreach(int num in _treeArray)
            {
                _helper.InsertValue(num);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Insert value done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }
    }
}
