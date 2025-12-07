using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class ArrayStringListHelpers
    {
        /**
         * <summary>InsertIntoArray: the array resize to accommodate the new value to be insert,
         * then shift the value in the array to the right, then insert that value in the index.</summary>
         * <param name="array">The collections that will have a new value being inserted</param>
         * <param name="index">The position of the array that will have value to be inserted</param>
         * <param name="value">The value that is going to be inserted</param>
         * <remarks>O(n) because it would have to go through every value in the array to shift
         * to the right before the value can be inserted.</remarks>
         */
        public void InsertIntoArray(int[] array, int index, int value)
        {
            Array.Resize(ref array, array.Length + 1);
            for (int i = index; i < array.Length-1; i++)
            {
                var tempvalue = array[index];
                array[index] = array[i + 1];
                array[i + 1] = tempvalue;
            }
            array[index] = value;
        }

        /**
         * <summary>DeleteFromArray: this method remove the value or shifting the value to the left,
         * then the array would shrink to remove it completely</summary>
         * <param name="array">The collections of value that would have one of value removed</param>
         * <param name="index">the position of the array that going to be removed from the array</param>
         * <remarks>O(n) because it would have to shift the values in the array to the left
         * to remove that value</remarks>
         */
        public void DeleteFromArray(int[] array, int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
        }
        /**
         * <summary>ConcatenateNamesNaive: This method initialize the result variable and go
         * through the array to concatenate and add the text to the result</summary>
         * <param name="names">the collection of names that will be go into results</param>
         * <remarks>O(n^2) because the string was immutable and would have to create a new string object and
         * copy the value with the value that will be added.</remarks>
         */
        public  void ConcatenateNamesNaive(string[] names)
        {
            var result = "";
            for (int i = 0; i < names.Length; i++)
            {
                result += names[i];
            }
        }
        /**
         * <summary>ConcatenateNamesBuilder: this method is the same as the ConcatenateNamesNaive
         * where it initialize result and go through array to combine the result but instead using
         * the string builder</summary>
         * <param name="names">the collection of names that will be go into results</param>
         * <remarks>O(n) because compared to the Concat names naive, stringbuilder allows the string of text to
         * be modify before it can be converted into a string.</remarks>
         */
        public void ConcatenateNamesBuilder(string[] names)
        {
            StringBuilder builder = new StringBuilder();
            var result = "";
            for (int i = 0;i < names.Length; i++)
            {
                builder.Append(names[i]);
            }
            result += builder.ToString();
        }
        /**
         * <summary>This method insert the value into a specific position in the list</summary>
         * <param name="list">a collection of numbers that can have the new value</param>
         * <param name="index">the positions of the list that the value will be added</param>
         * <param name="value">the value that will be added onto the list</param>
         * <remarks>O(n) because the list would have to resize and move the values before
         * the new value can be added</remarks>
         */ 
        public void InsertIntoList(List<int> list, int index, int value)
        {
            list.Insert(index, value);
        }
    }
}
