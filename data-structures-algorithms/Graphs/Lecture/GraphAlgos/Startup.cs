using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphAlgos
{
    class Startup
    {
        private static string input = @"7
8
1 4 5
1 7 3
2 6 2
2 7 8
3 5 10
3 6 8
3 7 9
5 6 1
";

        public static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();

            var graph = GetGraphWithAdjacencyList();
            //var graph = GetGraphWithMatrix();

            var path = DfsGraph(graph, 1);

            Console.WriteLine();

            // trigger DFS from every vertex

            //for (int i = 1; i < graph.Count; i++)
            //{
            //    DfsGraph(graph, i);
            //    Console.WriteLine();
            //}

            // print entire path

            for (int i = 1; i < path.Length; i++)
            {
                Console.WriteLine($"From: {path[i]} To: {i}");
            }

            // Print path to 5
            var current = 5;

            while (current != -1)
            {
                Console.WriteLine(current);
                current = path[current];
            }

            // BFS
            Console.WriteLine("===== BFS =====");

            var pathBfs = BfsGraph(graph, 3);
            Console.WriteLine();

            for (int i = 1; i < pathBfs.Length; i++)
            {
                Console.WriteLine($"From: {pathBfs[i]} To: {i}");
            }

            var currentBfs = 4;

            while (currentBfs != -1)
            {
                Console.WriteLine(currentBfs);
                currentBfs = pathBfs[currentBfs];
            }
        }

        public static int[] BfsGraph(List<List<Node>> graph, int startVertex)
        {
            var used = new bool[graph.Count];
            used[startVertex] = true;

            var path = new int[graph.Count];
            path[startVertex] = -1;

            var depth = new int[graph.Count];
            depth[startVertex] = 0;

            var q = new Queue<int>();
            q.Enqueue(startVertex);

            while (q.Count != 0)
            {
                var vertex = q.Dequeue();

                Console.Write(vertex + " ");

                foreach (var node in graph[vertex])
                {
                    if (used[node.To] == true)
                    {
                        continue;
                    }
                    path[node.To] = vertex;

                    q.Enqueue(node.To);

                    used[node.To] = true;

                    depth[node.To] = depth[vertex] + 1;
                }

            }

            return path;
            //return depth;
        }

        public static int[] BfsGraph(int[,] graph, int startVertex)
        {
            var used = new bool[graph.GetLength(0)];
            used[startVertex] = true;

            var path = new int[graph.GetLength(0)];
            path[startVertex] = -1;

            var depth = new int[graph.GetLength(0)];
            depth[startVertex] = 0;

            var q = new Queue<int>();
            q.Enqueue(startVertex);

            while (q.Count != 0)
            {
                var vertex = q.Dequeue();

                Console.Write(vertex + " ");

                for (int next = 1; next < graph.GetLength(1); next++)
                {
                    if (graph[vertex, next] != 0 && used[next] == false)
                    {
                        path[next] = vertex;
                        q.Enqueue(next);
                        used[next] = true;
                        depth[next] = depth[vertex] + 1;
                    }
                }

            }

            return path;
            //return depth;
        }

        public static int[] DfsGraph(List<List<Node>> graph, int startVertex)
        {
            var used = new bool[graph.Count];
            var vertex = startVertex;
            var path = new int[graph.Count];
            path[vertex] = -1; // mark the root

            Dfs(vertex, used, graph, path);

            return path;
        }

        public static int[] DfsGraph(int[,] graph, int startVertex)
        {
            var used = new bool[graph.GetLength(0)];
            var vertex = startVertex;
            var path = new int[graph.GetLength(0)];
            path[vertex] = -1; // mark the root

            Dfs(vertex, used, graph, path);

            return path;
        }

        public static int[] DfsGraphIterative(List<List<Node>> graph, int startVertex)
        {
            var used = new bool[graph.Count];
            used[startVertex] = true;

            var path = new int[graph.Count];
            path[startVertex] = -1;

            var depth = new int[graph.Count];
            depth[startVertex] = 0;

            var q = new Stack<int>();
            q.Push(startVertex);

            while (q.Count != 0)
            {
                var vertex = q.Pop();

                Console.Write(vertex + " ");

                foreach (var node in graph[vertex])
                {
                    if (used[node.To] == true)
                    {
                        continue;
                    }
                    path[node.To] = vertex;

                    q.Push(node.To);

                    used[node.To] = true;

                    depth[node.To] = depth[vertex] + 1;
                }

            }

            return path;
            //return depth;
        }

        public static int[] DfsGraphIterative(int[,] graph, int startVertex)
        {
            var used = new bool[graph.GetLength(0)];
            used[startVertex] = true;

            var path = new int[graph.GetLength(0)];
            path[startVertex] = -1;

            var depth = new int[graph.GetLength(0)];
            depth[startVertex] = 0;

            var q = new Stack<int>();
            q.Push(startVertex);

            while (q.Count != 0)
            {
                var vertex = q.Pop();

                Console.Write(vertex + " ");

                for (int next = 1; next < graph.GetLength(1); next++)
                {
                    if (graph[vertex, next] != 0 && used[next] == false)
                    {
                        path[next] = vertex;
                        q.Push(next);
                        used[next] = true;
                        depth[next] = depth[vertex] + 1;
                    }
                }

            }

            return path;
            //return depth;
        }

        private static void Dfs(int vertex, bool[] used, List<List<Node>> graph, int[] path)
        {
            used[vertex] = true;
            Console.Write(vertex + " ");


            foreach (var node in graph[vertex].OrderBy(x => x.To))
            {
                if (used[node.To] == true)
                {
                    continue;
                }
                path[node.To] = vertex;
                Dfs(node.To, used, graph, path);
            }

        }

        private static void Dfs(int vertex, bool[] used, int[,] graph, int[] path)
        {
            used[vertex] = true;
            Console.Write(vertex + " ");

            for (int to = 1; to < graph.GetLength(1); to++)
            {
                if (graph[vertex, to] != 0 && used[to] == false)
                {
                    path[to] = vertex;
                    Dfs(to, used, graph, path);
                }
            }
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
                node.To = vertices[1];
                node.Weight = vertices[2];                
                graph[from].Add(node);

                // undirected
                var node2 = new Node();
                node2.To = vertices[0];
                node2.Weight = vertices[2];
                graph[to].Add(node2);
            }

            return graph;
        }

        public class Node
        {
            public int To { get; set; }

            public int Weight { get; set; }
        }

        private static int[,] GetGraphWithMatrix()
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
