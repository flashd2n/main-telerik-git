using Structures;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public static class Kruskal
    {
        public static int[] RunKruskal(List<Edge> graph, int verticesCount)
        {
            var uf = new UnionFind(verticesCount + 1);

            // alternative is to sort the list and iterate, not use priority queue
            var queue = new BinaryHeap<Edge>((a, b) => a.Weight < b.Weight);

            graph.ForEach(x => queue.Enqueue(x));

            while (!queue.IsEmpty)
            {
                var edge = queue.Dequeue();

                var fromRoot = uf.Find(edge.From);
                var toRoot = uf.Find(edge.To);

                if (fromRoot == toRoot)
                {
                    // both vertices already belong to the same tree
                    continue;
                }

                if ((fromRoot == edge.From && toRoot == edge.To) || // both vertices are standalone
                    (fromRoot != edge.From && toRoot != edge.To)) // both vertices belong to a tree
                {
                    uf.UnionToElement(edge.From, edge.To);
                }
                else
                {
                    var single = fromRoot == edge.From ? edge.From : edge.To;
                    var attached = fromRoot == edge.From ? edge.To : edge.From;
                    uf.UnionToElement(single, attached);
                }
            }

            return uf.Array;
        }

        public static List<Edge> RunKruskalMST(List<Edge> graph, int verticesCount)
        {
            var uf = new UnionFind(verticesCount + 1);

            var forrest = new List<Edge>();

            // alternative to add priority to particular edge
            //forrest.Add(new Edge() { From = 1, To = 2, Weight = 5 });
            //uf.UnionToRoot(1, 2);

            // alternative is to sort the list and iterate, not use priority queue
            var queue = new BinaryHeap<Edge>((a, b) => a.Weight < b.Weight);

            graph.ForEach(x => queue.Enqueue(x));

            while (!queue.IsEmpty)
            {
                var edge = queue.Dequeue();

                var fromRoot = uf.FindAndRoot(edge.From);
                var toRoot = uf.FindAndRoot(edge.To);

                if (fromRoot == toRoot)
                {
                    // both vertices already belong to the same tree
                    continue;
                }

                //if ((fromRoot == edge.From && toRoot == edge.To) || // both vertices are standalone
                //    (fromRoot != edge.From && toRoot != edge.To)) // both vertices belong to a tree
                //{
                //    uf.UnionToRoot(edge.From, edge.To);
                //}
                //else
                //{
                //    var single = fromRoot == edge.From ? edge.From : edge.To;
                //    var attached = fromRoot == edge.From ? edge.To : edge.From;
                //    uf.UnionToRoot(single, attached);
                //}

                forrest.Add(edge);
                uf.UnionToRoot(edge.From, edge.To);
            }

            return forrest;
        }
    }
}
