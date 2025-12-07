using DataStructuresToolkit.StacksQueues;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class MyQueues_Tests
    {
        string Text;
        public string[] textTest = new string[1000];
        private MyQueue queue;
        private Stopwatch timer = new Stopwatch();
        [SetUp]
        public void Init()
        {
            for (int i = 0; i < textTest.Length; i++)
            {
                textTest[i] = $"Job {i}, ";
            }
            queue = new MyQueue();
        }
        [Test]
        public void Given_There_Are_No_Jobs_In_The_Queues_When_Trying_To_Dequeue_Or_Peek_Queues_Then_It_Should_Throw_Exception()
        {

            Assert.Throws<InvalidOperationException>(QueueProcess);
            Assert.Throws<InvalidOperationException>(QueuePeek);
        }

        [Test]
        public void Given_There_Is_Job_Name_When_Enqueuing_In_The_Queue_Then_It_Should_Succeed()
        {
            
            timer.Start();
            foreach (var test in textTest)
            {
                queue.AddAJobs(test);
            }
            timer.Stop();
            TestContext.WriteLine($"Time to enqueue job: {timer.Elapsed}");
            TestContext.WriteLine($"Time to enqueue job: {timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Queue Count: {queue.Count}");
            Assert.AreEqual(textTest.Length, queue.Count);
        }
        [Test]
        public void Given_There_Is_Job_In_The_Queue_When_Process_The_Next_Job_Then_It_Should_Process_Next()
        {
            timer.Start();
            foreach (var test in textTest)
            {
                queue.AddAJobs(test);
            }
            Text = queue.ProcessNextJobs();
            timer.Stop();
            TestContext.WriteLine($"Time to process next job: {timer.Elapsed}");
            TestContext.WriteLine($"Time to process next job: {timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Queue Count: {queue.Count}");
            Assert.AreEqual("Job 0, ", Text);
        }
        [Test]
        public void Given_There_Is_Job_In_The_Queue_When_Peeking_The_Next_Job_Then_It_Should_Not_Be_Removed()
        {
            foreach(var test in textTest)
            {
                queue.AddAJobs(test);
            }
            timer.Start();
            Text = queue.PeekNextJob();
            timer.Stop();
            TestContext.WriteLine($"Time to peek next job: {timer.Elapsed}");
            TestContext.WriteLine($"Time to peek next job: {timer.ElapsedMilliseconds} ms");
            TestContext.WriteLine($"Queue Count: {queue.Count}");
            Assert.AreEqual("Job 0, ", Text);
        }
        

        void QueueProcess()
        {
            queue.ProcessNextJobs();
        }
        void QueuePeek()
        {
            queue.PeekNextJob();
        }
    }
}
