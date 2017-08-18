using Structures;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public static class TopologicalSortClass
    {
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
    }
}
