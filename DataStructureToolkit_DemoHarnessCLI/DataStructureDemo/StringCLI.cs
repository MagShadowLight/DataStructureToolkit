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
    public class StringCLI
    {
        Stopwatch stopwatch;
        string[] text = new string[100000];
        private ArrayStringListHelpers _helpers1 = new ArrayStringListHelpers();
        private RecursionHelper _helpers2 = new RecursionHelper();
        Random rng = new Random();
        public StringCLI(Stopwatch timer)
        {
            stopwatch = timer;
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = $"Test {i}";
            }
        }
        
        private string GenerateWord()
        {
            if (rng.Next(0,2) == 0)
            {
                return "jesse";
            }
            else if (rng.Next(0,2) == 1)
            {
                return "hannah";
            } else
            {
                return "gary";
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: String ========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                  1. Concatenative Names Naive                        2. Concatenative Names Builder");
                Console.WriteLine("                  3. Is Palindrome Words                              4. Reverse");
                Console.WriteLine("                  0. Exit");
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

        public void ChooseMenu(int input)
        {
            switch (input)
            {
                case 1:
                    RunConcatenativeNamesNaive();
                    break;
                case 2:
                    RunConcatenativeNamesBuilder();
                    break;
                case 3:
                    RunIsPalindromesWords();
                    break;
                case 4:
                    RunReverse();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        public void RunConcatenativeNamesNaive()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Concatenate Names Naive", 
                "combine all of the string from the collection", 
                "O(n^2)", 
                "O(n^2)", 
                "O(n^2)", 
                "O(n^2)", 
                $"Number of data included: {text.Length}");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            _helpers1.ConcatenateNamesNaive(text);
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Concatenate names naive done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }

        public void RunConcatenativeNamesBuilder()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Concatenate Names Builder", 
                "Combine all of the string from the collection using builder", 
                "O(n)", 
                "O(n)", 
                "O(n)", 
                "O(n)", 
                $"Number of data included: {text.Length}");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            _helpers1.ConcatenateNamesBuilder(text);
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Concatenate names builder done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }

        public void RunIsPalindromesWords()
        {
            string word = GenerateWord();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Is Palindrome Words",
                "Checking if the word is palindrome or not",
                "O(n)",
                "O(n)",
                "O(n)",
                "O(n)",
                $"String included: {word}");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            var result = _helpers2.IsPalindromesWords(word);
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Is palindrome words done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
        public void RunReverse()
        {
            string word = GenerateWord();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Reverse", "Reverse the text", "O(n)", "O(n)", "O(n)", "O(1)", $"String included: {word}");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            var result = _helpers2.Reverse(word);
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Reverse done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
    }
}
