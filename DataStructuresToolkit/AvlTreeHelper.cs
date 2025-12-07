using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class AvlNode
    {
        public int Key { get; set; }
        public AvlNode? LeftNode;
        public AvlNode? RightNode;
        public int Height = 1;
        public AvlNode(int key)
        {
            Key = key;
        }
    }

    public class AvlTree
    {
        string result = "";
        public AvlNode? Root;
        private int Height(AvlNode? node) => node?.Height ?? 0;

        public int BalanceFactor(AvlNode? node) => node == null ? 0 : Height(node.LeftNode) - Height(node.RightNode);
        /// <summary>
        /// InsertWithoutBalance: Inserting the value into the tree.
        /// </summary>
        /// <param name="node">The current node of the tree</param>
        /// <param name="value">The value that will be inserted</param>
        /// <returns>It return the new node if that node is not existing otherwise it return the current node</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(log n)
        /// Worst Case Time Complexity: O(n)
        /// </remarks>
        public AvlNode InsertWithoutBalance(AvlNode? node, int value)
        {
            if (node == null) return new AvlNode(value);

            if (value < node.Key)
                node.LeftNode = InsertWithoutBalance(node.LeftNode, value);
            if (value > node.Key)
                node.RightNode = InsertWithoutBalance(node.RightNode, value);
            return node;
        }
        /// <summary>
        /// Insert: Inserting the value into the tree and then balancing the tree if it off balance by rotating left or right
        /// </summary>
        /// <param name="node">The current node of the tree</param>
        /// <param name="value">The value that will be inserted</param>
        /// <returns>It returns the new node if that node is not existing otherwise it return the current node or the rotated node if the tree is off balance</returns>
        /// <remarks>Time Complexity: O(log n)</remarks>
        public AvlNode Insert(AvlNode? node, int value)
        {
            if (node == null) return new AvlNode(value);

            if (value < node.Key)
                node.LeftNode = Insert(node.LeftNode, value);
            if (value > node.Key) 
                node.RightNode = Insert(node.RightNode, value);

            node.Height = 1 + Math.Max(Height(node.LeftNode), Height(node.RightNode));
            int balanceFactor = BalanceFactor(node);

            if (balanceFactor > 1 && value > node.LeftNode!.Key)
            {
                node.LeftNode = RotateLeft(node.LeftNode);
                return RotateRight(node);
            }

            if (balanceFactor < -1 && value < node.RightNode!.Key)
            {
                node.RightNode = RotateRight(node.RightNode);
                return RotateLeft(node);
            }

            if (balanceFactor > 1 && value < node.LeftNode!.Key)
                return RotateRight(node);

            if (balanceFactor < -1 && value > node.RightNode!.Key)
                return RotateLeft(node);

            return node;
        }
        /// <summary>
        /// RotateLeft: rotating the value of the parent and the child node to the left
        /// </summary>
        /// <param name="parentNode">The node that has the child nodes</param>
        /// <returns>It return the right child node from the parent node</returns>
        /// <remarks>Time Complexity: O(1)</remarks>
        public AvlNode RotateLeft(AvlNode? parentNode)
        {
            AvlNode childNode1 = parentNode.RightNode!;
            AvlNode childNode2 = childNode1.LeftNode!;
            childNode1.LeftNode = parentNode;
            parentNode.RightNode = childNode2;
            parentNode.Height = Math.Max(Height(parentNode.LeftNode), Height(parentNode.RightNode)) + 1;
            childNode1.Height = Math.Max(Height(childNode1.LeftNode), Height(childNode1.RightNode)) + 1;
            return childNode1;
        }
        /// <summary>
        /// RotateRight: rotating the value of the parent and the child node to the right
        /// </summary>
        /// <param name="parentNode">The node that has the child nodes</param>
        /// <returns>It returns the left child node from the parent node</returns>
        /// <remarks>Time Complexity: O(1)</remarks>
        public AvlNode RotateRight(AvlNode? parentNode)
        {
            AvlNode childNode1 = parentNode.LeftNode!;
            AvlNode childNode2 = childNode1.RightNode!;
            childNode1.RightNode = parentNode;
            parentNode.LeftNode = childNode2;
            parentNode.Height = Math.Max(Height(parentNode.LeftNode), Height(parentNode.RightNode)) + 1;
            childNode1.Height = Math.Max(Height(childNode1.LeftNode), Height(childNode1.RightNode)) + 1;
            return childNode1;
        }
        /// <summary>
        /// Contain: It searches for the target that the tree has.
        /// </summary>
        /// <param name="node">The current node of the tree</param>
        /// <param name="target">The value that will be searching for</param>
        /// <returns>If the value in the tree have been found, it would return true otherwise it return false</returns>
        /// <remarks>Time Complexity: O(log n)</remarks>
        public bool Contain(AvlNode? node, int target)
        {
            while (node != null)
            {
                if (target == node.Key) return true;
                node = target < node.Key ? node.LeftNode : node.RightNode;
            }
            return false;
        }
        /// <summary>
        /// PrintTree: Printing the tree to see the result
        /// </summary>
        /// <param name="node">The current node of the tree</param>
        /// <param name="indent">The amount of space if the node come from the parent tree</param>
        /// <param name="isLeft">check if the child node is the left side from the parent node or the right side from the parent node</param>
        /// <returns>It return the result of the tree to print</returns>
        /// <remarks>Time Complexity: O(n)</remarks>
        public string PrintTree(AvlNode? node, string indent = "", bool isLeft = true)
        {
            if (node == null) return "";
            result = result + indent + (isLeft == true ? "LeftNode: " : "RightNode: ") + node.Key + $"BF=({BalanceFactor(node)})\n";
            PrintTree(node.LeftNode, indent + "   ", true);
            PrintTree(node.RightNode, indent + "   ", false);
            return result;
        }
    }
}
