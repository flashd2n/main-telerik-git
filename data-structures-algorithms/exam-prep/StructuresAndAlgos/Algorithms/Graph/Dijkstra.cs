using Structures;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public static class Dijkstra
    {
        public static int[] RunDijkstraAllDistances(List<List<Node>> graph, int startNode)
        {
            var distances = new int[graph.Count];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }
                used.Add(node.Vertex);

                foreach (var next in graph[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Weight;
                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    distances[next.Vertex] = newDistance;
                    queue.Enqueue(new Node(next.Vertex, newDistance));
                }
            }
            return distances;
        }

        public static int[] RunDijkstraAllDistances(int[,] graph, int startNode)
        {
            var distances = new int[graph.GetLength(0)];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }
                used.Add(node.Vertex);

                for (int to = 1; to < graph.GetLength(1); to++)
                {
                    if (graph[node.Vertex, to] == 0)
                    {
                        continue;
                    }

                    var currentDistance = distances[to];
                    var newDistance = distances[node.Vertex] + graph[node.Vertex, to];

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    distances[to] = newDistance;
                    queue.Enqueue(new Node(to, newDistance));


                }
            }
            return distances;
        }

        public static int RunDijkstraDistanceToEnd(List<List<Node>> graph, int startNode, int endNode)
        {
            var distanceToEnd = -1;
            var distances = new int[graph.Count];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }
                if (node.Vertex == endNode)
                {
                    distanceToEnd = distances[node.Vertex];
                    break;
                }
                used.Add(node.Vertex);

                foreach (var next in graph[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Weight;
                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    distances[next.Vertex] = newDistance;
                    queue.Enqueue(new Node(next.Vertex, newDistance));
                }
            }
            return distanceToEnd;
        }

        public static int RunDijkstraDistanceToEnd(int[,] graph, int startNode, int endNode)
        {
            var distanceToEnd = -1;
            var distances = new int[graph.GetLength(0)];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                if (node.Vertex == endNode)
                {
                    distanceToEnd = distances[node.Vertex];
                    break;
                }

                used.Add(node.Vertex);

                for (int to = 1; to < graph.GetLength(1); to++)
                {
                    if (graph[node.Vertex, to] == 0)
                    {
                        continue;
                    }

                    var currentDistance = distances[to];
                    var newDistance = distances[node.Vertex] + graph[node.Vertex, to];

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    distances[to] = newDistance;
                    queue.Enqueue(new Node(to, newDistance));


                }
            }
            return distanceToEnd;
        }

        public static int[] RunDijkstraAllPaths(List<List<Node>> graph, int startNode)
        {
            var path = new int[graph.Count];
            path[startNode] = -1;

            var distances = new int[graph.Count];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                used.Add(node.Vertex);

                foreach (var next in graph[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Weight;

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }

                    path[next.Vertex] = node.Vertex;
                    distances[next.Vertex] = newDistance;
                    queue.Enqueue(new Node(next.Vertex, newDistance));
                }
            }
            return path;
        }

        public static int[] RunDijkstraAllPaths(int[,] graph, int startNode)
        {
            var path = new int[graph.GetLength(0)];
            path[startNode] = -1;

            var distances = new int[graph.GetLength(0)];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                used.Add(node.Vertex);

                for (int to = 1; to < graph.GetLength(1); to++)
                {
                    if (graph[node.Vertex, to] == 0)
                    {
                        continue;
                    }

                    var currentDistance = distances[to];
                    var newDistance = distances[node.Vertex] + graph[node.Vertex, to];

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    path[to] = node.Vertex;
                    distances[to] = newDistance;
                    queue.Enqueue(new Node(to, newDistance));


                }
            }
            return path;
        }

        public static int[] RunDijkstraPathToEnd(List<List<Node>> graph, int startNode, int endNode)
        {
            var path = new int[graph.Count];
            path[startNode] = -1;

            var distances = new int[graph.Count];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                if (node.Vertex == endNode)
                {
                    break;
                }

                used.Add(node.Vertex);

                foreach (var next in graph[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Weight;

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }

                    path[next.Vertex] = node.Vertex;
                    distances[next.Vertex] = newDistance;
                    queue.Enqueue(new Node(next.Vertex, newDistance));
                }
            }

            var pathToDestination = new List<int>();

            var current = endNode;

            while (current != -1)
            {
                pathToDestination.Add(current);
                current = path[current];
            }

            return pathToDestination.ToArray();
        }

        public static int[] RunDijkstraPathToEnd(int[,] graph, int startNode, int endNode)
        {
            var path = new int[graph.GetLength(0)];
            path[startNode] = -1;

            var distances = new int[graph.GetLength(0)];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startNode] = 0;

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Node>((a, b) => a.Weight < b.Weight);
            queue.Enqueue(new Node(startNode, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }

                if (node.Vertex == endNode)
                {
                    break;
                }

                used.Add(node.Vertex);

                for (int to = 1; to < graph.GetLength(1); to++)
                {
                    if (graph[node.Vertex, to] == 0)
                    {
                        continue;
                    }

                    var currentDistance = distances[to];
                    var newDistance = distances[node.Vertex] + graph[node.Vertex, to];

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }
                    path[to] = node.Vertex;
                    distances[to] = newDistance;
                    queue.Enqueue(new Node(to, newDistance));


                }
            }

            var pathToDestination = new List<int>();

            var current = endNode;

            while (current != -1)
            {
                pathToDestination.Add(current);
                current = path[current];
            }

            return pathToDestination.ToArray();
        }
    }
}
