using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class AvlTrees_Tests
    {
        private AvlTree _tree;
        private AvlNode Root;
        private Stopwatch _timer;
        

        [SetUp]
        public void Init()
        {
            _tree = new AvlTree();
            _timer = new Stopwatch();
        }

        [Test]
        public void Given_ThereAreNoValueInTheTree_When_InsertingTheValue_Then_ItShouldContainThoseValue()
        {
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 10);
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 20);
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 30);
            TestContext.WriteLine($"Tree before rotation: \n{_tree.PrintTree(_tree.Root)}");
            _tree = new AvlTree();
            _timer.Start();
            _tree.Root = _tree.Insert(_tree.Root, 10);
            _tree.Root = _tree.Insert(_tree.Root, 20);
            _tree.Root = _tree.Insert(_tree.Root, 30);
            _timer.Stop();
            Assert.IsTrue(_tree.Contain(_tree.Root, 10));
            Assert.IsTrue(_tree.Contain(_tree.Root, 20));
            Assert.IsTrue(_tree.Contain(_tree.Root, 30));
            TestContext.WriteLine($"Tree after rotation: \n{_tree.PrintTree(_tree.Root)}");
            TestContext.WriteLine($"Time for inserting into AVL Trees: {_timer.Elapsed}");
            TestContext.WriteLine($"Time for inserting into AVL Trees: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereAreNoValueInTheTree_When_InsertingTheMultipleValues_Then_ItShouldContainThoseValue()
        {
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 10);
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 20);
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 30);
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 35);
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 45);
            _tree.Root = _tree.InsertWithoutBalance(_tree.Root, 50);
            TestContext.WriteLine($"Tree before rotation: \n{_tree.PrintTree(_tree.Root)}");
            _tree = new AvlTree();
            _timer.Start();
            _tree.Root = _tree.Insert(_tree.Root, 10);
            _tree.Root = _tree.Insert(_tree.Root, 20);
            _tree.Root = _tree.Insert(_tree.Root, 30);
            _tree.Root = _tree.Insert(_tree.Root, 35);
            _tree.Root = _tree.Insert(_tree.Root, 45);
            _tree.Root = _tree.Insert(_tree.Root, 50);
            _timer.Stop();
            Assert.IsTrue(_tree.Contain(_tree.Root, 10));
            Assert.IsTrue(_tree.Contain(_tree.Root, 20));
            Assert.IsTrue(_tree.Contain(_tree.Root, 30));
            Assert.IsTrue(_tree.Contain(_tree.Root, 35));
            Assert.IsTrue(_tree.Contain(_tree.Root, 45));
            Assert.IsTrue(_tree.Contain(_tree.Root, 50));
            TestContext.WriteLine($"Tree after rotation: \n{_tree.PrintTree(_tree.Root)}");
            TestContext.WriteLine($"Time for inserting into AVL Trees: {_timer.Elapsed}");
            TestContext.WriteLine($"Time for inserting into AVL Trees: {_timer.ElapsedMilliseconds} ms");
        }
    }
}
