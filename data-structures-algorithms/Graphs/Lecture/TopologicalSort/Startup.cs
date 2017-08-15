using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TopologicalSort
{
    class Startup
    {
        private static string input = @"10
13
A B
A F
B H
D C
D E
D H
D I
E I
G A
G B
G C
I C
J E
";

        public static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();

            var dict = new Dictionary<int, string>();

            var graph = GetGraphWithAdjacencyList(dict);
            var sorted = TopologicalSort(graph);

            var result = new string[sorted.Length];

            for (int i = 0; i < sorted.Length; i++)
            {
                result[i] = dict[sorted[i]];
            }

            Console.WriteLine(string.Join(" ", result));
        }

        public static int[] TopologicalSort(List<List<Node>> graph)
        {
            var used = new HashSet<int>();
            var stack = new Stack<int>();

            for (int i = 1; i < graph.Count; i++)
            {
                if (used.Contains(i))
                {
                    continue;
                }
                used.Add(i);

                TopologicalSort(graph, used, stack, i);
            }

            var result = new int[graph.Count - 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = stack.Pop();
            }

            return result;
        }

        private static void TopologicalSort(List<List<Node>> graph, HashSet<int> used, Stack<int> stack, int currentNode)
        {
            foreach (var next in graph[currentNode])
            {
                if (used.Contains(next.Vertex))
                {
                    continue;
                }
                used.Add(next.Vertex);
                TopologicalSort(graph, used, stack, next.Vertex);
            }
            stack.Push(currentNode);
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
                graph[from].Add(node);
            }

            return graph;
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
                graph[from].Add(node);
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
    }
}
