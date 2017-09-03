using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridges
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];

            var edges = new BinaryHeap<Edge>((a, b) => a.MaxWeight < b.MaxWeight);

            //var edges = new List<Edge>();

            for (int i = 0; i < m; i++)
            {
                var inputTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var edge = new Edge(inputTwo[0], inputTwo[1], inputTwo[2]);

                edges.Enqueue(edge);
            }

            var busWeight = int.Parse(Console.ReadLine());

            var result = RunKruskalMST(edges, n, busWeight);

            Console.WriteLine(result);
        }

        public static int RunKruskalMST(BinaryHeap<Edge> queue, int verticesCount, int busWeight)
        {
            var result = 0;

            var uf = new UnionFind(verticesCount + 1);

            //var queue = new BinaryHeap<Edge>((a, b) => a.MaxWeight < b.MaxWeight);

            //graph.ForEach(x => queue.Enqueue(x));

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

                if (edge.MaxWeight < busWeight)
                {
                    continue;
                }

                uf.UnionToRoot(edge.From, edge.To);
            }

            Array.Sort(uf.Array);

            for (int i = 1; i < uf.Array.Length; i++)
            {
                if (uf.Array[i] == -1)
                {
                    ++result;
                }
                else
                {
                    break;
                }
            }

            return result - 1;
        }
    }

    public class Edge
    {
        public Edge(int from, int to, int weight)
        {
            this.From = from;
            this.To = to;
            this.MaxWeight = weight;
        }

        public int From { get; set; }
        public int To { get; set; }
        public int MaxWeight { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Edge;
            return this.From == other.From && this.To == other.To && this.MaxWeight == other.MaxWeight;
        }

        public override int GetHashCode()
        {
            return this.From.GetHashCode() + this.To.GetHashCode() + this.MaxWeight.GetHashCode();
        }
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

        public int[] Array
        {
            get { return this.array; }
        }

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
