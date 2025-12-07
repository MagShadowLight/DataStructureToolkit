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
    public class ComplexityTesterCLI
    {
        private ComplexityTester _complexityTester = new ComplexityTester();
        private Stopwatch Timer = new Stopwatch();
        int[] num = new int[10000];
        string[] text = new string[10000];
        
        public ComplexityTesterCLI(Stopwatch timer)
        {
            Timer = timer;
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = i;
                text[i] = $"Test {i}";
            }
        }

        public void ComplexityCLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("===================================== Demo: Complexity Tester ==========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                  1. Constant Scenario                                  2. Linear Scenario");
                Console.WriteLine("                  3. Quadratic Scenario                                 0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    ChooseOption(input);
                    if (input == 0)
                        return;
                }  catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
            }
        }

        public void ChooseOption(int input)
        {
            switch (input)
            {
                case 1:
                    RunConstantScenarioCLI();
                    break;
                case 2:
                    RunLinearScenarioCLI();
                    break;
                case 3:
                    RunQuadraticScenarioCLI();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        } 
        public void RunConstantScenarioCLI()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Constant Scenario", "Run the scenario with the constant time", "O(1)", "O(1)", "O(1)", "O(1)", $"Number of data included: {num.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _complexityTester.RunConstantScenario(num, 10);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Constant Scenario Done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }

        public void RunLinearScenarioCLI()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Linear Scenario", "Run the scenario with the linear time", "O(n)", "O(n)", "O(n)", "O(1)", $"Number of data included: {text.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _complexityTester.RunLinearScenario(text);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Linear Scenario Done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }

        public void RunQuadraticScenarioCLI()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Quadratic Scenario", "Run the scenario with the quadratic time", "O(n^2)", "O(n^2)", "O(n^2)", "O(n)", $"Number of data included: {text.Length}");
            Console.WriteLine("Currently running...");
            Timer.Start();
            _complexityTester.RunQuadraticScenario(text);
            Timer.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Quadratic Scenario Done at time {Timer.ElapsedMilliseconds} ms ({Timer.Elapsed})");
            Timer.Reset();
        }
    }
}
