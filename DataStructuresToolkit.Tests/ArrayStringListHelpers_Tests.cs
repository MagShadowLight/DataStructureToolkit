using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class ArrayStringListHelpers_Tests
    {
        private int[] _numberArray = new int[100000];
        private List<int> _numberList = new List<int>();
        private string[] _names = new string[100000];
        private Stopwatch _timer = new Stopwatch();
        private ArrayStringListHelpers _helper = new ArrayStringListHelpers();
        [SetUp]
        public void Init()
        {
            for (int i = 0; i < _numberArray.Length || i < _names.Length; i++)
            {
                _numberArray[i] = i;
                _numberList.Add(i);
                _names[i] = $"Student Name {i}";
            }
        }
        [Test]
        public void Given_There_Are_Numbers_In_The_Array_When_Inserting_A_Value_Then_It_Should_Succeed_With_Time_Printed()
        {
            _timer.Start();
            _helper.InsertIntoArray(_numberArray, 5, 100);
            _timer.Stop();
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.Elapsed}");
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.ElapsedMilliseconds} ms");
            Assert.Contains(100, _numberArray);
        }
        [Test]
        public void Given_There_Are_Numbers_In_The_Array_When_Deleting_A_Value_Then_It_Should_Succeed_With_Time_Printed()
        {
            _timer.Start();
            _helper.DeleteFromArray(_numberArray, 5);
            _timer.Stop();
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.Elapsed}");
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.ElapsedMilliseconds} ms");
            Assert.Contains(10, _numberArray);
        }
        [Test]
        public void Given_There_Are_String_In_The_Array_When_Concatenating_Using_Naive_Then_It_Should_Succeed_With_Time_Printed()
        {
            _timer.Start();
            _helper.ConcatenateNamesNaive(_names);
            _timer.Stop();
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.Elapsed}");
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.ElapsedMilliseconds} ms");
            Assert.Pass();
        }
        [Test]
        public void Given_There_Are_String_In_The_Array_When_Concatenating_Using_String_Builder_Then_It_Should_Succeed_With_Time_Printed()
        {
            _timer.Start();
            _helper.ConcatenateNamesBuilder(_names);
            _timer.Stop();
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.Elapsed}");
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.ElapsedMilliseconds} ms");
            Assert.Pass();
        }
        [Test]
        public void Given_There_Are_Numbers_In_The_List_When_Inserting_Value_Into_A_List_Then_It_Should_Succeed_With_Time_Printed()
        {
            _timer.Start();
            _helper.InsertIntoList(_numberList, 10, 100);
            _timer.Stop();
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.Elapsed}");
            TestContext.WriteLine($"n={_numberArray.Length}: {_timer.ElapsedMilliseconds} ms");
            Assert.Contains(100, _numberList);
        }
    }
}
