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
    public class HashTableCLI
    {
        static int length = 50;
        private SimpleHashTable _hashTable = new SimpleHashTable(length);
        int[] nums = new int[length];
        Random _rng = new Random();
        private Stopwatch _stopwatch;
        public HashTableCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void GenerateInput()
        {
            for (int i = 0; i < length; i++)
            {
                nums[i] = _rng.Next(1, length);
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Hash Table ====================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Insert                                         2. Contain");
                Console.WriteLine("                       3. Print Table                                    0. Exit");
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
                    RunInsert();
                    break;
                case 2:
                    RunContain();
                    break;
                case 3:
                    RunPrintTable();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunPrintTable()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Print table", "print the hash table", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            _hashTable.PrintTable();
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Print table done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunContain()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Contain", "Search the hash table for the target", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            bool result = _hashTable.Contains(_rng.Next(1, length));
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Contain done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunInsert()
        {
            _hashTable = new SimpleHashTable(length);
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Insert", "Insert the value into the hash table", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {nums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            foreach (int value in nums)
            {
                _hashTable.Insert(value);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Insert done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }
    }
}
