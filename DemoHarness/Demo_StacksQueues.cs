using DataStructuresToolkit.StacksQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHarness
{
    public class Demo_StacksQueues
    {
        MyStack stacks = new MyStack();
        MyQueue queues = new MyQueue();
        string[] TextArray = new string[1000];
        public void StacksQueues()
        {
            for (int i = 0; i < TextArray.Length; i++)
            {
                TextArray[i] = $"Test {i}, ";
            }
            foreach(var text in TextArray)
            {
                stacks.AppendText(text);
                queues.AddAJobs(text);
            }
            stacks.Undo();
            Console.WriteLine($"Stack Text: {stacks.Text}");
            stacks.Undo();
            Console.WriteLine($"Stack Text: {stacks.Text}");
            stacks.Undo();
            Console.WriteLine($"Stack Text: {stacks.Text}");
            Console.WriteLine($"Processing: {queues.ProcessNextJobs()}");
            Console.WriteLine($"Processing: {queues.ProcessNextJobs()}");
            Console.WriteLine($"Processing: {queues.ProcessNextJobs()}");
        }
    }
}
