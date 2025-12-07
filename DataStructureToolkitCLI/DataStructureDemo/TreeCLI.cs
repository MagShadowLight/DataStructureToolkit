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
    public class TreeCLI
    {
        private Random _rng = new Random();
        public int[] _treeArray = new int[100];
        private Stopwatch _stopwatch = new Stopwatch();
        private BST _helper = new BST();

        public TreeCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public TreeNode GenerateTree()
        {
            TreeNode? root = null;
            for (int i = 0; i < _treeArray.Length; i++)
            {
                _treeArray[i] = _rng.Next(0, _treeArray.Length);
                if (root == null)
                    root = TreeNode.BuildLargeTree(null, _treeArray[i]);
                else
                    root = TreeNode.BuildLargeTree(root, _treeArray[i]);
            }
            return root;
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Trees ========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. InOrder                                         2. PreOrder");
                Console.WriteLine("                       3. PostOrder                                       0. Exit");
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
                    RunInOrder();
                    break;
                case 2:
                    RunPreOrder();
                    break;
                case 3:
                    RunPostOrder();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunPostOrder()
        {
            TreeNode tree = GenerateTree();
            List<int> output = new List<int>();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Post Order", "Traverse through the tree by traverse through Left to right node to root", "O(log(n))", "O(log(n))", "O(n)", "O(n)", $"Number of data included: {_treeArray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            tree.PostOrder(tree, output);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {string.Join(", ", output)}");
            ConsoleWriter.BenchmarkEnd($"Postorder done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            _stopwatch.Reset();
        }

        private void RunPreOrder()
        {
            TreeNode tree = GenerateTree();
            List<int> output = new List<int>();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Preorder", "Traverse through the tree by traverse through root to left node to right node", "O(log(n))", "O(log(n))", "O(n)", "O(n)", $"Number of data included: {_treeArray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            tree.PreOrder(tree, output);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {string.Join(", ", output)}");
            ConsoleWriter.BenchmarkEnd($"Preorder done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            _stopwatch.Reset();
        }

        private void RunInOrder()
        {
            TreeNode tree = GenerateTree();
            List<int> output = new List<int>();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Inorder", "Traverse through the tree by traverse through Left node to root to right node", "O(log(n))", "O(log(n))", "O(n)", "O(n)", $"Number of data included: {_treeArray.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            tree.InOrder(tree, output);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {string.Join(", ", output)}");
            ConsoleWriter.BenchmarkEnd($"InOrder done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            _stopwatch.Reset();
        }
    }
}
