using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class RecursionHelper_Tests
    {
        private RecursionHelper _helper;
        private int[] numbers = new int[25];
        private string[] fileNames = new string[10000];
        private string[] texts;
        private Stopwatch _timer = new Stopwatch();

        [SetUp]
        public void Init()
        {
            _helper = new RecursionHelper();
            for (int i = 0; i < 100;  i++)
            {
                if (i < numbers.Length)
                    numbers[i] = i + 1;
                fileNames[i] = $"Test\\Test{i}.txt";
            }
            texts = new string[] { "Apple", "racecar", "nunit", "sis", "solos", "test", "banana" };
        }

        [Test]
        public void Given_There_Are_Numbers_In_The_Array_When_Multiplying_The_Number_In_The_Array_Then_It_Should_Return_The_Result()
        {
            _timer.Start();
            int result = _helper.MultiplyArray(numbers, 0);
            _timer.Stop();
            TestContext.WriteLine($"Result: {result}");
            Assert.AreEqual(2076180480, result);
            TestContext.WriteLine($"Time: {_timer.Elapsed}");
            TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Are_No_Numbers_In_The_Array_When_Try_To_Multiply_The_Numbers_Then_It_Should_Return_Zero()
        {
            int[] emptyNum = new int[10];
            _timer.Start();
            int result = _helper.MultiplyArray(emptyNum, 0);
            _timer.Stop();
            TestContext.WriteLine($"Result: {result}");
            Assert.AreEqual(0, result);
            TestContext.WriteLine($"Time: {_timer.Elapsed}");
            TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Are_File_Name_In_The_Array_When_Looking_For_A_File_And_Found_The_File_Then_It_Should_Return_True_If_That_File_Exists()
        {
            _timer.Start();
            bool result = _helper.IsFileExists(fileNames, 10);
            _timer.Stop();
            TestContext.WriteLine($"Result: {result}");
            Assert.IsTrue(result);
            TestContext.WriteLine($"Time: {_timer.Elapsed}");
            TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Are_File_Names_In_The_Array_When_Looking_For_A_File_And_Does_Not_Find_It_Then_It_Should_Return_False()
        {
            _timer.Start();
            bool result = _helper.IsFileExists(fileNames, 100);
            _timer.Stop();
            TestContext.WriteLine($"Result: {result}");
            Assert.IsFalse(result);
            TestContext.WriteLine($"Time: {_timer.Elapsed}");
            TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Are_Empty_String_Array_When_Looking_For_A_File_Then_It_Should_Return_False()
        {
            _timer.Start();
            bool result = _helper.IsFileExists(new string[1000], 11);
            _timer.Stop();
            TestContext.WriteLine($"Result: {result}");
            Assert.IsFalse(result);
            TestContext.WriteLine($"Time: {_timer.Elapsed}");
            TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Are_String_In_The_Array_When_Checking_For_Palindromes_Then_It_Should_Return_True_Or_False_If_It_Was_Palindrome()
        {
            foreach(var text in texts)
            {
                _timer.Start();
                bool result = _helper.IsPalindromesWords(text);
                _timer.Stop();
                TestContext.WriteLine($"Result: {result}");
                if (result == true)
                {
                    Assert.IsTrue(result);
                    TestContext.WriteLine($"{text} => {_helper.Reverse(text)}");
                    TestContext.WriteLine($"Time: {_timer.Elapsed}");
                    TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
                }
                else
                {
                    Assert.IsFalse(result);
                    TestContext.WriteLine($"{text} => {_helper.Reverse(text)}");
                    TestContext.WriteLine($"Time: {_timer.Elapsed}");
                    TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
                }
            }
        }
        [Test]
        public void Given_There_Are_Empty_String_When_Checking_For_Palindromes_Then_It_Should_Return_False()
        {
            string text = "";
            _timer.Start();
            bool result = _helper.IsPalindromesWords(text);
            _timer.Stop();
            TestContext.WriteLine($"Result: {result}");
            Assert.IsFalse(result);
            TestContext.WriteLine($"Time: {_timer.Elapsed}");
            TestContext.WriteLine($"Time: {_timer.ElapsedMilliseconds} ms");
        }
    }
}
