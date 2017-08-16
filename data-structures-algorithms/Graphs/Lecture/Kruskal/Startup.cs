using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Startup
    {
        private static string input = @"7
9
A B 2
A C 3
A D 11
B C 3
B E 15
C D 2
C E 6
D E 3
F Z 2
";

        public static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();
            var dict = new Dictionary<int, string>();

            var graph = GetGraphWithSetOfEdges(dict);

            var forrest = RunKruskal(graph, 7);

            var result = new string[forrest.Length];

            for (int i = 1; i < result.Length; i++)
            {
                if (forrest[i] == -1)
                {
                    Console.WriteLine($"{dict[i]} -> Root");
                    continue;
                }
                result[i] = dict[forrest[i]];
                Console.WriteLine($"{dict[i]} -> {dict[forrest[i]]}");
            }            
        }

        public static int[] RunKruskal(List<Edge> graph, int verticesCount)
        {
            var uf = new UnionFind(verticesCount + 1);

            var queue = new BinaryHeap<Edge>((a, b) => a.Weight < b.Weight);

            graph.ForEach(x => queue.Enqueue(x));            

            while (!queue.IsEmpty)
            {
                var edge = queue.Dequeue();

                var fromRoot = uf.Find(edge.From);
                var toRoot = uf.Find(edge.To);

                if (fromRoot == toRoot)
                {
                    continue;
                }

                if ((fromRoot == edge.From && toRoot == edge.To) ||
                    (fromRoot != edge.From && toRoot != edge.To))
                {
                    uf.UnionToElement(edge.From, edge.To);
                }
                else
                {
                    var detached = fromRoot == edge.From ? edge.From : edge.To;
                    var attached = fromRoot == edge.From ? edge.To : edge.From;
                    uf.UnionToElement(detached, attached);
                }
            }

            return uf.Array;
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
    }
}
