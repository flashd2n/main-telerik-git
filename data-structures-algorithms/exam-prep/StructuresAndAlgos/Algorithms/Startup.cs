using Algorithms.Graph;
using Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Startup
    {
        private static string input = @"8
11
1 2 5
1 3 1
1 4 5
2 3 1
2 5 5
3 4 2
3 5 6
4 5 3
6 7 1
6 8 2
7 8 7
";
        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main(string[] args)
        {
            FakeInput();

            var edges = ReadEdges();
            var kruskal = Kruskal.RunKruskalMST(edges, 8);

        }

        private static List<Edge> ReadEdges()
        {
            var edges = new List<Edge>();
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var edge1 = new Edge();
                edge1.From = input[0];
                edge1.To = input[1];
                edge1.Weight = input[2];

                var edge2 = new Edge();
                edge2.To = input[0];
                edge2.From = input[1];
                edge2.Weight = input[2];

                edges.Add(edge1);
                edges.Add(edge2);
            }
            return edges;
        }
    }
}
