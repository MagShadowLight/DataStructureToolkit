using DataStructuresToolkit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHarness
{
    public class Demo_SortingSearch
    {
        SortingSearchHelpers _helper = new SortingSearchHelpers();
        Random _random = new Random();
        Stopwatch timer = new Stopwatch();
        int[] numbers;

        public void SetupWithRandom(int length)
        {
            numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                numbers[i] = _random.Next(1, length);
            }
        }
        public void Setup(int length)
        {
            numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                numbers[i] = i;
            }
        }
        public void Sorting()
        {
            int[] testNumbers = new int[100];
            SetupWithRandom(100);
            Array.Copy(numbers, testNumbers, 100);
            timer.Restart();
            _helper.BubbleSort(testNumbers);
            timer.Stop();
            Console.WriteLine($"Time of bubble sort with 100 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of bubble sort with 100 numbers: {timer.ElapsedMilliseconds} ms");
            Array.Copy(numbers, testNumbers, 100);
            timer.Restart();
            _helper.MergeSort(testNumbers);
            timer.Stop();
            Console.WriteLine($"Time of merge sort with 100 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of merge sort with 100 numbers: {timer.ElapsedMilliseconds} ms");
            SetupWithRandom(1000);
            testNumbers = new int[1000];
            Array.Copy(numbers, testNumbers, 1000);
            timer.Restart();
            _helper.BubbleSort(testNumbers);
            timer.Stop();
            Console.WriteLine($"Time of bubble sort with 1000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of bubble sort with 1000 numbers: {timer.ElapsedMilliseconds} ms");
            Array.Copy(numbers, testNumbers, 1000);
            timer.Restart();
            _helper.MergeSort(testNumbers);
            timer.Stop();
            Console.WriteLine($"Time of merge sort with 1000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of merge sort with 1000 numbers: {timer.ElapsedMilliseconds} ms");
            SetupWithRandom(10000);
            testNumbers = new int[10000];
            Array.Copy(numbers, testNumbers, 10000);
            timer.Restart();
            _helper.BubbleSort(testNumbers);
            timer.Stop();
            Console.WriteLine($"Time of bubble sort with 10000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of bubble sort with 10000 numbers: {timer.ElapsedMilliseconds} ms");
            Array.Copy(numbers, testNumbers, 10000);
            timer.Restart();
            _helper.MergeSort(testNumbers);
            timer.Stop();
            Console.WriteLine($"Time of merge sort with 10000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of merge sort with 10000 numbers: {timer.ElapsedMilliseconds} ms");
        }

        public void Searching()
        {
            Setup(100);
            _helper.MergeSort(numbers);
            timer.Restart();
            _helper.LinearSearch(numbers, 50);
            timer.Stop();
            Console.WriteLine($"Time of linear search with 100 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of linear search with 100 numbers: {timer.ElapsedMilliseconds} ms");
            timer.Restart();
            _helper.BinarySearch(numbers, 50);
            timer.Stop();
            Console.WriteLine($"Time of binary search with 100 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of binary search with 100 numbers: {timer.ElapsedMilliseconds} ms");
            Setup(1000);
            _helper.MergeSort(numbers);
            timer.Restart();
            _helper.LinearSearch(numbers, 100);
            timer.Stop();
            Console.WriteLine($"Time of linear search with 1000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of linear search with 1000 numbers: {timer.ElapsedMilliseconds} ms");
            timer.Restart();
            _helper.BinarySearch(numbers, 100);
            timer.Stop();
            Console.WriteLine($"Time of binary search with 1000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of binary search with 1000 numbers: {timer.ElapsedMilliseconds} ms");
            Setup(10000);
            _helper.MergeSort(numbers);
            timer.Restart();
            _helper.LinearSearch(numbers, 2910);
            timer.Stop();
            Console.WriteLine($"Time of linear search with 10000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of linear search with 10000 numbers: {timer.ElapsedMilliseconds} ms");
            timer.Restart();
            _helper.BinarySearch(numbers, 2910);
            timer.Stop();
            Console.WriteLine($"Time of binary search with 10000 numbers: {timer.Elapsed}");
            Console.WriteLine($"Time of binary search with 10000 numbers: {timer.ElapsedMilliseconds} ms");
        }
    }
}
