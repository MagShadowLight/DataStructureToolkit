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
    public class FileCLI
    {
        private RecursionHelper _Helpers = new RecursionHelper();
        private Stopwatch _Stopwatch = new Stopwatch();
        string[] filesName = new string[10000];
        private Random rng = new Random();
        public FileCLI(Stopwatch timer)
        {
            _Stopwatch = timer;
            for (int i = 0; i < filesName.Length; i++)
            {
                filesName[i] = $"Test{i}.txt";
            }
        }

        private int GenerateInput()
        {
            int num = rng.Next(0, 2);
            switch (num)
            {
                case 0:
                    return 10;
                case 1:
                    return 1000;
                default:
                    return 0;
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Files ========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Is File Exists                                         0. Exit");
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
                    RunIsFileExists();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunIsFileExists()
        {
            int input = GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Is File Exists", "Checking if the file is exist or not (Note: this functionality uses recursion)", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {filesName.Length}");
            Console.WriteLine("Currently running...");
            _Stopwatch.Start();
            bool result = _Helpers.IsFileExists(filesName, input);
            _Stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Index from the array: {input}");
            Console.WriteLine($"File exists? {result}");
            ConsoleWriter.BenchmarkEnd($"Is file exists done at time {_Stopwatch.ElapsedMilliseconds} ms ({_Stopwatch.Elapsed})");
            _Stopwatch.Reset();
        }
    }
}
