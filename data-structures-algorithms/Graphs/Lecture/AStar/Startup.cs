using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AStar
{
    class Startup
    {
        private static string input = @"6
11
1 2 2
1 3 3
1 4 11
2 3 3
2 5 15
3 4 2
3 5 6
4 5 3
1 6 100
2 6 100
5 6 1
";

        public static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();

            //var graph = GetGraphWithAdjacencyList();
            var graph = GetGraphWithMatrix();

            var heuristicValues = new List<int>() { 0, 10, 4, 2, 2, 0, 7 };

            var distanceToEndPoint = AStarToEndPoint(graph, 1, 5, heuristicValues);

            Console.WriteLine(distanceToEndPoint);

            // print path from direct access

            var result = AStarPathToEnd(graph, 1, 5, heuristicValues);
            Console.WriteLine(string.Join(" <- ", result));


        }

        public static int AStarToEndPoint(List<List<Node>> graph, int startNode, int endNode, List<int> heuristicValues)
        {
            var distanceToEnd = -1;
            var distances = new int[graph.Count];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<HeuristicNode>((a, b) => (a.Weight + a.HeuristicValue) < (b.Weight + b.HeuristicValue));
            queue.Enqueue(new HeuristicNode(startNode, 0, heuristicValues[startNode]));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }
                if (node.Vertex == endNode)
                {
                    distanceToEnd = distances[node.Vertex];
                    break;
                }
                used.Add(node.Vertex);

                foreach (var next in graph[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Weight;
                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    distances[next.Vertex] = newDistance;
                    queue.Enqueue(new HeuristicNode(next.Vertex, newDistance, heuristicValues[next.Vertex]));
                }
            }
            return distanceToEnd;
        }

        public static int AStarToEndPoint(int[,] graph, int startNode, int endNode, List<int> heuristicValues)
        {
            var distanceToEnd = -1;
            var distances = new int[graph.GetLength(0)];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<HeuristicNode>((a, b) => (a.Weight + a.HeuristicValue) < (b.Weight + b.HeuristicValue));
            queue.Enqueue(new HeuristicNode(startNode, 0, heuristicValues[startNode]));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                if (node.Vertex == endNode)
                {
                    distanceToEnd = distances[node.Vertex];
                    break;
                }

                used.Add(node.Vertex);

                for (int to = 1; to < graph.GetLength(1); to++)
                {
                    if (graph[node.Vertex, to] == 0)
                    {
                        continue;
                    }

                    var currentDistance = distances[to];
                    var newDistance = distances[node.Vertex] + graph[node.Vertex, to];

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    distances[to] = newDistance;
                    queue.Enqueue(new HeuristicNode(to, newDistance, heuristicValues[to]));
                }
            }
            return distanceToEnd;
        }
        
        public static int[] AStarPathToEnd(List<List<Node>> graph, int startNode, int endNode, List<int> heuristicValues)
        {
            var path = new int[graph.Count];
            path[startNode] = -1;

            var distances = new int[graph.Count];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<HeuristicNode>((a, b) => (a.Weight + a.HeuristicValue) < (b.Weight + b.HeuristicValue));
            queue.Enqueue(new HeuristicNode(startNode, 0, heuristicValues[startNode]));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                if (node.Vertex == endNode)
                {
                    break;
                }

                used.Add(node.Vertex);

                foreach (var next in graph[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Weight;

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }

                    path[next.Vertex] = node.Vertex;
                    distances[next.Vertex] = newDistance;
                    queue.Enqueue(new HeuristicNode(next.Vertex, newDistance, heuristicValues[next.Vertex]));
                }
            }

            var pathToDestination = new List<int>();

            var current = endNode;

            while (current != -1)
            {
                pathToDestination.Add(current);
                current = path[current];
            }

            return pathToDestination.ToArray();
        }

        public static int[] AStarPathToEnd(int[,] graph, int startNode, int endNode, List<int> heuristicValues)
        {
            var path = new int[graph.GetLength(0)];
            path[startNode] = -1;

            var distances = new int[graph.GetLength(0)];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<HeuristicNode>((a, b) => (a.Weight + a.HeuristicValue) < (b.Weight + b.HeuristicValue));
            queue.Enqueue(new HeuristicNode(startNode, 0, heuristicValues[startNode]));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                if (node.Vertex == endNode)
                {
                    break;
                }

                used.Add(node.Vertex);

                for (int to = 1; to < graph.GetLength(1); to++)
                {
                    if (graph[node.Vertex, to] == 0)
                    {
                        continue;
                    }

                    var currentDistance = distances[to];
                    var newDistance = distances[node.Vertex] + graph[node.Vertex, to];

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    path[to] = node.Vertex;
                    distances[to] = newDistance;
                    queue.Enqueue(new HeuristicNode(to, newDistance, heuristicValues[to]));
                }
            }

            var pathToDestination = new List<int>();

            var current = endNode;

            while (current != -1)
            {
                pathToDestination.Add(current);
                current = path[current];
            }

            return pathToDestination.ToArray();
        }

        public static List<List<Node>> GetGraphWithAdjacencyList()
        {
            var verticesCount = int.Parse(Console.ReadLine());

            var edgesCount = int.Parse(Console.ReadLine());

            var graph = new List<List<Node>>(verticesCount + 1);

            for (int i = 0; i < verticesCount + 1; i++)
            {
                graph.Add(new List<Node>());
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var from = vertices[0];
                var to = vertices[1];

                var node = new Node();
                node.Vertex = vertices[1];
                node.Weight = vertices[2];
                graph[from].Add(node);

                // undirected
                var node2 = new Node();
                node2.Vertex = vertices[0];
                node2.Weight = vertices[2];
                graph[to].Add(node2);
            }

            return graph;
        }

        public class Node
        {
            public Node()
            {

            }

            public Node(int to, int weight)
            {
                this.Vertex = to;
                this.Weight = weight;
            }

            public int Vertex { get; set; }

            public int Weight { get; set; }
        }

        public class HeuristicNode
        {
            public HeuristicNode(int vertex, int weight, int heuristicValue)
            {
                this.Vertex = vertex;
                this.Weight = weight;
                this.HeuristicValue = heuristicValue;
            }

            public int Vertex { get; set; }
            public int HeuristicValue { get; set; }
            public int Weight { get; set; }
        }

        public static int[,] GetGraphWithMatrix()
        {
            var verticesCount = int.Parse(Console.ReadLine());

            var matrix = new int[verticesCount + 1, verticesCount + 1];

            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var from = vertices[0];
                var to = vertices[1];
                var weight = vertices[2];

                matrix[from, to] = weight;
                // undirected
                matrix[to, from] = weight;
            }

            return matrix;
        }
    }
}
