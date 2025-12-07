using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class PriorityQueue_Tests
    {
        private PriorityQueue _queue;
        private Stopwatch _timer;

        [SetUp]
        public void Init()
        {
            _queue = new PriorityQueue();
            _timer = new Stopwatch();
        }

        [Test]
        public void Given_ThereAreNoValueInPriorityQueue_When_InsertingAValueInTheQueueAndThenDequeueMin_Then_ItShouldReturnValue2()
        {
            _timer.Start();
            _queue.Enqueue(5);
            _queue.Enqueue(2);
            _queue.Enqueue(8);
            int result = _queue.Dequeue();
            _timer.Stop();
            Assert.That(result, Is.EqualTo(2));
            TestContext.WriteLine($"Priority queue dequeue: {result}");
            TestContext.WriteLine($"Time to enqueue value into priority queue: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to enqueue value into priority queue: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereAreNoValueInPriorityQueue_When_TryingToExtractTheMin_Then_ItShouldThrowAnInvalidOperationException()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
            TestContext.WriteLine("Dequeue should throw successfully when heap is empty");
            TestContext.WriteLine(exception.Message);
        }

        [Test]
        public void Given_ThereAreNoValueInPriorityQueue_When_InsertingAValueInTheQueue_Then_ItShouldContainThoseValue()
        {
            _timer.Start();
            _queue.Enqueue(5);
            _queue.Enqueue(2);
            _queue.Enqueue(8);
            _timer.Stop();
            Assert.That(_queue.heapList, Is.EqualTo(new List<int> { 2, 5, 8 }));
            TestContext.WriteLine($"Priority queue values: {string.Join(", ", _queue.heapList)}");
            TestContext.WriteLine($"Time to enqueue value into priority queue: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to enqueue value into priority queue: {_timer.ElapsedMilliseconds} ms");
        }
    }
}
