using System;
using System.IO;
using System.Linq;

namespace FloydWarshall
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

            var graph = GetGraphWithMatrix();
            var distances = RunFloydWarshall(graph);
        }

        public static int[,] RunFloydWarshall(int[,] graph)
        {
            var infinity = 99999;
            var distances = new int[graph.GetLength(0), graph.GetLength(1)];

            for (int i = 1; i < graph.GetLength(0); i++)
            {
                for (int j = 1; j < graph.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        distances[i, j] = 0;
                        continue;
                    }

                    if (graph[i, j] == 0)
                    {
                        distances[i, j] = infinity;
                        continue;
                    }

                    distances[i, j] = graph[i, j];
                }
            }

            for (int k = 1; k < graph.GetLength(0); k++)
            {
                for (int i = 1; i < graph.GetLength(0); i++)
                {
                    for (int j = 1; j < graph.GetLength(0); j++)
                    {
                        if (distances[i, j] > distances[i, k] + distances[k, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }

            return distances;
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
                //undirected
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
