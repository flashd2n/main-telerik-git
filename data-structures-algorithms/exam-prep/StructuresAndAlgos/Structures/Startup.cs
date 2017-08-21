using System;
using System.IO;
using static Structures.Graph;

namespace Structures
{
    public class Startup
    {
//        private static string input = @"7
//8
//1 4 5
//1 7 3
//2 6 2
//2 7 8
//3 5 10
//3 6 8
//3 7 9
//5 6 1
//";

//        public static void FakeInput()
//        {
//            Console.SetIn(new StringReader(input));
//        }

        static void Main()
        {
            //FakeInput();
            //var n = int.Parse(Console.ReadLine());
            //var m = int.Parse(Console.ReadLine());

            //    var graphBase = new Graph(n, m, GraphType.SetOfEdges);
            //    graphBase.ReadEdges();
            //    var dict = graphBase.Dictionary;

            //    var graph = graphBase.EdgeListGraph;

            //    for (int i = 0; i < graph.Count; i++)
            //    {
            //        var toDeMap = graph[i].From;
            //        var from = dict[toDeMap];
            //        toDeMap = graph[i].To;
            //        var to = dict[toDeMap];
            //        Console.WriteLine($"{from} -> {to}");
            //    }
            //}

            //var graphBase = new Graph(n, m, GraphType.AdjacencyList);
            //graphBase.ReadEdges();
            //var dict = graphBase.Dictionary;
            //var graph = graphBase.AdjListGraph;

            //for (int i = 1; i < graph.Count; i++)
            //{
            //    Console.Write(dict[i] + " -> ");
            //    for (int j = 0; j < graph[i].Count; j++)
            //    {
            //        var vertex = dict[graph[i][j].Vertex];

            //        Console.Write($"{vertex} || ");
            //    }
            //    Console.WriteLine();
            //}

            //var graphBase = new Graph(n, m, GraphType.Matrix);
            //graphBase.ReadEdges();
            //var dict = graphBase.Dictionary;

            //var graph = graphBase.MatrixGraph;

            //Console.WriteLine("RAW GRAPH");

            //for (int i = 1; i < graph.GetLength(0); i++)
            //{
            //    for (int j = 1; j < graph.GetLength(1); j++)
            //    {
            //        Console.Write(graph[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("ACTUAL RELATIONS");

            //for (int i = 1; i < graph.GetLength(0); i++)
            //{
            //    Console.Write($"{dict[i]} -> ");
            //    for (int j = 1; j < graph.GetLength(1); j++)
            //    {
            //        if (graph[i, j] == 0)
            //        {
            //            continue;
            //        }
            //        Console.Write($"{dict[j]}, ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
