using Structures;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public static class Kruskal
    {
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
    }
}
