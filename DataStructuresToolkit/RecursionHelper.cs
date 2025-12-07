using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class RecursionHelper
    {
        /// <summary>
        /// MultiplyArray: multiply the elements from the numbers in the array
        /// </summary>
        /// <param name="numArray">The collection of the numbers that will be multiply</param>
        /// <param name="index">The position of the array to start</param>
        /// <returns>The result of the products from the number in the array</returns>
        /// <remarks>
        /// Base case: Base case return the number in numArray if the position is less than or equal to the length of numArray.
        /// Recursive case: Recursive case call the new MultiplyArray with the same array but new index and return the total 
        /// Time complexity: O(n)
        /// </remarks>
        public int MultiplyArray(int[] numArray, int index)
        {
            if (index >= numArray.Length - 1)
                return numArray[index];
            return numArray[index] * MultiplyArray(numArray, index + 1);
        }
        /// <summary>
        /// IsFileExists: This method go through the string array of path to the files and find the one that is existed
        /// </summary>
        /// <param name="files">collection of array that is used to look for the files in the directory</param>
        /// <param name="index">the position of the files array</param>
        /// <returns>it return true if the file exists in the directory, but it return false if the file does not exists in the directory with that name</returns>
        /// <remarks>
        /// Base case: It return either true if the file existed or false if it not existed
        /// Recursive case: it call the new IsFileExists with same file array but new index and return true or false depend on if the file exists or not
        /// Time complexity: O(n)
        /// </remarks>
        public bool IsFileExists(string[] files, int index)
        {
            if (index == files.Length)
                return false;
            string dir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + files[index];
            if (File.Exists(dir))
                return true;
            return IsFileExists(files, index + 1);
        }
        /// <summary>
        /// IsPalindromesWords: this method call Reverse method to reverse the text from original and save it in a string and check if the reversed text is same as original
        /// </summary>
        /// <param name="text">The text that is going to be reversed and check if it was palindrome</param>
        /// <returns>it return true if the reversedText is same as the original text otherwise it returns false</returns>
        /// <remarks>
        /// Time complexity: O(n)
        /// </remarks>
        public bool IsPalindromesWords(string text)
        {
            string reversedText = Reverse(text);
            if (text == reversedText && text != "")
                return true;
            return false;
        }
        /// <summary>
        /// Reverse: this method reverse the text and return it as a reversed text
        /// </summary>
        /// <param name="text">The text to reverse</param>
        /// <returns>The reversed text</returns>
        /// <remarks>
        /// Base case: It return the first character from the end.
        /// Recursive case: It call the same Reverse method to reverse the text before returning the reversed text.
        /// Time complexity: O(n)
        /// </remarks>
        public string Reverse(string text)
        {
            if (text.Length == 0 || text == null)
                return "";
            char firstChar = text[0];
            string restText = text.Substring(1);
            return Reverse(restText) + firstChar;
        }
    }
}
