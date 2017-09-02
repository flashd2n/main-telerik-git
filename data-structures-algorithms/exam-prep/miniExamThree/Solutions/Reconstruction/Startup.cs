using System;
using System.Collections.Generic;

namespace Reconstruction
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var roads = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    roads[i, j] = input[j] - 48;
                }
            }            

            var buildPrices = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    buildPrices[i, j] = input[j] >= 65 && input[j] <= 90 ? input[j] - 65 : input[j] - 71;
                }
            }

            var destrPrices = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    destrPrices[i, j] = input[j] >= 65 && input[j] <= 90 ? input[j] - 65 : input[j] - 71;
                }
            }

            var cost = 0;
            var edges = new List<Edge>();

            // KRUSKAL

            //for (int i = 0; i < roads.GetLength(0) - 1; i++)
            //{
            //    for (int j = i + 1; j < roads.GetLength(1); j++)
            //    {
            //        if (roads[i, j] == 1 && roads[j, i] == 1)
            //        {
            //            var edgeOne = new Edge(i, j);
            //            edgeOne.Weight = -destrPrices[i, j];
            //            edges.Add(edgeOne);
            //            cost += destrPrices[i, j];
            //        }
            //        else
            //        {
            //            var edgeOne = new Edge(i, j);
            //            edgeOne.Weight = buildPrices[i, j];
            //            edges.Add(edgeOne);
            //        }
            //    }
            //}

            //var result = RunKruskalMST(edges, n, cost);

            // PRIM

            for (int i = 0; i < roads.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < roads.GetLength(1); j++)
                {
                    if (roads[i, j] == 1 && roads[j, i] == 1)
                    {
                        var edgeOne = new Edge(i, j);
                        edgeOne.Weight = -destrPrices[i, j];
                        edges.Add(edgeOne);
                        var edgeTwo = new Edge(j, i);
                        edgeTwo.Weight = -destrPrices[i, j];
                        edges.Add(edgeTwo);
                        cost += destrPrices[i, j];
                    }
                    else
                    {
                        var edgeOne = new Edge(i, j);
                        edgeOne.Weight = buildPrices[i, j];
                        edges.Add(edgeOne);
                        var edgeTwo = new Edge(j, i);
                        edgeTwo.Weight = buildPrices[i, j];
                        edges.Add(edgeTwo);
                    }
                }
            }

            var result = RunPrim(edges, 0, cost);

            Console.WriteLine(result);

        }

        public static int RunKruskalMST(List<Edge> graph, int verticesCount, int cost)
        {
            var uf = new UnionFind(verticesCount + 1);


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
                    continue;
                }
                cost += edge.Weight;
                uf.UnionToRoot(edge.From, edge.To);
            }

            return cost;
        }

        public static int RunPrim(List<Edge> graph, int startNode, int cost)
        {
            graph.Sort((a, b) => a.From.CompareTo(b.From));

            var used = new HashSet<int>();

            var queue = new BinaryHeap<Edge>((a, b) => a.Weight < b.Weight);

            used.Add(startNode);

            ModifyQueue(queue, graph, startNode);

            while (!queue.IsEmpty)
            {
                var edge = queue.Dequeue();
                if (used.Contains(edge.To))
                {
                    continue;
                }
                used.Add(edge.To);
                // make calc for mst or whatever
                cost += edge.Weight;

                ModifyQueue(queue, graph, edge.To);
            }

            return cost;
        }

        public static void ModifyQueue(BinaryHeap<Edge> queue, List<Edge> graph, int vertex)
        {
            var start = LowerBound(graph, vertex);
            var end = UpperBound(graph, vertex);

            for (int i = start; i < end; i++)
            {
                queue.Enqueue(graph[i]);
            }
        }

        public static int LowerBound(List<Edge> array, int value)
        {
            return Bound(array, a => a.From < value);
        }

        public static int UpperBound(List<Edge> array, int value)
        {
            return Bound(array, a => a.From <= value);
        }

        private static int Bound(List<Edge> array, Func<Edge, bool> f)
        {
            var left = 0;
            var right = array.Count;

            while (right - left != 0)
            {
                var middle = (left + right) / 2;

                if (f(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }

    public class Edge
    {
        public Edge(int from, int to)
        {
            this.From = from;
            this.To = to;
        }
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }

    public class UnionFind
    {
        private int[] array;

        public UnionFind(int n)
        {
            array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = -1;
            }
        }

        //public int[] Array => this.array;

        public int Find(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }
            x = Find(array[x]);
            return x;
        }

        public int FindAndRoot(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }
            array[x] = Find(array[x]);
            return array[x];
        }

        public bool UnionToRoot(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x == y)
            {
                return false;
            }

            array[x] = y;

            return true;
        }

        public bool UnionToElement(int x, int y)
        {
            var xRoot = Find(x);
            var yRoot = Find(y);

            if (xRoot == yRoot)
            {
                return false;
            }

            array[xRoot] = y;

            return true;
        }
    }

    public class BinaryHeap<T>
    {
        private const int DEFAULT_SIZE = 4;
        private T[] heap;
        private int count;
        private Func<T, T, bool> compareFunc;

        public BinaryHeap(Func<T, T, bool> compFunc)
        {
            this.compareFunc = compFunc;
            this.heap = new T[DEFAULT_SIZE];
            this.count = 0;
        }

        public BinaryHeap(T[] array, Func<T, T, bool> compFunc)
        {
            this.compareFunc = compFunc;

            var firstRoot = (array.Length - 2) / 2;

            for (int i = firstRoot; i >= 0; i--)
            {
                HeapifyDown(array, i);
            }

            this.heap = array;
            this.count = array.Length;
        }

        public bool IsEmpty
        {
            get { return this.count <= 0; }
        }

        public void Enqueue(T value)
        {
            if (this.count == this.heap.Length)
            {
                this.DoubleHeap();
            }

            this.heap[this.count] = value;

            this.HeapifyUp(this.count);

            ++this.count;
        }

        public T Dequeue()
        {
            var root = this.heap[0];

            this.SwapElements(0, this.count - 1);
            this.heap[this.count - 1] = default(T);
            --this.count;

            this.HeapifyDown(0);

            return root;
        }

        private void DoubleHeap()
        {
            var newSize = this.heap.Length * 2;
            var newHeap = new T[newSize];

            for (int i = 0; i < this.heap.Length; i++)
            {
                newHeap[i] = this.heap[i];
            }
            this.heap = newHeap;
        }

        private void HeapifyUp(int startIndex)
        {
            for (int i = startIndex; i > 0; i = (i - 1) / 2)
            {
                var parentIndex = (i - 1) / 2;

                if (this.compareFunc(heap[i], heap[parentIndex]))
                {
                    this.SwapElements(i, parentIndex);
                }
                else
                {
                    return;
                }
            }
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                var left = index * 2 + 1;
                var right = index * 2 + 2;

                if (left >= this.count)
                {
                    break;
                }

                if (right >= this.count)
                {
                    if (this.compareFunc(heap[index], heap[left]))
                    {
                        break;
                    }
                    else
                    {
                        this.SwapElements(index, left);
                        break;
                    }
                }

                var betterChildIndex = this.compareFunc(heap[left], heap[right]) ? left : right;

                if (this.compareFunc(heap[betterChildIndex], heap[index]))
                {
                    this.SwapElements(index, betterChildIndex);
                    index = betterChildIndex;
                    continue;
                }
                break;
            }
        }

        private void HeapifyDown(IList<T> array, int index)
        {
            var count = array.Count;
            while (true)
            {
                var left = index * 2 + 1;
                var right = index * 2 + 2;

                if (left >= count)
                {
                    break;
                }

                if (right >= count)
                {
                    if (compareFunc(array[index], array[left]))
                    {
                        break;
                    }
                    else
                    {
                        SwapElements(array, index, left);
                        break;
                    }
                }

                var betterChildIndex = compareFunc(array[left], array[right]) ? left : right;

                if (compareFunc(array[betterChildIndex], array[index]))
                {
                    SwapElements(array, index, betterChildIndex);
                    index = betterChildIndex;
                    continue;
                }
                break;
            }
        }

        private void SwapElements(int first, int second)
        {
            var tmp = this.heap[first];
            this.heap[first] = this.heap[second];
            this.heap[second] = tmp;
        }

        private void SwapElements(IList<T> array, int first, int second)
        {
            var tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }

        public bool IsValidHeap(int current)
        {
            var left = current * 2 + 1;
            var right = current * 2 + 2;

            if (left >= this.count)
            {
                return true;
            }

            if (right >= this.count && this.compareFunc(this.heap[current], this.heap[left]))
            {
                return true;
            }

            if (right >= this.count && !this.compareFunc(this.heap[current], this.heap[left]))
            {
                return false;
            }

            if (this.compareFunc(this.heap[current], this.heap[left]) &&
                this.compareFunc(this.heap[current], this.heap[right]) &&
                this.IsValidHeap(current * 2 + 1) && this.IsValidHeap(current * 2 + 2))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
