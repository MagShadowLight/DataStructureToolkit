using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class LinkedListHelpers_Tests
    {
        Stopwatch _timer;
        SinglyLinkedList<int> _singlelist;
        DoublyLinkedList<int> _doublelist;

        [SetUp]
        public void Init()
        {
            _timer = new Stopwatch();
            _singlelist = new SinglyLinkedList<int>();
            _doublelist = new DoublyLinkedList<int>();
        }

        [Test]
        public void Given_ThereAreNoValueInSinglyLinkedList_When_AddingANewValueIntoList_Then_ItShouldContainThoseValues()
        {
            _timer.Start();
            _singlelist.AddFirst(30);
            _singlelist.AddFirst(20);
            _singlelist.AddFirst(10);
            _timer.Stop();
            Assert.True(_singlelist.Contains(30));
            Assert.True(_singlelist.Contains(20));
            Assert.True(_singlelist.Contains(10));
            Assert.False(_singlelist.Contains(100));
            TestContext.WriteLine($"Time to insert a value into linked list: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to insert a value into linked list: {_timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_ThereAreValueInSinglyLinkedList_When_TraversingThroughTheList_Then_ItShouldPrintValuesCorrectly()
        {
            _singlelist.AddFirst(30);
            _singlelist.AddFirst(20);
            _singlelist.AddFirst(10);
            _timer.Start();
            string result = _singlelist.Traverse();
            _timer.Stop();
            Assert.That(result, Does.Contain("10, 20, 30"));
            TestContext.WriteLine(result);
            TestContext.WriteLine($"Time to traverse through linked list: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to traverse through linked list: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereAreNoValueInDoublyLinkedList_When_AddingANewValueInFirstAndLast_Then_ItShouldContainThoseValues()
        {
            _timer.Start();
            _doublelist.AddFirst(10);
            _doublelist.AddFirst(20);
            _doublelist.AddFirst(30);
            _doublelist.AddLast(40);
            _doublelist.AddLast(50);
            _doublelist.AddLast(60);
            _timer.Stop();
            Assert.True(_doublelist.Contains(10));
            Assert.True(_doublelist.Contains(20));
            Assert.True(_doublelist.Contains(30));
            Assert.True(_doublelist.Contains(40));
            Assert.True(_doublelist.Contains(50));
            Assert.True(_doublelist.Contains(60));
            Assert.False(_doublelist.Contains(1000));
            TestContext.WriteLine($"Time to insert a value into linked list: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to insert a value into linked list: {_timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_ThereAreValueInDoublyLinkedList_When_RemovingAValueFromTheList_Then_ItShouldNotContainsThoseValue()
        {
            _doublelist.AddFirst(10);
            _doublelist.AddFirst(20);
            _doublelist.AddFirst(30);
            _doublelist.AddLast(40);
            _doublelist.AddLast(50);
            _doublelist.AddLast(60);
            _timer.Start();
            _doublelist.Remove(_doublelist.GetNode(20));
            _timer.Stop();
            Assert.False(_doublelist.Contains(20));
            Assert.True(_doublelist.Contains(10));
            Assert.True(_doublelist.Contains(30));
            Assert.True(_doublelist.Contains(40));
            Assert.True(_doublelist.Contains(50));
            Assert.True(_doublelist.Contains(60));
            TestContext.WriteLine($"Time to remove a value into linked list: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to remove a value into linked list: {_timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_ThereAreValuesInDoublyLinkedList_When_TraversingForwardThroughTheList_Then_ItShouldPrintThoseValueCorrectly()
        {
            _doublelist.AddFirst(10);
            _doublelist.AddFirst(20);
            _doublelist.AddFirst(30);
            _doublelist.AddLast(40);
            _doublelist.AddLast(50);
            _doublelist.AddLast(60);
            _timer.Start();
            string result = _doublelist.TraverseForward();
            _timer.Stop();
            Assert.That(result, Does.Contain("30, 20, 10, 40, 50, 60"));
            TestContext.WriteLine(result);
            TestContext.WriteLine($"Time to traverse through the list forward: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to traverse through the list forward: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereAreValuesInDoublyLinkedList_When_TraversingBackwardThroughTheList_Then_ItShouldPrintThoseValueCorrectly()
        {
            _doublelist.AddFirst(10);
            _doublelist.AddFirst(20);
            _doublelist.AddFirst(30);
            _doublelist.AddLast(40);
            _doublelist.AddLast(50);
            _doublelist.AddLast(60);
            _timer.Start();
            string result = _doublelist.TraverseBackward();
            _timer.Stop();
            Assert.That(result, Does.Contain("60, 50, 40, 10, 20, 30"));
            TestContext.WriteLine(result);
            TestContext.WriteLine($"Time to traverse through the list backward: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to traverse through the list backward: {_timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void CSharpBuiltInLinkedList_VS_CustomLinkedList()
        {
            Stopwatch timer1 = new Stopwatch();
            Stopwatch timer2 = new Stopwatch();
            // C# Linked List
            LinkedList<int> nums = new LinkedList<int>();
            timer1.Start();
            nums.AddFirst(10);
            nums.AddFirst(20);
            nums.AddFirst(30);
            nums.AddLast(40);
            nums.AddLast(50);
            nums.AddLast(60);
            timer1.Stop();
            // Custom Linked List
            timer2.Start();
            _doublelist.AddFirst(10);
            _doublelist.AddFirst(20);
            _doublelist.AddFirst(30);
            _doublelist.AddLast(40);
            _doublelist.AddLast(50);
            _doublelist.AddLast(60);
            timer2.Stop();
            TestContext.WriteLine($"C# Linked List:\n{string.Join(", ", nums)}");
            TestContext.WriteLine($"Custom {_doublelist.TraverseForward()}");
            Assert.Pass();
        }
    }
}
