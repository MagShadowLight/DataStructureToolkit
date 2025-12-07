using DataStructuresToolkit;
using DataStructureToolkitCLI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructureToolkitCLI.DataStructureDemo
{
    public class LinkedListsCLI
    {
        private SinglyLinkedList<int> _SingleLinkedList = new SinglyLinkedList<int>();
        private DoublyLinkedList<int> _doubleLinkedList = new DoublyLinkedList<int>();
        private Stopwatch _stopwatch;
        int[] nums = new int[10000];
        Random _rng = new Random();

        public LinkedListsCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void GenerateInput()
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = _rng.Next(1, nums.Length);
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Linked Lists ==================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Singly Linked List                             2. Doubly Linked List");
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
            switch(input)
            {
                case 1:
                    SinglyLinkedListCLI();
                    break;
                case 2:
                    DoublyLinkedListCLI();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void DoublyLinkedListCLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("=============================================== Demo: Doubly Linked Lists ==============================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Add First                                      2. Add Last");
                Console.WriteLine("                       3. Traverse Forward                               4. Traverse Backward");
                Console.WriteLine("                       5. Remove                                         6. Contains");
                Console.WriteLine("                       0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenuDoubly(input);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0)
                    return;
            }
        }
        private void ChooseMenuDoubly(int input)
        {
            switch (input)
            {
                case 1:
                    RunAddFirstDoubly();
                    break;
                case 2:
                    RunAddLast();
                    break;
                case 3:
                    RunTraverseForward();
                    break;
                case 4:
                    RunTraverseBackward();
                    break;
                case 5:
                    RunRemove();
                    break;
                case 6:
                    RunContainsDoubly();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunContainsDoubly()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Contains", "Search through the linked list from the head", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            bool result = _doubleLinkedList.Contains(_rng.Next(1, nums.Length));
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Contains done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunRemove()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Remove", "Remove the value from the linked list", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            var node = _doubleLinkedList.GetNode(_rng.Next(0, nums.Length));
            _stopwatch.Start();
            _doubleLinkedList.Remove(node);
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Remove done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunTraverseBackward()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Traverse Backward", "Traverse through the linked list from the tail", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            _doubleLinkedList.TraverseBackward();
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Traverse backward done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunTraverseForward()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Traverse Forward", "Traverse through the linked list from the head", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            _doubleLinkedList.TraverseForward();
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Traverse forward done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunAddLast()
        {
            _doubleLinkedList = new DoublyLinkedList<int>();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Add Last", "Insert the value into the Linked List from the tail", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            foreach (int num in nums)
            {
                _doubleLinkedList.AddLast(num);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Add last done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunAddFirstDoubly()
        {
            _doubleLinkedList = new DoublyLinkedList<int>();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Add First", "Insert the value into the Linked List from the head", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            foreach (int num in nums)
            {
                _doubleLinkedList.AddFirst(num);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Add first done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void SinglyLinkedListCLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("=============================================== Demo: Singly Linked Lists ==============================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Add First                                      2. Traverse");
                Console.WriteLine("                       3. Contains                                       0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenuSingly(input);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0)
                    return;
            }
        }

        private void ChooseMenuSingly(int input)
        {
            switch (input)
            {
                case 1:
                    RunAddFirstSingly();
                    break;
                case 2:
                    RunTraverse();
                    break;
                case 3:
                    RunContainsSingly();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunContainsSingly()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Contains", "search through the linked list for the value from the head", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            _SingleLinkedList.Traverse();
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Contains done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunTraverse()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Traverse", "Traverse through the linked list from the head", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            _SingleLinkedList.Traverse();
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Traverse done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunAddFirstSingly()
        {
            _SingleLinkedList = new SinglyLinkedList<int>();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Add First", "Insert the value into the Linked List from the head", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            foreach(int num in nums)
            {
                _SingleLinkedList.AddFirst(num);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Add first done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }
    }
}
