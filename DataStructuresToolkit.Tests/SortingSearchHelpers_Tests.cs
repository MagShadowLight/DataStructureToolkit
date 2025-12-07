using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class SortingSearchHelpers_Tests
    {
        int[] unSortedArray;
        int[] sortedArray;
        SortingSearchHelpers _helper = new SortingSearchHelpers();
        Stopwatch _timer;
        Random _random = new Random();
        int[] expected = new int[250000];
        int target = 750000;
        [SetUp]
        public void init()
        {
            _timer = new Stopwatch();
            unSortedArray = new int[250000];
            for (int i = 0; i < unSortedArray.Length; i++)
                unSortedArray[i] = _random.Next(1, unSortedArray.Length);
            sortedArray = new int[1000000];
            for (int i = 0; i < sortedArray.Length; i++)
                sortedArray[i] = i;
            Array.Copy(unSortedArray, expected, unSortedArray.Length);
            _helper.MergeSort(expected);
        }

        [Test]
        public void Given_There_Are_Unsorted_Array_When_Sorting_Through_The_Array_With_Bubble_Then_It_Should_Succeed()
        {
            _timer.Start();
            Assert.DoesNotThrow(() => _helper.BubbleSort(unSortedArray));
            Assert.That(unSortedArray, Is.EqualTo(expected));
            _timer.Stop();
            TestContext.WriteLine($"Time for bubble sort with 250000 numbers: {_timer.Elapsed}");
            TestContext.WriteLine($"Time for bubble sort with 250000 numbers: {_timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Sorted Array: {string.Join(", ", unSortedArray)}");
        }
        [Test]
        public void Given_There_Are_Unsorted_Array_When_Sorting_Through_The_Array_With_Merge_Then_It_Should_Succeed()
        {
            _timer.Start();
            Assert.DoesNotThrow(() => _helper.MergeSort(unSortedArray));
            Assert.That(unSortedArray, Is.EqualTo(expected));
            _timer.Stop();
            TestContext.WriteLine($"Time for merge sort with 250000 numbers: {_timer.Elapsed}");
            TestContext.WriteLine($"Time for merge sort with 250000 numbers: {_timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Sorted Array: {string.Join(", ", unSortedArray)}");
        }
        [Test]
        public void Given_There_Are_Sorted_Array_When_Searching_For_The_Number_With_Linear_Then_It_Should_Return_With_That_Position()
        {
            _timer.Start();
            int result = _helper.LinearSearch(sortedArray, target);
            _timer.Stop();
            Assert.AreEqual(target, result);
            TestContext.WriteLine($"Time for linear search with 1000000 numbers: {_timer.Elapsed}");
            TestContext.WriteLine($"Time for linear search with 1000000 numbers: {_timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Result: {result}");
        }
        [Test]
        public void Given_There_Are_Sorted_Array_When_Searching_For_The_Number_With_Binary_Then_It_Should_Return_With_That_Position()
        {
            _timer.Start();
            int result = _helper.BinarySearch(sortedArray, target);
            _timer.Stop();
            Assert.AreEqual(target, result);
            TestContext.WriteLine($"Time for linear search with 1000000 numbers: {_timer.Elapsed}");
            TestContext.WriteLine($"Time for linear search with 1000000 numbers: {_timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Result: {result}");
        }
    }
}
