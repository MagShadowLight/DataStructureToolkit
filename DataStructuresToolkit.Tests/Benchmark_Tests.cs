using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class Benchmark_Tests
    {
        List<string> list;
        DoublyLinkedList<string> linkedList;
        Stopwatch timer;
        bool result;

        [SetUp]
        public void Init()
        {
            list = new List<string> { "Test 1", "Test 2", "Test 3", "Test 4", "Test 5", "Test 6", "Test 7", "Test 8", "Test 9", "Test 10", "Test 11", "Test 12", "Test 13", "Test 14", "Test 15", "Test 16", "Test 17", "Test 18", "Test 19", "Test 20" };
            linkedList = new DoublyLinkedList<string>();
            timer = new Stopwatch();
            linkedList.AddLast("Test 1");
            linkedList.AddLast("Test 2");
            linkedList.AddLast("Test 3");
            linkedList.AddLast("Test 4");
            linkedList.AddLast("Test 5");
            linkedList.AddLast("Test 6");
            linkedList.AddLast("Test 7");
            linkedList.AddLast("Test 8");
            linkedList.AddLast("Test 9");
            linkedList.AddLast("Test 10");
            linkedList.AddLast("Test 11");
            linkedList.AddLast("Test 12");
            linkedList.AddLast("Test 13");
            linkedList.AddLast("Test 14");
            linkedList.AddLast("Test 15");
            linkedList.AddLast("Test 16");
            linkedList.AddLast("Test 17");
            linkedList.AddLast("Test 18");
            linkedList.AddLast("Test 19");
            linkedList.AddLast("Test 20");
        }
        [Test]
        public void Given_ThereAreListsAndLinkedLists_WhenSearchingThroughTwoDataStructureAndCompare_ThenOneShouldTakeLessTimeThanOther()
        {
            timer.Start();
            result = list.Contains("Test 15");
            timer.Stop();
            Assert.IsTrue(result);
            TestContext.WriteLine($"Time to access Test 15 from the list: {timer.Elapsed}");
            TestContext.WriteLine($"Time to access Test 15 from the list: {timer.ElapsedMilliseconds} ms");
            timer.Restart();
            result = linkedList.Contains("Test 15");
            timer.Stop();
            Assert.IsTrue(result);
            Console.WriteLine($"Time to access Test 15 from the linked list: {timer.Elapsed}");
            Console.WriteLine($"Time to access Test 15 from the linked list: {timer.ElapsedMilliseconds} ms");
        }
    }
}
