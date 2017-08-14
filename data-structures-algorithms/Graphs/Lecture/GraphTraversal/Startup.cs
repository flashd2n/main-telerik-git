using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraversal
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

            //PrintGraphWithAdjacencyMatrix();
            //PrintGraphWithAdjacencyList();
            PrintGraphWithSetOfEdges();

        }

        public static void PrintGraphWithSetOfEdges()
        {
            var verticesCount = int.Parse(Console.ReadLine());

            var edgesCount = int.Parse(Console.ReadLine());

            // * 2 becuase undirectional
            var graph = new List<Edge>(edgesCount * 2);

            for (int i = 0; i < edgesCount; i++)
            {
                var vertices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var from = vertices[0];
                var to = vertices[1];

                var edge = new Edge();
                edge.From = from;
                edge.To = to;
                edge.Weight = vertices[2];
                graph.Add(edge);

                var edgeTwo = new Edge();
                edgeTwo.From = to;
                edgeTwo.To = from;
                edgeTwo.Weight = vertices[2];
                graph.Add(edgeTwo);
            }

            for (int i = 0; i < graph.Count; i++)
            {
                graph[i].Print();
            }

        }

        public class Edge
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Weight { get; set; }
            public void Print()
            {
                Console.WriteLine($"From: {From} | To: {To} | Weight {Weight}");
            }
        }

        public static void PrintGraphWithAdjacencyList()
        {
            var verticesCount = int.Parse(Console.ReadLine());
            
            var edgesCount = int.Parse(Console.ReadLine());

            var graph = new List<List<Node>>();

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

            PrintAdjacencyList(graph);
        }

        public class Node
        {
            public int To { get; set; }

            public int Weight { get; set; }
        }

        public static void PrintAdjacencyList(List<List<Node>> graph)
        {
            for (int i = 1; i < graph.Count; i++)
            {
                Console.Write(i + " -> ");
                for (int j = 0; j < graph[i].Count; j++)
                {
                    Console.Write($"{graph[i][j].To} | weight {graph[i][j].Weight} || ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintGraphWithAdjacencyMatrix()
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

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
