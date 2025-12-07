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
    public class ArrayCLI
    {
        Stopwatch Timer;
        public int[] num = new int[10000];
        public int[] randomNum = new int[100000];
        public string[] text = new string[100000];
        private Random rng = new Random();
        List<int> list = new List<int>();
        private ArrayStringListHelpers _arrayStringListHelpers = new ArrayStringListHelpers();
        private RecursionHelper _recursionHelper = new RecursionHelper();
        private SortingSearchHelpers _sortSearchHelper = new SortingSearchHelpers();
        public ArrayCLI(Stopwatch timer)
        {
            Timer = timer;
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = i;
                text[i] = $"Test {i}";
                list.Add(i);
            }
        }

        public void GenerateNewInput()
        {
            for (int i = 0;i < randomNum.Length;i++)
            {
                randomNum[i] = rng.Next(0, 50000);
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Array =========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                  1. Insert an Value into array                        2. Delete an Value from array");
                Console.WriteLine("                  3. Multiply Array                                    4. Bubble Sort");
                Console.WriteLine("                  5. Merge Sort                                        6. Linear Search");
                Console.WriteLine("                  7. Binary Search                                     0. Exit");
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
            //Console.WriteLine("Running Insert into List");
            //Timer.Restart();
            //_arrayStringListHelpers.InsertIntoList(list, 30, 200);
            //Timer.Stop();
            //Console.WriteLine($"Insert Into List done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            //Timer.Reset();
        }

        public void ChooseMenu(int input)
        {
            switch (input)
            {
                case 1:
                    RunInsertIntoArray();
                    break;
                case 2:
                    RunDeleteFromArray();
                    break;
                case 3:
                    RunMultiplyArray();
                    break;
                case 4:
                    RunBubbleSort();
                    break;
                case 5:
                    RunMergeSort();
                    break;
                case 6:
                    RunLinearSearch();
                    break;
                case 7:
                    RunBinarySearch();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break; 
            }
        }

        public void RunInsertIntoArray()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Insert into array", "Inserting the input into the existing array", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {num.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _arrayStringListHelpers.InsertIntoArray(num, 12, 100);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Insert into array done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }


        public void RunDeleteFromArray()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Delete from array", "Deleting the input from the existing array", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {num.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _arrayStringListHelpers.DeleteFromArray(num, 16);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Delete from array done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }

        public void RunMultiplyArray()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Multiply Array", 
                "Multiplying the number from the array. (Note: this functionality using recursion)", 
                "O(n)", 
                "O(n)", 
                "O(n)", 
                "O(n)", 
                $"Number of data included: {num.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _recursionHelper.MultiplyArray(num, 0);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Multiply array done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }

        public void RunBubbleSort()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Bubble sort", 
                "Sorting through the array by looking at adjacent elements", 
                "O(n)",
                "O(n^2)",
                "O(n^2)",
                "O(1)",
                $"Number of data included: {randomNum.Length}");
            Console.WriteLine("Currently running...");
            GenerateNewInput();
            Timer.Start();
            _sortSearchHelper.BubbleSort(randomNum);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Bubble sort done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }

        public void RunMergeSort()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Merge sort",
                "Sorting through the array by dividing the array and merging it",
                "O(n Log(n))",
                "O(n Log(n))",
                "O(n Log(n))",
                "O(n)",
                $"Number of data included: {randomNum.Length}");
            Console.WriteLine("Currently running...");
            GenerateNewInput();
            Timer.Start();
            _sortSearchHelper.MergeSort(randomNum);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Merge sort done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }

        public void RunLinearSearch()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Linear Search",
                "Search through the elements in array by looping through the array",
                "O(n)",
                "O(n)",
                "O(n)",
                "O(1)",
                $"Number of data included: {num.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _sortSearchHelper.LinearSearch(num, 500);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Linear search done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }

        public void RunBinarySearch()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Binary Search",
                "Search through the elements in array using starting position, end position, and middle position (Note: It must work with sorted array)",
                "O(Log(n))",
                "O(Log(n))",
                "O(Log(n))",
                "O(1)",
                $"Number of data included: {num.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _sortSearchHelper.BinarySearch(num, 500);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Binary search done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }
    }
}
