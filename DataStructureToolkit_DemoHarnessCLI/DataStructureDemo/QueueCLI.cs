using DataStructuresToolkit.StacksQueues;
using DataStructuresToolkit;
using DataStructureToolkitCLI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataStructureToolkitCLI.DataStructureDemo
{
    public class QueueCLI
    {
        Random _rng = new Random();
        private int[] nums = new int[10000];
        private string[] texts = new string[10000];
        private MyQueue _helpers = new MyQueue();
        private PriorityQueue _helpers2 = new PriorityQueue();
        private Stopwatch _StopWatch = new Stopwatch();
        public QueueCLI(Stopwatch stopwatch)
        {
            _StopWatch = stopwatch;
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = $"Test {i}";
            }
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
                Console.WriteLine("================================================== Demo: Queues ========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Add a job                                         2. Process Next Job");
                Console.WriteLine("                       3. Peek Next Job                                     4. Priority Queue");
                Console.WriteLine("                       0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                        Note: Process and peek next job will throw error if queues is empty");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenuQueue(input);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0)
                    return;
            }
        }

        public void ChooseMenuQueue(int input)
        {
            switch (input)
            {
                case 1:
                    RunAddAJob();
                    break;
                case 2:
                    RunProcessNextJob();
                    break;
                case 3:
                    RunPeekAJob();
                    break;
                case 4:
                    PriorityQueueCLI();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        public void PriorityQueueCLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Priority Queues ===============================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Enqueue                                         2. Dequeue");
                Console.WriteLine("                       0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                        Note: Dequeue will throw error if heap list is empty");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenuHeap(input);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0)
                    return;
            }
        }

        private void ChooseMenuHeap(int input)
        {
            switch (input)
            {
                case 1:
                    RunEnqueue();
                    break;
                case 2:
                    RunDequeue();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunDequeue()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Dequeue", "Remove the value to the priority queue or heap", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {texts.Length}");
            Console.WriteLine("Currently running...");
            _StopWatch.Start();
            int result = _helpers2.Dequeue();
            _StopWatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Dequeue done at time {_StopWatch.ElapsedMilliseconds} ms ({_StopWatch.Elapsed})");
            _StopWatch.Reset();
        }

        private void RunEnqueue()
        {
            _helpers2 = new();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Enqueue", "Add the value to the priority queue or heap", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {texts.Length}");
            Console.WriteLine("Currently running...");
            _StopWatch.Start();
            foreach (int item in nums)
            {
                _helpers2.Enqueue(item);
            }
            _StopWatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Enqueue done at time {_StopWatch.ElapsedMilliseconds} ms ({_StopWatch.Elapsed})");
            _StopWatch.Reset();
        }

        public void RunAddAJob()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Add A Job", "Add the text to the queue", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {texts.Length}");
            Console.WriteLine("Currently running...");
            _StopWatch.Start();
            foreach (string item in texts)
            {
                _helpers.AddAJobs(item);
            }
            _StopWatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Add a job done at time {_StopWatch.ElapsedMilliseconds} ms ({_StopWatch.Elapsed})");
            _StopWatch.Reset();
        }
        public void RunProcessNextJob()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Process Next Job", "Process the next job from the queue", "O(1)", "O(1)", "O(1)", "O(n)", $"data included: none");
            Console.WriteLine("Currently running...");
            _StopWatch.Start();
            string result = _helpers.ProcessNextJobs();
            _StopWatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Process next job done at time {_StopWatch.ElapsedMilliseconds} ms ({_StopWatch.Elapsed})");
            _StopWatch.Reset();
        }
        public void RunPeekAJob()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Peek A Job", "Peek the job from the queue", "O(n)", "O(n)", "O(n)", "O(n)", $"data included: none");
            Console.WriteLine("Currently running...");
            _StopWatch.Start();
            string result = _helpers.PeekNextJob();
            _StopWatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Peek next job done at time {_StopWatch.ElapsedMilliseconds} ms ({_StopWatch.Elapsed})");
            _StopWatch.Reset();
        }
    }
}
