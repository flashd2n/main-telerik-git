using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Prim
{
    class Startup
    {

        private static string input = @"5
8
A B 2
A C 3
A D 11
B C 3
B E 15
C D 2
C E 6
D E 3
";

        public static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();
            var dict = new Dictionary<int, string>();

            //var graph = GetGraphWithSetOfEdges(dict);
            var graph = GetGraphWithAdjacencyList(dict);

            var minSpanTree = RunPrim(graph, 1);

            foreach (var edge in minSpanTree)
            {
                Console.WriteLine($"{dict[edge.From]} -> {dict[edge.To]} ({edge.Weight})");
            }

        }

        public static List<Edge> RunPrim(List<Edge> graph, int startNode)
        {
            graph.Sort((a, b) => a.From.CompareTo(b.From));

            var used = new HashSet<int>();

            var tree = new List<Edge>();

            var queue = new BinaryHeap<Edge>((a, b) => a.Weight < b.Weight);

            used.Add(startNode);

            ModifyQueue(queue, graph, startNode);

            while (!queue.IsEmpty)
            {
                var edge = queue.Dequeue();
                if (used.Contains(edge.To))
                {
                    continue;
                }
                used.Add(edge.To);
                tree.Add(edge);

                ModifyQueue(queue, graph, edge.To);
            }

            return tree;
        }

        public static List<Edge> RunPrim(List<List<Node>> graph, int startNode)
        {
            var used = new HashSet<int>();

            var tree = new List<Edge>();

            var queue = new BinaryHeap<Edge>((a, b) => (a.Weight - a.Priority) < (b.Weight - b.Priority));

            used.Add(startNode);

            ModifyQueue(queue, graph, startNode);

            while (!queue.IsEmpty)
            {
                var edge = queue.Dequeue();
                if (used.Contains(edge.To))
                {
                    continue;
                }
                used.Add(edge.To);
                tree.Add(edge);

                ModifyQueue(queue, graph, edge.To);
            }

            return tree;
        }

        public static List<List<Node>> GetGraphWithAdjacencyList(Dictionary<int, string> dict)
        {
            var verticesCount = int.Parse(Console.ReadLine());

            var edgesCount = int.Parse(Console.ReadLine());

            var graph = new List<List<Node>>(verticesCount + 1);

            for (int i = 0; i < verticesCount + 1; i++)
            {
                graph.Add(new List<Node>());
            }

            var dictCount = 1;

            for (int i = 0; i < edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').ToArray();

                if (!dict.ContainsValue(vertices[0]))
                {
                    dict.Add(dictCount, vertices[0]);
                    ++dictCount;
                }
                if (!dict.ContainsValue(vertices[1]))
                {
                    dict.Add(dictCount, vertices[1]);
                    ++dictCount;
                }

                var from = dict.First(x => x.Value == vertices[0]).Key;
                var to = dict.First(x => x.Value == vertices[1]).Key;

                var node = new Node();
                node.Vertex = to;
                node.Weight = int.Parse(vertices[2]);
                graph[from].Add(node);

                var node2 = new Node();
                node2.Vertex = from;
                node2.Weight = int.Parse(vertices[2]);
                graph[to].Add(node2);
            }

            return graph;
        }

        public class Node
        {
            public int Vertex { get; set; }

            public int Weight { get; set; }
        }

        public static List<Edge> GetGraphWithSetOfEdges(Dictionary<int, string> dict)
        {
            var verticesCount = int.Parse(Console.ReadLine());

            var edgesCount = int.Parse(Console.ReadLine());

            // * 2 becuase undirectional
            var graph = new List<Edge>(edgesCount * 2);

            var dictCount = 1;

            for (int i = 0; i < edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').ToArray();

                if (!dict.ContainsValue(vertices[0]))
                {
                    dict.Add(dictCount, vertices[0]);
                    ++dictCount;
                }
                if (!dict.ContainsValue(vertices[1]))
                {
                    dict.Add(dictCount, vertices[1]);
                    ++dictCount;
                }

                var from = dict.First(x => x.Value == vertices[0]).Key;
                var to = dict.First(x => x.Value == vertices[1]).Key;

                var edge = new Edge();
                edge.From = from;
                edge.To = to;
                edge.Weight = int.Parse(vertices[2]);
                graph.Add(edge);

                var edgeTwo = new Edge();
                edgeTwo.From = to;
                edgeTwo.To = from;
                edgeTwo.Weight = int.Parse(vertices[2]);
                graph.Add(edgeTwo);
            }

            return graph;

        }
        
        public class Edge
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Weight { get; set; }
            public int Priority { get; set; }
        }

        public static void ModifyQueue(BinaryHeap<Edge> queue, List<Edge> graph, int vertex)
        {
            var start = LowerBound(graph, vertex);
            var end = UpperBound(graph, vertex);

            for (int i = start; i < end; i++)
            {
                queue.Enqueue(graph[i]);
            }
        }

        public static void ModifyQueue(BinaryHeap<Edge> queue, List<List<Node>> graph, int vertex)
        {
            foreach (var next in graph[vertex])
            {
                var newEdge = new Edge() { From = vertex, To = next.Vertex, Weight = next.Weight };
                // PRIORITY SET
                //if ((newEdge.From == 1 && newEdge.To == 4) ||
                //    (newEdge.From == 4 && newEdge.To == 1))
                //{
                //    newEdge.Priority = int.MaxValue;
                //}
                queue.Enqueue(newEdge);
            }
        }

        public static int LowerBound(List<Edge> array, int value)
        {
            return Bound(array, a => a.From < value);
        }

        public static int UpperBound(List<Edge> array, int value)
        {
            return Bound(array, a => a.From <= value);
        }

        private static int Bound(List<Edge> array, Func<Edge, bool> f)
        {
            var left = 0;
            var right = array.Count;

            while (right - left != 0)
            {
                var middle = (left + right) / 2;

                if (f(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }
}
