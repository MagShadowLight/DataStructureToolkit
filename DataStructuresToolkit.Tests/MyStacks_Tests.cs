using DataStructuresToolkit.StacksQueues;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataStructuresToolkit.Tests
{
    public class MyStacks_Tests
    {
        public string[] textTest = new string[1000];
        string[] StringArray;
        private MyStack stacks;
        private Stopwatch timer = new Stopwatch();
        [SetUp]
        public void Init()
        {
           stacks = new MyStack();
            for (int i = 0; i < textTest.Length; i++)
            {
                textTest[i] = $"Text {i}, ";
            }
        }
        

        [Test]
        public void Given_There_Are_No_Text_In_The_Stacks_When_Trying_To_Pop_Or_Peek_Stacks_Then_It_Should_Throw_Exception()
        {

            Assert.Throws<InvalidOperationException>(StackUndo);
            Assert.Throws<InvalidOperationException>(StackPeek);
        }
        [Test]
        public void Given_There_Are_Text_In_The_Input_When_Pushing_To_Stack_Then_It_Should_Succeed()
        {
            timer.Start();
            foreach(var text in textTest)
            {
                stacks.AppendText(text);
            }
            timer.Stop();
            TestContext.WriteLine($"Time to push text: {timer.Elapsed}");
            TestContext.WriteLine($"Time to push text: {timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Stack Count: {stacks.Count}");
            Assert.AreEqual(textTest.Length, stacks.Count);
        }
        [Test]
        public void Given_There_Are_Text_In_The_Stacks_When_Popping_Text_From_The_Stack_Then_Text_Should_Be_Removed()
        {
            string Text;
            foreach (var text in textTest)
            {
                stacks.AppendText(text);
            }
            timer.Start();
            Text = stacks.Undo();
            StringArray = Text.Split(", ");
            timer.Stop();
            TestContext.WriteLine($"Time to pop stack: {timer.Elapsed}");
            TestContext.WriteLine($"Time to pop stack: {timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Stack Count: {stacks.Count}");
            Assert.Contains("Text 998", StringArray);
            timer.Start();
            Text = stacks.Redo();
            timer.Stop();
            TestContext.WriteLine($"Time to pop stack: {timer.Elapsed}");
            TestContext.WriteLine($"Time to pop stack: {timer.ElapsedMilliseconds} ms");
            Assert.Contains("Text 998", StringArray);
        }
        [Test]
        public void Given_There_Are_Text_In_The_Stacks_When_Peeking_The_History_Then_Text_Should_Not_Be_Removed()
        {
            string Text = "";
            foreach (var text in textTest)
            {
                stacks.AppendText(text);
            }
            timer.Start();
            Text = stacks.PeekHistory();
            timer.Stop();
            StringArray = Text.Split(", ");
            TestContext.WriteLine($"Time to peek stack: {timer.Elapsed}");
            TestContext.WriteLine($"Time to peek stack: {timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Stack Count: {stacks.Count}");
            Assert.Contains("Text 998", StringArray);
        }

        public void StackUndo()
        {
            stacks.Undo();
        }
        public void StackPeek()
        {
            stacks.PeekHistory();
        }
    }
}
