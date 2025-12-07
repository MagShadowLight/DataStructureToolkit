// I have chose to extend the toolkit with both the graph feature and the set feature because I could use both the
// graph traversal and the set feature like union, intersection or the difference between the two sets to benchmarks
// between those two along with the other structures like the linked lists, arrays, trees, and some other as well as the
// algorithms like the simple, easy bubble sort that uses nested loops which was inefficient for large dataset. The
// benchmarks comparison with the linked list traversal and the regular list traversal revealed that the linked lists
// when searching through a value in a large amount of data in a linked list, it was linearly slower to find a specific
// value due to how it traverse through the nodes one by one before the target found one in that collection where as
// the regular dynamic lists found the target in an instant with the random access with the array functionality instead
// of using a node and the connection between those nodes. This works have strengthen my capstone’s efficiency and
// the clarity for the next week showcase by providing more tests with the time complexity to see how long it should take
// as well as the space complexity.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class GraphHelpers<T>
    {
        /// <summary>
        /// BFS: Traverse and search through the graph with the breadth first
        /// </summary>
        /// <param name="startVertex">The starting point of the graph to traverse</param>
        /// <param name="graph">The graph that for traversing through from the vertex</param>
        /// <returns>The text result of the graph from traversing through the graph</returns>
        /// <remarks>
        /// Time Complexity: O(V+E) where as V = Vertex in the graph and E = edge in the graph
        /// Space Complexity: O(V) where as V = Vertex in the graph
        /// </remarks>
        public string BFS(T startVertex, Dictionary<T, List<T>> graph)
        {
            var visitedVertex = new HashSet<T>();
            var queue = new Queue<T>();
            string result = string.Empty;
            queue.Enqueue(startVertex);
            while(queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (!visitedVertex.Contains(vertex))
                {
                    result = result + $"{vertex}\n";
                    visitedVertex.Add(vertex);
                    foreach(var neighbor in graph[vertex])
                        queue.Enqueue(neighbor);
                }
            }
            return result;
        }
        /// <summary>
        /// DFS: Traverse and search through the graph with depth first
        /// </summary>
        /// <param name="vertex">The current vertex of the graph</param>
        /// <param name="graph">The graph that for traversing through to get result</param>
        /// <param name="visitedVertex">The vertex that have been visited from the graph</param>
        /// <param name="result">The text output from the graph traversal</param>
        /// <returns>The text output from traversing through the graph</returns>
        /// <remarks>
        /// Time Complexity: O(V+E) where as V = vertex in the graph and E = edges in the graph
        /// Space Complexity O(V) where as V = vertex in the graph
        /// </remarks>
        public string DFS(T vertex, Dictionary<T, List<T>> graph, HashSet<T> visitedVertex, string result)
        {
            if (visitedVertex.Contains(vertex))
                return result;

            result = result + Convert.ToString(vertex) + " ";
            visitedVertex.Add(vertex);

            foreach(var neighbor in graph[vertex])
            {
                result = DFS(neighbor, graph, visitedVertex, result);
            }
            return result;
        }
    }
}
