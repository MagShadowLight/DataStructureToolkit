using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructuresToolkit
{
    public class TreeNode
    {
        public int Value;
        TreeNode? LeftNode;
        TreeNode? RightNode;
        string result = "";

        public TreeNode(int value)
        {
            Value = value;
        }

        public static TreeNode BuildLargeTree(TreeNode? node, int value)
        {
            if (node == null)
                return new TreeNode(value);

            if (value < node.Value)
                node.LeftNode = BuildLargeTree(node.LeftNode, value);
            if (value > node.Value)
                node.RightNode = BuildLargeTree(node.RightNode, value);
            return node;
         }

        public string PrintTree(TreeNode? root, string message, string indent = "")
        {
            if (root == null) return "";
            result = result + indent + message + root.Value + "\n";
            PrintTree(root.LeftNode, "Left Node: ", indent + "   ");
            PrintTree(root.RightNode, "Right Node: ", indent + "   ");
            return result;
        }

        public static TreeNode BuildTree()
        {
            var root = new TreeNode(38);
            root.LeftNode = new TreeNode(27)
            {
                LeftNode = new TreeNode(3),
                RightNode = new TreeNode(9)
            };
            root.RightNode = new TreeNode(43);
            return root;
        }
        /// <summary>
        /// InOrder: traverse the tree from the left side of the root node and grab those value, then grab the root value, and then traverse to the right side of the root node and grab
        /// those values and return the output as a list.
        /// </summary>
        /// <param name="root">The current node of the tree to traverse.</param>
        /// <param name="output">The list of the result as a numbers.</param>
        /// <remarks>Time Complexity: O(n)</remarks>
        public void InOrder(TreeNode? root, List<int> output)
        {
            if (root == null) return;
            InOrder(root.LeftNode, output);
            output.Add(root.Value);
            InOrder(root.RightNode, output);
        }
        /// <summary>
        /// PreOrder: grab the value from the root node then traverse through the left of root node and grab those values and then traverse through the right side of root node
        /// and grab those values and then return the output as a list.
        /// </summary>
        /// <param name="root">The current node of the tree to traverse</param>
        /// <param name="output">The list that would be result as numbers</param>
        /// <remarks>Time Complexity: O(n)</remarks>
        public void PreOrder(TreeNode? root, List<int> output)
        {
            if (root == null) return;
            output.Add(root.Value);
            PreOrder(root.LeftNode, output);
            PreOrder(root.RightNode, output);
        }
        /// <summary>
        /// PostOrder: Traverse through the left side of the root node and grab those values, then through the right side of the root node and grab those,
        /// and then grab the value from the root node and return the output as a list.
        /// </summary>
        /// <param name="root">The current node of the tree to traverse</param>
        /// <param name="output">The list that are for result as numbers.</param>
        /// <remarks>Time Complexity: O(n)</remarks>
        public void PostOrder(TreeNode? root, List<int> output)
        {
            if (root == null) return;
            PostOrder(root.LeftNode, output);
            PostOrder(root.RightNode, output);
            output.Add(root.Value);
        }
        /// <summary>
        /// Height: Traverse through the tree and check if one side from the root node has more depth than the other and return the height as a number.
        /// </summary>
        /// <param name="root">The current node of the tree to traverse</param>
        /// <returns>The height of the tree.</returns>
        /// <remarks>Time Complexity: O(n)</remarks>
        public int Height(TreeNode? root)
        {
            if (root == null) return -1;
            int LeftHeight = Height(root.LeftNode);
            int RightHeight = Height(root.RightNode);
            return 1 + Math.Max(LeftHeight, RightHeight);
        }
        /// <summary>
        /// Depth: Search through the tree to find the target value by traversing through the tree and returns the depth of the target if that target have been found otherwise
        /// return -1 if the target is not found.
        /// </summary>
        /// <param name="root">The current node of the tree to traverse</param>
        /// <param name="target">The number that would be searching for in the tree</param>
        /// <returns>The depth of the tree if the target have been found in the tree otherwise -1.</returns>
        /// <remarks>Time Complexity: O(n)</remarks>
        public int Depth(TreeNode? root, int target)
        {
            int depth = 0;
            if (root == null) return -1;
            else if (root.Value == target) return 0;
            int left = Depth(root.LeftNode, target);
            if (left != -1) return left + 1;
            int right = Depth(root.RightNode, target);
            if (right != -1) return right + 1;
            return -1;
        }
    }

    public class BST
    {
        string result = "";
        public class BinaryNode
        {
            public int Value;
            public BinaryNode? LeftNode;
            public BinaryNode? RightNode;
            public BinaryNode(int value)
            {
                Value = value;
            }
        }

        public BinaryNode? root { get; private set; }
        /// <summary>
        /// InsertValue: Inserting the value into the tree starting at the root then traverse down the tree from the left side if the number from the root is greater than
        /// the value or the right side if the number from the root is less than the value.
        /// </summary>
        /// <param name="value">The number that will be inserted into the tree</param>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(log n)
        /// Worst Case Time Complexity: O(n)
        /// </remarks>
        public void InsertValue(int value)
        {
            if (root == null)
            {
                root = new BinaryNode(value);
                return;
            }

            var branch = root;
            while (true)
            {
                if (value < branch.Value)
                {
                    if (branch.LeftNode == null)
                    {
                        branch.LeftNode = new BinaryNode(value);
                        return;
                    }
                    branch = branch.LeftNode;
                }
                else if (value > branch.Value)
                {
                    if (branch.RightNode == null)
                    {
                        branch.RightNode = new BinaryNode(value);
                        return;
                    }
                    branch = branch.RightNode;
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// IsContainValue: Searching through the tree for the target by traversing the tree from left side from the root to the right side from the root.
        /// If the target is found in that tree, return true otherwise it return false
        /// </summary>
        /// <param name="value">The target number that would be searching for in the tree</param>
        /// <returns>it return true if the target is in the tree or false if the target is not in the tree.</returns>
        /// <remarks>
        /// Best or Average Case Time Complexity: O(log n)
        /// Worst Case Time Complexity: O(n)
        /// </remarks>
        public bool IsContainValue(int value)
        {
            var branch = root;
            while (branch != null)
            {
                if (value == branch.Value) return true;
                branch = value < branch.Value ? branch.LeftNode : branch.RightNode;
            }
            return false;
        }
        /// <summary>
        /// Height: Traverse through the tree and check if one side from the root has more depth than the other or the same depth on both and return the height as a number.
        /// </summary>
        /// <param name="root">The current node of the tree</param>
        /// <returns>The height of the tree. If the tree is skewed, the height is greater.</returns>
        /// <remarks>Time Complexity: O(n)</remarks>
        public int Height(BinaryNode? root)
        {
            if (root == null) return -1;
            int leftNode = Height(root.LeftNode);
            int rightNode = Height(root.RightNode);
            return 1 + Math.Max(leftNode, rightNode);
        }
        public string PrintTree(BinaryNode? root, string message, string indent = "")
        {
            if (root == null) return "";
            result = result + indent + message + root.Value + "\n";
            PrintTree(root.LeftNode, "Left Node: ", indent + "   ");
            PrintTree(root.RightNode, "Right Node: ", indent + "   ");
            return result;
        }
    }
}
