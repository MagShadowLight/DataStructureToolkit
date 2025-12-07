using DataStructuresToolkit;
using DataStructureToolkitCLI.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureToolkitCLI.DataStructureDemo
{
    public class AssociativeCLI
    {
        private AssociativeHelpers _helpers = new AssociativeHelpers();
        private string[] PhoneNums = new string[50];
        private string[] name = new string[50];
        Random _rng = new Random();
        Stopwatch _stopwatch;

        public AssociativeCLI(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }
        public void GenerateInput()
        {
            for (int i = 0; i < name.Length; i++)
            {
                name[i] = $"Test {i}";
                PhoneNums[i] = Convert.ToString(_rng.Next(1, 2000000000));
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("============================================= Demo: Associative Container ==============================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Dictionary                                     2. Hashset");
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
                    DictionaryCLI();
                    break;
                case 2:
                    HashsetCLI();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void DictionaryCLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("==================================================== Demo: Dictionary ==================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Insert Dictionary                              2. Contains Name");
                Console.WriteLine("                       3. Contain Phone Number                           4. Print Dictionary");
                Console.WriteLine("                       0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenuDictionary(input);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0)
                    return;
            }
        }

        private void ChooseMenuDictionary(int input)
        {
            switch (input)
            {
                case 1:
                    RunInsertDictionary();
                    break;
                case 2:
                    RunContainsName();
                    break;
                case 3:
                    RunContainsPhoneNumber();
                    break;
                case 4:
                    RunPrintDictionary();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunPrintDictionary()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Print Dictionary", "Print the dictionary", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {name.Length} name and {PhoneNums.Length} phone number");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            _helpers.PrintDictionary();
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Print dictionary done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunContainsPhoneNumber()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Contains Phone Number", "Search the dictionary for the phone number", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {name.Length} name and {PhoneNums.Length} phone number");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            bool result = _helpers.ContainPhoneNumber($"{_rng.Next(0, 2000000000)}");
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Contains phone number done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunContainsName()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Contains Name", "Search the dictionary for the name", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {name.Length} name and {PhoneNums.Length} phone number");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            bool result = _helpers.ContainName($"Test {_rng.Next(0, name.Length)}");
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Contains name done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunInsertDictionary()
        {
            _helpers = new AssociativeHelpers();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Insert Dictionary", "Insert the value into the Dictionary", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {name.Length} and {PhoneNums.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            for (int i = 0; i < name.Length; i++)
            {
                _helpers.InsertDictionary(name[i], PhoneNums[i]);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Insert Dictionary done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void HashsetCLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================= Demo: Hashset ========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Insert Hashset                                     2. Contains");
                Console.WriteLine("                       3. Print Hashset                                      0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseMenuHashset(input);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0)
                    return;
            }
        }


        private void ChooseMenuHashset(int input)
        {
            switch(input)
            {
                case 1:
                    RunInsertHashset();
                    break;
                case 2:
                    RunContains();
                    break;
                case 3:
                    RunPrintHashset();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunPrintHashset()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Print Hashset", "Print the hash set", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {name.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            _helpers.PrintHashSet();
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Print Hash set done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunContains()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Contains", "Search the hash set for the value ", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {name.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            bool result = _helpers.Contains($"Test {_rng.Next(0, name.Length)}");
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            Console.WriteLine($"Result: {result}");
            ConsoleWriter.BenchmarkEnd($"Contains done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }

        private void RunInsertHashset()
        {
            _helpers = new AssociativeHelpers();
            GenerateInput();
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Insert Hashset", "Insert the value into the hash set ", "O(1)", "O(1)", "O(n)", "O(n)", $"Number of data included: {name.Length}");
            Console.WriteLine("Currently running...");
            _stopwatch.Start();
            foreach (string value in name)
            {
                _helpers.InsertHashSet(value);
            }
            _stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Insert done at time {_stopwatch.ElapsedMilliseconds} ms ({_stopwatch.Elapsed})");
            Console.Clear();
            _stopwatch.Reset();
        }
    }
}
