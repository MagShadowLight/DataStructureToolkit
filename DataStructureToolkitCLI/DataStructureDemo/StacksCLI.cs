using DataStructuresToolkit.StacksQueues;
using DataStructureToolkitCLI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class StacksCLI
    {
        private MyStack _helpers = new MyStack();
        private Stopwatch stopwatch = new Stopwatch();
        string[] text = new string[10000];

        public StacksCLI(Stopwatch timer)
        {
            stopwatch = timer;
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = $"Test {i}";
            }
        }

        public void CLI()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("================================================== Demo: Stacks ========================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                       1. Append Text                                       2. Delete last char");
                Console.WriteLine("                       3. Undo                                              4. Redo");
                Console.WriteLine("                       5. Peek History                                      0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                        Note: Undo, Redo, and Peek History will throw error if stack is empty");
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
                    RunAppendText();
                    break;
                case 2:
                    RunDeleteLastChar();
                    break;
                case 3:
                    RunUndo();
                    break;
                case 4:
                    RunRedo();
                    break;
                case 5:
                    RunPeekHistory();
                    break;
                case 0:
                    Console.Clear();
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }

        private void RunAppendText()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Append Text", "Append the text to add to the stack", "O(1)", "O(1)", "O(1)", "O(n)", $"Number of data included: {text.Length}");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            foreach (string item in text)
            {
                _helpers.AppendText(item);
            }
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Append text done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
        private void RunDeleteLastChar()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Delete Last Char", "Delete the last char to add to the stacks", "O(1)", "O(1)", "O(1)", "O(n)", $"data included: none");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            _helpers.DeleteLastChar();
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Delete last char done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
        private void RunUndo()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Undo (Note: It will cause error if the stack is empty)", "Undo the text added or deleted", "O(1)", "O(1)", "O(1)", "O(n)", $"data included: none");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            _helpers.Undo();
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Undo done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
        private void RunRedo()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Redo (Note: It will cause error if the stack is empty)", "Redo the text added or deleted", "O(1)", "O(1)", "O(1)", "O(n)", $"data included: none");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            _helpers.Redo();
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Redo done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
        private void RunPeekHistory()
        {
            Console.Clear();
            ConsoleWriter.BenchmarkStart("Running Peek History (Note: It will cause error if the stack is empty)", "Peek the history of the text added or deleted", "O(1)", "O(1)", "O(1)", "O(n)", $"data included: none");
            Console.WriteLine("Currently running...");
            stopwatch.Start();
            _helpers.PeekHistory();
            stopwatch.Stop();
            ConsoleUtils.ClearLine();
            ConsoleWriter.BenchmarkEnd($"Peek history done at time {stopwatch.ElapsedMilliseconds} ms ({stopwatch.Elapsed})");
            stopwatch.Reset();
        }
    }
}
