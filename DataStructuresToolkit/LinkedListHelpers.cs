// I have learned about the linked list being different from both the array and the regular list. The array was using the fixed amount of data inside the array as well as not
// being efficient when adding and deleting the value inside the array. The list<T> uses the array to not only add or remove the value into that array but also resize the array
// capacity by copying the array and doubling the original capacity of the list. The linked list uses the node instead of using the array with the data and the reference to other
// nodes. Linked lists give away the fast random access from the array for the fast modification with the memory usage flexibility. The doubly linked list makes sense to use for
// the undo or redo functionality of the text editor or the code editor. The game with the turn-based combat like some Final Fantasy or Pokémon games makes sense to use the circular
// linked list instead of the doubly or singly linked list because it uses the cycle to fight certain enemies. This exercise deepens my understanding of the pointers and references
// because it allows me to manipulate the structure from the tree to the linked list with one node referencing another node by adding or removing data in that node.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> NextNode { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
        }
    }

    public class DoublyNode<T>
    {
        public T Data { get; set; }
        public DoublyNode<T> NextNode { get; set; }
        public DoublyNode<T> PrevNode { get; set; }

        public DoublyNode(T data)
        {
            Data = data;
        }
    }
    public class SinglyLinkedList<T>
    {
        public LinkedListNode<T> HeadNode { get; set; }
        /// <summary>
        /// AddFirst: Insert the data in front of the head node inside singly linked list
        /// </summary>
        /// <param name="data">The value that would be added in front of the linked list</param>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(1)
        /// Worst Case Time Complexity: O(1)
        /// Space Complexity: O(n)
        /// </remarks>
        public void AddFirst(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);
            node.NextNode = HeadNode;
            HeadNode = node;
        }
        /// <summary>
        /// Traverse: Traverse through the linked list from the head of the list to the end. 
        /// </summary>
        /// <returns>The text result of the linked list from the traversal</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(n)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public string Traverse()
        {
            LinkedListNode<T> currentNode = HeadNode;
            string result = string.Empty;
            result += "Linked List:\n";
            while (currentNode != null)
            {
                result += currentNode.Data + ", ";
                currentNode = currentNode.NextNode;
            }
            return result;
        }
        /// <summary>
        /// Contains: Search through the linked list for the particular value and return true or false whether that valus is contain in that list
        /// </summary>
        /// <param name="data">The value that woule be used to search for</param>
        /// <returns>It return true if that value is contain in linked list otherwise it return false</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(n)
        /// Worst Case Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public bool Contains(T data)
        {
            LinkedListNode<T> currentNode = HeadNode;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                    return true;
                currentNode = currentNode.NextNode;
            }
            return false;
        }
    }

    public class DoublyLinkedList<T>
    {
        public DoublyNode<T> HeadNode { get; set; }
        public DoublyNode<T> TailNode { get; set; }
        /// <summary>
        /// AddFirst: Insert the value in front of the head node in Doubly Linked List
        /// </summary>
        /// <param name="data">The value that would be inserted in front of head node</param>
        /// <remarks>
        /// Time Complexity: O(1)
        /// Space Complexity: O(n)
        /// </remarks>
        public void AddFirst(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (HeadNode == null)
                HeadNode = TailNode = newNode;
            else
            {
                newNode.NextNode = HeadNode;
                HeadNode.PrevNode = newNode;
                HeadNode = newNode;
            }
        }
        /// <summary>
        /// AddLast: Insert the value behind the tail node in Doubly Linked List
        /// </summary>
        /// <param name="data">The value that would be inserted behind the tail node</param>
        /// <remarks>
        /// Time Complexity: O(1)
        /// Space Complexity: O(n)
        /// </remarks>
        public void AddLast(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (TailNode == null)
                HeadNode = TailNode = newNode;
            else
            {
                newNode.PrevNode = TailNode;
                TailNode.NextNode = newNode;
                TailNode = newNode;
            }
        }
        /// <summary>
        /// TraverseForward: Traverse through the linked list from the head node to the tail node and return the result.
        /// </summary>
        /// <returns>The text result of the linked list from the traversal</returns>
        /// <remarks>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public string TraverseForward()
        {
            DoublyNode<T> currentNode = HeadNode;
            var result = string.Empty;
            result += "Linked List:\n";
            while (currentNode != null)
            {
                result += currentNode.Data + ", ";
                currentNode = currentNode.NextNode;
            }
            return result;
        }
        /// <summary>
        /// TraverseBackward: Traverse through the linked list from the tail node to the head node and return the result.
        /// </summary>
        /// <returns>The text result of the linked list from the traversal</returns>
        /// <remarks>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public string TraverseBackward()
        {
            DoublyNode<T> currentNode = TailNode;
            string result = string.Empty;
            result += "Linked List:\n";
            while (currentNode != null)
            {
                result += currentNode.Data + ", ";
                currentNode = currentNode.PrevNode;
            }
            return result;
        }
        /// <summary>
        /// GetNode: search for the node from that value and return that node as a result.
        /// </summary>
        /// <param name="data">The value to search the node for</param>
        /// <returns>It return the node if that node contain that value otherwise it return null</returns>
        /// <remarks>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public DoublyNode<T> GetNode(T data)
        {
            var currentNode = HeadNode;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }
        /// <summary>
        /// Remove: Remove that node from the linked list.
        /// </summary>
        /// <param name="currentNode">The current node of the list</param>
        /// <remarks>
        /// Time Complexity: O(1)
        /// Space Complexity: O(n)
        /// </remarks>
        public void Remove(DoublyNode<T> currentNode)
        {
            if (currentNode == null)
                return;

            if (currentNode.PrevNode != null)
                currentNode.PrevNode.NextNode = currentNode.NextNode;
            else
                HeadNode = currentNode.NextNode;
            if (currentNode.NextNode != null)
                currentNode.NextNode.PrevNode = currentNode.PrevNode;
            else
                TailNode = currentNode.PrevNode;
        }
        /// <summary>
        /// Contains: Search the node that contains those values.
        /// </summary>
        /// <param name="data">The value to search for the node</param>
        /// <returns>It return true if that node contains those value otherwise it return false</returns>
        /// <remarks>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </remarks>
        public bool Contains(T data)
        {
            DoublyNode<T> currentNode = HeadNode;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                    return true;
                currentNode = currentNode.NextNode;
            }
            return false;
        }
    }
}
