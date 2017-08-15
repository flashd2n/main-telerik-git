using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BellmanFord
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
3 5 -2
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

            var allDistances = BellmanFord(graph, 1);
            Console.WriteLine(string.Join(" ", allDistances));

            var allpaths = BellmanFordPaths(graph, 1);
            Console.WriteLine(string.Join(" ", allpaths));

            //path to a node

            var current = 4;

            while (current != -1)
            {
                Console.Write(current + " <- ");
                current = allpaths[current];
            }
            Console.WriteLine();
        }

        public static int[] BellmanFord(List<List<Node>> graph, int startNode)
        {
            var distances = new int[graph.Count];
            distances[0] = 0;
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            for (int v = 1; v < graph.Count - 1; v++)
            {
                var changes = 0;
                for (int i = 1; i < graph.Count; i++)
                {
                    foreach (var next in graph[i])
                    {
                        var currentDistance = distances[next.Vertex];
                        var newDistance = distances[i] + next.Weight;
                        if (currentDistance <= newDistance)
                        {
                            continue;
                        }
                        ++changes;
                        distances[next.Vertex] = newDistance;
                    }
                }
                if (changes == 0)
                {
                    break;
                }
            }            

            return distances;
        }

        public static int[] BellmanFord(int[,] graph, int startNode)
        {
            var distances = new int[graph.GetLength(0)];
            distances[0] = 0;
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            for (int v = 1; v < graph.GetLength(0) - 1; v++)
            {
                var changes = 0;
                for (int node = 1; node < graph.GetLength(0); node++)
                {
                    for (int next = 1; next < graph.GetLength(1); next++)
                    {
                        if (graph[node, next] == 0)
                        {
                            continue;
                        }
                        var currentDistance = distances[next];
                        var newDistance = distances[node] + graph[node, next];
                        if (currentDistance <= newDistance)
                        {
                            continue;
                        }
                        ++changes;
                        distances[next] = newDistance;
                    }
                }
                if (changes == 0)
                {
                    break;
                }
            }           

            return distances;
        }

        public static int[] BellmanFordPaths(List<List<Node>> graph, int startNode)
        {
            var paths = new int[graph.Count];
            paths[startNode] = -1;

            var distances = new int[graph.Count];
            distances[0] = 0;
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            for (int i = 1; i < graph.Count; i++)
            {
                foreach (var next in graph[i])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[i] + next.Weight;
                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    paths[next.Vertex] = i;
                    distances[next.Vertex] = newDistance;
                }
            }

            // negative cycle check

            //for (int i = 1; i < graph.Count; i++)
            //{
            //    foreach (var next in graph[i])
            //    {
            //        var currentDistance = distances[next.Vertex];
            //        var newDistance = distances[i] + next.Weight;
            //        if (currentDistance <= newDistance)
            //        {
            //            continue;
            //        }
            //        Console.WriteLine("Negative Cycle");
            //    }
            //}

            return paths;
        }

        public static int[] BellmanFordPaths(int[,] graph, int startNode)
        {
            var paths = new int[graph.GetLength(0)];
            paths[startNode] = -1;

            var distances = new int[graph.GetLength(0)];
            distances[0] = 0;
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            for (int v = 1; v < graph.GetLength(0) - 1; v++)
            {
                var changes = 0;
                for (int node = 1; node < graph.GetLength(0); node++)
                {
                    for (int next = 1; next < graph.GetLength(1); next++)
                    {
                        if (graph[node, next] == 0)
                        {
                            continue;
                        }
                        var currentDistance = distances[next];
                        var newDistance = distances[node] + graph[node, next];
                        if (currentDistance <= newDistance)
                        {
                            continue;
                        }
                        ++changes;
                        paths[next] = node;
                        distances[next] = newDistance;
                    }
                }
                if (changes == 0)
                {
                    break;
                }
            }

            // negative cycle check

            //for (int i = 1; i < graph.Count; i++)
            //{
            //    foreach (var next in graph[i])
            //    {
            //        var currentDistance = distances[next.Vertex];
            //        var newDistance = distances[i] + next.Weight;
            //        if (currentDistance <= newDistance)
            //        {
            //            continue;
            //        }
            //        Console.WriteLine("Negative Cycle");
            //    }
            //}

            return paths;
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

                if (from == 3 && to == 5)
                {
                    continue;
                }

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
                if (from == 3 && to == 5)
                {
                    continue;
                }
                matrix[to, from] = weight;
            }

            return matrix;
        }
    }
}
