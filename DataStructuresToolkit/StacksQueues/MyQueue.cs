using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
    public class MyQueue
    {
        private readonly Queue<string> _printer = new Queue<string>();

        public int Count { get { return _printer.Count; } }
        /// <summary>
        /// AddaJobs: add the job with a name to the queue to be processed
        /// </summary>
        /// <param name="jobName">The name of the jobs</param>
        /// <remarks>O(1) amortized: It uses the enqueue to add the job with a name</remarks>
        public void AddAJobs(string jobName)
        {
            _printer.Enqueue(jobName);
        }
        /// <summary>
        /// ProcessNextJobs: remove the current job name to process the next job
        /// </summary>
        /// <returns>The current job in the queue</returns>
        /// <exception cref="InvalidOperationException">Throw an error if the queue is empty</exception>
        /// <remarks>O(1): it uses the dequeue to process the next jobs or the examples the people in a line</remarks>
        public string ProcessNextJobs()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Printer empty");
            }
            return _printer.Dequeue();
        }
        /// <summary>
        /// PeekNextJob: Peek into the current job without processing the next job
        /// </summary>
        /// <returns>The current job in the queue</returns>
        /// <exception cref="InvalidOperationException">Throw an error if the queue is empty</exception>
        /// <remarks>O(1): it uses the peek in queue to peek into the next job</remarks>
        public string PeekNextJob()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Printer empty");
            }
            return _printer.Peek();
        }
    }
}
