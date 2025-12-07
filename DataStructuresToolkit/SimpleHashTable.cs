// I have learned that the collision in the hash table or hash set was if I have the twenty buckets in a hash table and each
// buckets have only one value. When I insert another value into one of the buckets like for example, in bucket 8, I would
// encounter the collision in bucket 8 which give me a messy searches. When I handle how the buckets or the hash table, I use
// two different strategies to handle each buckets. One strategies that I handle the collisions In hash table was using the lists
// or any collections that can be resizable like lists or linked lists in each buckets where I can insert more than one value in a
// buckets. Another strategy of handing the collision when inserting a value was check if the bucket that I am trying to add a value
// in was full. If that bucket was full, I would check the other bucket to see if it was full and if those bucket are not full, I would
// place value in that bucket. The built-in collections like the dictionary or the hashset simplify the implementation of having the
// custom hash table by providing the built-in functionality of the hash table without the messy details that the custom hash table
// doesn’t. If i want to have a multiple values in the bucket, I would use the custom hash table otherwise I would instead use a
// built-in functionality like dictionary or hashset for something like phone books.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class SimpleHashTable
    {
        public List<int>[] buckets;

        public SimpleHashTable(int length)
        {
            buckets = new List<int>[length];
            for (int index = 0; index < length; index++)
            {
                buckets[index] = new List<int>();
            }
        }
        /// <summary>
        /// HashValue: Hashing the value by using the modular
        /// </summary>
        /// <param name="value">The number that would be use for hash</param>
        /// <returns>The index for the bucket</returns>
        /// <remarks>
        /// Time Complexity: O(1)
        /// Space Complexity: O(n)
        /// </remarks>
        public int HashValue(int value)
        {
            return value % buckets.Length;
        } 
        /// <summary>
        /// Insert: Inserting the value into the bucket
        /// </summary>
        /// <param name="value">The number that would be inserted into the bucket</param>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public void Insert(int value)
        {
            int index = HashValue(value);

            if (buckets[index] != null && !buckets[index].Contains(value))
            {
                buckets[index].Add(value);
            }
        }
        /// <summary>
        /// Contains: Check if the value is in that bucket
        /// </summary>
        /// <param name="value">the target number to be searched</param>
        /// <returns>If the target does contain the number, it return true otherwise false</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public bool Contains(int value)
        {
            int index = HashValue(value);
            bool isFound = buckets[index].Contains(value);
            return isFound;
        }
        /// <summary>
        /// PrintTable: Printing the hash table to be used in the console
        /// </summary>
        /// <returns>the result from the printer</returns>
        /// <remarks>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public string PrintTable()
        {
            string result = "";
            for (int index = 0; index < buckets.Length; index++)
            {
                result += $"bucket {index}\n";
                result += $"{string.Join(", ", buckets[index])}\n";
            }
            return result;
        }
    }
}
