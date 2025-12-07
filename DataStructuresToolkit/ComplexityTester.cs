using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class ComplexityTester
    {
        /** <summary>RunConstantScenario: this method return the value from specific index in an array</summary>
         * <param name="input">the array of numbers that used to return value in an array</param>
         * <param name="index">the position of array to return an value in an array</param>
         * <remarks>O(1) because It would have only one input inside multiple inputs</remarks>
         */
        public int RunConstantScenario(int[] input, int index)
        {
            return input[index];
        }
        /**
         * <summary>RunLinearScenario: this method combine all of the string and return as one whole text</summary>
         * <param name="input">array of string that is used to combine all of the text into one</param>
         * <remarks>O(n) because it would go through the array and concatenate the text for each iterations</remarks>
         */
        public string RunLinearScenario(string[] input)
        {
            string text = "";
            for (int i = 0; i < input.Length; i++)
            {
                text += input[i];
            }
            return text;
        }
        /**
         * <summary>RunQuadraticScenario: check all of the possible string combo if there is a duplicate value in an array.</summary>
         * <param name="input">array of string that is used to check possible duplicate value.</param>
         * <remarks>O(n^2) because it would have to check every input multiple times for duplication</remarks>
         */
        public bool RunQuadraticScenario(string[] input)
        {
            bool isSame = false;
            for (int i = 0; i < input.Length; i++)
            {
                string text = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (text.Equals(input[j]))
                    {
                        isSame = true;
                    }
                }
            }
            return isSame;
        }
    }
}
