using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class SortingSearchHelpers
    {
        /// <summary>
        /// BubbleSort: Sorting through the array by swapping adjacent numbers in the array if it in wrong order
        /// </summary>
        /// <param name="numArray">The collection of the numbers that going to be sorted</param>
        /// <remarks>
        /// Worst case time complexity: O(n^2)
        /// Average case time complexity: O(n^2)
        /// Best case time complexity: O(n)
        /// Space Complexity: O(1)
        /// </remarks>
        public void BubbleSort(int[] numArray)
        {
            for (int index1 = 0; index1 < numArray.Length; index1++)
            {
                for (int index2 = 0; index2 < numArray.Length - index1 - 1; index2++)
                {
                    if (numArray[index2] > numArray[index2+1])
                    {
                        int tempNumber = numArray[index2];
                        numArray[index2] = numArray[index2+1];
                        numArray[index2+1] = tempNumber;
                    }
                }
            }
        }
        /// <summary>
        /// MergeSort: sorting through the array by dividing the array into two and then merging them into one
        /// </summary>
        /// <param name="numArray">The collection of numbers that going to be sorted</param>
        /// <remarks>
        /// time complexity: O(n log n)
        /// Space complexity: O(n)
        /// </remarks>
        public void MergeSort(int[] numArray)
        {
            if (numArray.Length <= 1)
                return;

            int middleIndex = numArray.Length / 2;
            int[] Array1 = numArray.Skip(middleIndex).ToArray();
            int[] Array2 = numArray.Take(middleIndex).ToArray();

            MergeSort(Array1);
            MergeSort(Array2);

            Merge(numArray, Array1, Array2);
        }
        /// <summary>
        /// Merge: Merging the two array into one when sorting through the array.
        /// </summary>
        /// <param name="NumArray">The full collection of the numbers that going to be merged</param>
        /// <param name="Array1">The left side of the collection that are merging into</param>
        /// <param name="Array2">The right side of the collection that are merging into</param>
        public void Merge(int[] NumArray, int[] Array1, int[] Array2)
        {
            int i = 0, j = 0, k = 0;

            while (i < Array1.Length && j < Array2.Length)
            {
                if ((Array1[i] <= Array2[j]))
                    NumArray[k++] = Array1[i++];
                else
                    NumArray[k++] = Array2[j++];
            }

            while (i < Array1.Length) NumArray[k++] = Array1[i++];
            while (j < Array2.Length) NumArray[k++] = Array2[j++];
        }
        /// <summary>
        /// LinearSearch: searching through the array by going from the start to the end of the array.
        /// </summary>
        /// <param name="numArray">The collection of the numbers that going to be for search</param>
        /// <param name="target">The number that the user want to search for</param>
        /// <returns>It return the position of the array if the target have been found otherwise return -1 indicating that the number have not been found</returns>
        /// <remarks>
        /// Time complexity: O(n)
        /// Space complexity: O(1)
        /// </remarks>
        public int LinearSearch(int[] numArray, int target)
        {
            for (int i = 0; i < numArray.Length; i++)
                if (numArray[i] == target)
                    return i;
            return -1;
        }
        /// <summary>
        /// BinarySearch: Searching through the array by taking the starting position and ending position and the middle position and then search right if the target is
        /// higher than the middle position or search left if the target is lower than the middle position. It require the sorted array
        /// </summary>
        /// <param name="numArray">The collection of the number that going to be for search</param>
        /// <param name="target">The number that the user want to search for</param>
        /// <returns>It return the middle position of the array if the target have been found otherwise it return -1 which indicate that the number have not been found.</returns>
        /// <remarks>
        /// Time complexity: O(log n)
        /// Space complexity: O(1)
        /// </remarks>
        public int BinarySearch(int[] numArray, int target)
        {
            int leftIndex = 0, rightIndex = numArray.Length - 1;
            while (leftIndex <= rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                if (numArray[middleIndex] == target) return middleIndex;
                else if (numArray[middleIndex] < target) leftIndex = middleIndex + 1;
                else rightIndex = middleIndex - 1;
            }
            return -1;
        }
    }
}
