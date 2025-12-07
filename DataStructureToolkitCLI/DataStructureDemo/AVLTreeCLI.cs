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
    public class AVLTreeCLI
    {
        private Random _rng = new Random();
        private int[] _treearray = new int[1000];
        private Stopwatch _stopwatch = new Stopwatch();
        private AvlTree _avlTree = new AvlTree();

        public AVLTreeCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void GenerateInput()
        {
            for (int i = 0; i < _treearray.Length; i++)
            {
                _treearray[i] = _rng.Next(0, _treearray.Length);
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: AVL Trees =====================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Insert                                         2. Contain");
                Console.WriteLine("                       3. Print Tree                                     0. Exit");
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
                    RunInsert();
                    break;
                case 2:
                    RunContain();
                    break;
                case 3:
                    RunPrintTree();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunPrintTree()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Print Tree", "Printing the tree", "O(log(n))", "O(log(n))", "O(log(n))", "O(n)", $"Number of data included: {_treearray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            string result = _avlTree.PrintTree(_avlTree.Root, "", true);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Print tree done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunContain()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Contain", "Search for the value in the tree", "O(log(n))", "O(log(n))", "O(log(n))", "O(n)", $"Number of data included: {_treearray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            bool result = _avlTree.Contain(_avlTree.Root, _rng.Next(1, _treearray.Length));
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Contain done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunInsert()
        {
            _avlTree = new AvlTree();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Insert", "Insert the value into the tree with the self balancing", "O(log(n))", "O(log(n))", "O(log(n))", "O(n)", $"Number of data included: {_treearray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            foreach (int value in _treearray)
            {
                _avlTree.Root = _avlTree.Insert(_avlTree.Root, value);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Insert done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }
    }
}
