using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class PriorityQueue
    {
        public List<int> heapList = new List<int>();
        /// <summary>
        /// Enqueue: Inserting the value and swap the two value if the child node of the tree is greater than the parent node
        /// </summary>
        /// <param name="value">The value that will be inserted into</param>
        /// <remarks>
        /// Worst and Average Case Time Complexity: O(log n)
        /// Best Case Time Complexity: O(1)
        /// </remarks>
        public void Enqueue(int value)
        {
            heapList.Add(value);
            int index = heapList.Count - 1;
            while (index > 0 && heapList[(index-1)/2] > heapList[index])
            {
                (heapList[index], heapList[(index - 1) / 2]) = (heapList[(index - 1) / 2], heapList[index]);
                index = (index - 1) / 2;
            }
        }
        /// <summary>
        /// Dequeue: Extract the minimum value of the number
        /// </summary>
        /// <returns>It return the number that was extracted from the list</returns>
        /// <exception cref="InvalidOperationException">It throw the invalid operation if the heap list is empty</exception>
        /// <remarks>
        /// Worst and Average Case Time Complexity: O(log n)
        /// Best Case Time Complexity: O(1)
        /// </remarks>
        public int Dequeue()
        {
            if (heapList.Count == 0) throw new InvalidOperationException("heap is empty");
            int root = heapList[0];
            heapList[0] = heapList[^1];
            heapList.RemoveAt(heapList.Count - 1);
            Heapify(0);
            return root;
        }
        /// <summary>
        /// Search through the heap tree and check if the parent node is less than the child node. 
        /// If the parent node is greater than the child node, swap those two values.
        /// </summary>
        /// <param name="index">The current position or node of the trees</param>
        /// <remarks>
        /// Worst and Average Case Time Complexity: O(log n)
        /// Best Case Time Complexity: O(n)
        /// </remarks>
        private void Heapify(int index)
        {
            int smallestNum = index;
            int leftIndex = 2 * index + 1;
            int rightIndex = 2 * index + 2;

            if (leftIndex < heapList.Count && heapList[leftIndex] < heapList[smallestNum]) smallestNum = leftIndex;
            if (rightIndex < heapList.Count && heapList[rightIndex] < heapList[smallestNum]) smallestNum = rightIndex;

            if (smallestNum != 1) {
                (heapList[index], heapList[smallestNum]) = (heapList[smallestNum], heapList[index]);
                Heapify(smallestNum);
            }
        }
    }
}
