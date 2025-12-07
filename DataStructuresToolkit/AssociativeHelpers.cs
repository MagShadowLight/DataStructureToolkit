using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class AssociativeHelpers
    {
        public Dictionary<string, string> phoneBooks = new Dictionary<string, string>();

        public HashSet<string> hashSet = new HashSet<string>();

        /// <summary>
        /// InsertDictionary: insert both the name and the phone number into the dictionary.
        /// </summary>
        /// <param name="name">The name of the person</param>
        /// <param name="phoneNum">The phone number for that particular person</param>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public void InsertDictionary(string name, string phoneNum)
        {
            phoneBooks.Add(name, phoneNum);
        }
        /// <summary>
        /// ContainName: Search for the person name and return true if the name is found
        /// </summary>
        /// <param name="name">The name of the person to be searched</param>
        /// <returns>It return true if that name is contain in dictionary otherwise it return false</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public bool ContainName(string name)
        {
            return phoneBooks.ContainsKey(name);
        }
        /// <summary>
        /// ContainPhoneNumber: Search for the phone number from that person and return true if that phone number is found
        /// </summary>
        /// <param name="phoneNum">The person's phone number that will be searched</param>
        /// <returns>It return true if that phone number is contain in that dictionary otherwise it return false</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public bool ContainPhoneNumber(string phoneNum)
        {
            return phoneBooks.ContainsValue(phoneNum);
        }
        /// <summary>
        /// PrintDictionary: Print the dictionary to be used in the console
        /// </summary>
        /// <returns>The result from the printer</returns>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        public string PrintDictionary()
        {
            string result = "";
            for (int index = 0; index < phoneBooks.Count; index++)
            {
                result += $"{index + 1} = {phoneBooks.ElementAt(index).Key}: {phoneBooks.ElementAt(index).Value}\n";
            }
            return result;
        }
        /// <summary>
        /// InsertHashSet: Inserting the value into the hash set. If there is already a value, ignore the value.
        /// </summary>
        /// <param name="value">The value that would be added into hash set with the uniqueness</param>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public void InsertHashSet(string value)
        {
            hashSet.Add(value);
        }
        /// <summary>
        /// Contains: search the hashset for the target value and return true or false whether that value contain in the hashset.
        /// </summary>
        /// <param name="value">The value that would be search for</param>
        /// <returns>It return true if that value is in the hashset otherwise it return false.</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public bool Contains(string value)
        {
            bool result = false;
            result = hashSet.Contains(value);
            return result;
        }

        /// <summary>
        /// PrintHashSet: Print the hash set with the values.
        /// </summary>
        /// <returns>The result of the hashset from the printer</returns>
        /// <remarks>
        /// Time Complexity: O(n)
        /// Space Complexity: O(1)
        /// </remarks>
        public string PrintHashSet()
        {
            string result = "";
            for (int index = 0; index < hashSet.Count; index++)
            {
                result += $"{index + 1} = {hashSet.ElementAt(index)}\n";
            }
            return result;
        }
    }
}
