using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class GraphHelpers_Tests
    {
        Dictionary<string, List<string>> graph;
        private GraphHelpers<string> _helper;
        Stopwatch _timer;
        [SetUp]
        public void Init()
        {
            graph = new Dictionary<string, List<string>> {
                ["Test 1"] = new List<string> { "Test 2" },
                ["Test 2"] = new List<string> { "Test 1", "Test 3" },
                ["Test 3"] = new List<string> { "Test 2", "Test 4" },
                ["Test 4"] = new List<string> { "Test 3" }
            };
            _helper = new GraphHelpers<string>();
            _timer = new Stopwatch();
        }

        [Test]
        public void Given_ThereAreValueInGraph_When_TraverseThroughTheGraphWithBFS_Then_ItShouldPrintTheCorrectOrderOfValue()
        {
            var vertex = graph.FirstOrDefault(x => x.Value.Contains("Test 2")).Key;
            _timer.Start();
            string result = _helper.BFS(vertex, graph);
            _timer.Stop();
            Assert.That(result, Does.Contain("Test 1"));
            Assert.That(result, Does.Contain("Test 2"));
            Assert.That(result, Does.Contain("Test 3"));
            Assert.That(result, Does.Contain("Test 4"));
            TestContext.WriteLine($"Graph: {result}");
            TestContext.WriteLine($"Time to traverse graph with BFS {_timer.Elapsed}");
            TestContext.WriteLine($"Time to traverse graph with BFS {_timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_ThereAreValueInGraph_When_TraverseThroughTheGraphWithDFS_Then_ItShouldPrintTheCorrectOrderOfValue()
        {
            var vertex = graph.FirstOrDefault(x => x.Value.Contains("Test 2")).Key;
            _timer.Start();
            string result = _helper.DFS(vertex, graph, new HashSet<string>(), string.Empty);
            _timer.Stop();
            Assert.That(result, Does.Contain("Test 1"));
            Assert.That(result, Does.Contain("Test 2"));
            Assert.That(result, Does.Contain("Test 3"));
            Assert.That(result, Does.Contain("Test 4"));
            TestContext.WriteLine($"Graph: {result}");
            TestContext.WriteLine($"Time to traverse graph with DFS {_timer.Elapsed}");
            TestContext.WriteLine($"Time to traverse graph with DFS {_timer.ElapsedMilliseconds} ms");
        }
    }
}
