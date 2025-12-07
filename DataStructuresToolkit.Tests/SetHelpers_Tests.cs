using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class SetHelpers_Tests
    {
        private SetHelpers<string> _setHelpers;
        private Stopwatch _timer;
        private HashSet<string> setA;
        private HashSet<string> setB;

        [SetUp]
        public void Init()
        {
            _setHelpers = new SetHelpers<string>();
            _timer = new Stopwatch();
            setA = new HashSet<string> { "Test 1", "Test 2", "Test 3" };
            setB = new HashSet<string> { "Test 3", "Test 4", "Test 5" };
        }

        [Test]
        public void Given_ThereAreTwoSets_When_RunningTheUnion_Then_ItShouldCombineThoseTwoSets()
        {
            _timer.Start();
            var result = _setHelpers.Union(setA, setB);
            _timer.Stop();
            Assert.That(result, Does.Contain("Test 1"));
            Assert.That(result, Does.Contain("Test 2"));
            Assert.That(result, Does.Contain("Test 3"));
            Assert.That(result, Does.Contain("Test 4"));
            Assert.That(result, Does.Contain("Test 5"));
            TestContext.WriteLine($"Set with union: {result}");
            TestContext.WriteLine($"Time to run union on both set A and B: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to run union on both set A and B: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereAreTwoSets_When_RunningTheIntersection_Then_ItShouldReturnOnlyTheResultFromBothSets()
        {
            _timer.Start();
            var result = _setHelpers.Intersection(setA, setB);
            _timer.Stop();
            Assert.That(result, Does.Contain("Test 3"));
            TestContext.WriteLine($"Set with intersection: {result}");
            TestContext.WriteLine($"Time to run intersection on both set A and B: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to run intersection on both set A and B: {_timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereAreTwoSets_When_RunningTheDifference_Then_ItShouldReturnTheResultFromOnlyOneSet()
        {
            _timer.Start();
            var result = _setHelpers.Difference(setA, setB);
            _timer.Stop();
            Assert.That(result, Does.Contain("Test 1"));
            Assert.That(result, Does.Contain("Test 2"));
            TestContext.WriteLine($"Set with difference: {result}");
            TestContext.WriteLine($"Time to run difference on both set A and B: {_timer.Elapsed}");
            TestContext.WriteLine($"Time to run difference on both set A and B: {_timer.ElapsedMilliseconds} ms");
        }
    }
}
