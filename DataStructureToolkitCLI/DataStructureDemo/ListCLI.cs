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
    public class ListCLI
    {
        Stopwatch stopwatch;
        List<int> num = new List<int>();
        ArrayStringListHelpers _helpers = new ArrayStringListHelpers();
        public ListCLI(Stopwatch timer)
        {
            stopwatch = timer;
            for (int i = 0; i < 100000; i++)
            {
                num.Add(i);
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Lists =========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Insert Into List                                0. Exit");
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
                    RunInsertIntoList();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunInsertIntoList()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Insert Into List", "Insert the value into the list", "O(n)", "O(n)", "O(n)", "O(n)", $"Number of data included: {num.Count}");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            _helpers.InsertIntoList(num, 40, 100);
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Insert into list done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
    }
}
