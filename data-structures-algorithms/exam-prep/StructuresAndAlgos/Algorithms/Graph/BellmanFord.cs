using Structures;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public static class BellmanFord
    {
        public static int[] RunBellmanFord(List<List<Node>> graph, int startNode)
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

        public static int[] RunBellmanFord(int[,] graph, int startNode)
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
    }
}
