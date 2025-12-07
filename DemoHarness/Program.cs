using DataStructuresToolkit;
using System.Diagnostics;

namespace DemoHarness
{
    internal class Program
    {
        static Demo_StacksQueues stacksQueues = new Demo_StacksQueues();
        static Demo_SortingSearch sortSearch = new Demo_SortingSearch();


        static void Main(string[] args)
        {
            stacksQueues.StacksQueues();
            sortSearch.Sorting();
            sortSearch.Searching();
        }
    }
}
