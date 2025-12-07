using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class TreeToolkit_Tests
    {
        TreeNode _treeRoot;
        BST _bst;
        bool resultBool;
        List<int> _output;
        int resultNum;
        Stopwatch timer;

        [SetUp]
        public void SetUp()
        {
            _treeRoot = TreeNode.BuildTree();
            _bst = new BST();
            _output = new List<int>();
            timer = new Stopwatch();
            resultBool = new bool();
            resultNum = new int();
        }

        [Test]
        public void Given_There_Is_Value_In_The_Trees_When_Running_InOrder_Then_Output_Should_Contain_Correct_Values_In_InOrder_Form()
        {
            timer.Start();
            _treeRoot.InOrder(_treeRoot, _output);
            timer.Stop();
            Assert.That(_output, Is.EqualTo(new List<int>{ 3, 27, 9, 38, 43 }));
            TestContext.WriteLine($"Tree Inorder: {string.Join(", ", _output)}");
            TestContext.WriteLine($"Time for Inorder in tree: {timer.Elapsed}");
            TestContext.WriteLine($"Time for Inorder in tree: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Is_Value_In_The_Trees_When_Running_PreOrder_Then_Output_Should_Contain_Correct_Values_In_PreOrder_Form()
        {
            timer.Start();
            _treeRoot.PreOrder(_treeRoot, _output);
            timer.Stop();
            Assert.That(_output, Is.EqualTo(new List<int>{ 38, 27, 3, 9, 43 }));
            TestContext.WriteLine($"Tree Preorder: {string.Join(", ", _output)}");
            TestContext.WriteLine($"Time for Preorder in tree: {timer.Elapsed}");
            TestContext.WriteLine($"Time for Preorder in tree: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Is_Value_In_The_Trees_When_Running_PostOrder_Then_Output_Should_Contain_Correct_Values_In_PostOrder_Form()
        {
            timer.Start();
            _treeRoot.PostOrder(_treeRoot, _output);
            timer.Stop();
            Assert.That(_output, Is.EqualTo(new List<int> { 3, 9, 27, 43, 38 }));
            TestContext.WriteLine($"Tree PostOrder: {string.Join(", ", _output)}");
            TestContext.WriteLine($"Time for Postorder in tree: {timer.Elapsed}");
            TestContext.WriteLine($"Time for Postorder in tree: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Is_Values_In_The_Tree_When_Running_Height_Then_Result_Should_Be_Two_With_Current_Tree()
        {
            timer.Start();
            resultNum = _treeRoot.Height(_treeRoot);
            timer.Stop();
            Assert.That(resultNum, Is.EqualTo(2));
            TestContext.WriteLine($"Tree Height: {resultNum}");
            TestContext.WriteLine($"Time for Height: {timer.Elapsed}");
            TestContext.WriteLine($"Time for Height: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Is_Values_In_The_Tree_When_Running_Depths_Then_Result_Should_Contain_Correct_Depths()
        {
            timer.Start();
            resultNum = _treeRoot.Depth(_treeRoot, 38);
            Assert.That(resultNum, Is.EqualTo(0));
            TestContext.WriteLine($"Depth at 38: {resultNum}");
            resultNum = _treeRoot.Depth(_treeRoot, 27);
            Assert.That(resultNum, Is.EqualTo(1));
            TestContext.WriteLine($"Depth at 27: {resultNum}");
            resultNum = _treeRoot.Depth(_treeRoot, 43);
            Assert.That(resultNum, Is.EqualTo(1));
            TestContext.WriteLine($"Depth at 43: {resultNum}");
            resultNum = _treeRoot.Depth(_treeRoot, 3);
            Assert.That(resultNum, Is.EqualTo(2));
            TestContext.WriteLine($"Depth at 3: {resultNum}");
            resultNum = _treeRoot.Depth(_treeRoot, 9);
            Assert.That(resultNum, Is.EqualTo(2));
            TestContext.WriteLine($"Depth at 9: {resultNum}");
            timer.Stop();
            TestContext.WriteLine($"Time at Depth: {timer.Elapsed}");
            TestContext.WriteLine($"Time at Depth: {timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_There_Is_No_Value_In_Binary_Tree_When_Inserting_Value_Then_It_Should_Be_Inserted_With_Balanced()
        {
            timer.Start();
            var nums = new List<int>() { 50, 30, 70, 20, 40, 60, 80 };
            foreach(int num in nums)
            {
                _bst.InsertValue(num);
            }
            resultBool = _bst.IsContainValue(50);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(30);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(70);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(20);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(40);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(60);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(80);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(55);
            Assert.IsFalse(resultBool);
            timer.Stop();
            TestContext.WriteLine($"Time to insert and contain value in balanced tree: {timer.Elapsed}");
            TestContext.WriteLine($"Time to insert and contain value in balanced tree: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Is_No_Value_In_Binary_Tree_When_Inserting_Value_With_Skewed_Right_Then_It_Should_Be_Inserted()
        {
            timer.Start();
            var nums = new List<int>(){10, 20, 30, 40, 50};
            foreach(int num in nums)
            {
                _bst.InsertValue(num);
            }
            resultBool = _bst.IsContainValue(10);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(20);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(30);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(40);
            Assert.IsTrue(resultBool);
            resultBool = _bst.IsContainValue(50);
            Assert.IsTrue(resultBool);
            timer.Stop();
            TestContext.WriteLine($"Time to insert and contain value in skewed tree: {timer.Elapsed}");
            TestContext.WriteLine($"Time to insert and contain value in skewed tree: {timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_There_Is_Values_In_Binary_Trees_When_Checking_For_Height_In_Skewed_Trees_Then_It_Should_Return_More_Height_From_One_Side_Than_Other()
        {
            var nums = new List<int>() { 10, 20, 30, 40, 50 };
            foreach (int num in nums)
            {
                _bst.InsertValue(num);
            }
            timer.Start();
            resultNum = _bst.Height(_bst.root);
            timer.Stop();
            Assert.That(resultNum, Is.EqualTo(4));
            TestContext.WriteLine($"Tree Height: {resultNum}");
            TestContext.WriteLine($"Time to check height in skewed tree: {timer.Elapsed}");
            TestContext.WriteLine($"Time to check height in skewed tree: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_There_Is_Values_In_Binary_Trees_When_Checking_For_Height_In_Balanced_Trees_Then_It_Should_Return_The_Height()
        {
            var nums = new List<int>() { 50, 30, 70, 20, 40, 60, 80 };
            foreach (int num in nums)
            {
                _bst.InsertValue(num);
            }
            timer.Start();
            resultNum = _bst.Height(_bst.root);
            timer.Stop();
            Assert.That(resultNum, Is.EqualTo(2));
            TestContext.WriteLine($"Tree Height: {resultNum}");
            TestContext.WriteLine($"Time to check height in skewed tree: {timer.Elapsed}");
            TestContext.WriteLine($"Time to check height in skewed tree: {timer.ElapsedMilliseconds} ms");
        }
    }
}
