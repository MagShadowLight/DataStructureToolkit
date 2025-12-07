using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class SetHelpers<T>
    {
        /// <summary>
        /// Union: combine both sets into one set.
        /// </summary>
        /// <param name="setA">One side of the set to be combined</param>
        /// <param name="setB">Other side of the set to be combined</param>
        /// <returns>The text result of the combined set</returns>
        /// <remarks>
        /// Best and Average Case Time Complexity: O(n + m) where as n = one set and m = other set.
        /// Worst Case Time Complexity: O(n * m) where as n = one set and m = other set
        /// Space Complexity: O(n)
        /// </remarks>
        public string Union(HashSet<T> setA, HashSet<T> setB)
        {
            setA.UnionWith(setB);
            return string.Join(", ", setA);
        }
        /// <summary>
        /// Intersection: Return the elements that was in both sets.
        /// </summary>
        /// <param name="setA">One set that return the elements which also in setB</param>
        /// <param name="setB">Other set that return elements which also in setA</param>
        /// <returns>The text result of the elements that returns from both sets</returns>
        /// <remarks>
        /// Best and Average Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public string Intersection(HashSet<T> setA, HashSet<T> setB)
        {
            setA.IntersectWith(setB);
            return string.Join(", ", setA);
        }
        /// <summary>
        /// Difference: Return the elements that only from one sets but not in both sets
        /// </summary>
        /// <param name="setA">One set that return the elements only in this sets but not in setB</param>
        /// <param name="setB">Other set that exclude those elements that in setA</param>
        /// <returns>The text result that return elements from only one set</returns>
        /// <remarks>
        /// Best and Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public string Difference(HashSet<T> setA, HashSet<T> setB)
        {
            setA.ExceptWith(setB);
            return string.Join(", ", setA);
        }
        
    }
}
