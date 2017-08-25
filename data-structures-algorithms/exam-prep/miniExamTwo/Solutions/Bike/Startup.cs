using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike
{
    class Startup
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var tiles = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    tiles[i, j] = input[j];
                }
            }

            var verticesCount = rows * cols;

            var graph = new Graph(verticesCount);

            var from = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ++from;
                    var tos = GetTos(from, cols, i, j, verticesCount, tiles);
                    foreach (var x in tos)
                    {
                        graph.ReadEdge(from, x.Vertex, x.Weight);
                    }
                }
            }
            double result = Math.Abs(tiles[0, 0]);
            
            result += RunDijkstraDistanceToEnd(graph.AdjListGraph, 1, verticesCount);
            result += Math.Abs(tiles[rows - 1, cols - 1]);

            Console.WriteLine("{0:0.00}", result);
        }

        public static double RunDijkstraDistanceToEnd(List<List<Node>> graph, int startNode, int endNode)
        {
            double distanceToEnd = -1;
            var distances = new double[graph.Count];
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

        public static List<Node> GetTos(int from, int cols, int currentRow, int currentCol, int verticesCount, double[,] tiles)
        {
            var result = new List<Node>();

            var to = from + 1;
            if (currentCol < cols - 1)
            {
                var weight = Math.Abs(tiles[currentRow, currentCol]) - Math.Abs(tiles[currentRow, currentCol + 1]);

                result.Add(new Node(to, Math.Abs(weight)));
            }

            to = from + cols;
            if (to <= verticesCount)
            {                
                var weight = Math.Abs(tiles[currentRow, currentCol]) - Math.Abs(tiles[currentRow + 1, currentCol]);

                result.Add(new Node(to, Math.Abs(weight)));
            }

            to = from + cols - 1;
            if (currentRow % 2 == 0 && currentCol != 0)
            {
                if (to <= verticesCount)
                {
                    var weight = Math.Abs(tiles[currentRow, currentCol]) - Math.Abs(tiles[currentRow + 1, currentCol - 1]);

                    result.Add(new Node(to, Math.Abs(weight)));
                }
            }

            to = from + cols + 1;
            if (currentRow % 2 == 1 && currentCol != cols - 1)
            {
                if (from + cols + 1 <= verticesCount)
                {
                    var weight = Math.Abs(tiles[currentRow, currentCol]) - Math.Abs(tiles[currentRow + 1, currentCol + 1]);

                    result.Add(new Node(to, Math.Abs(weight)));
                }
            }

            return result;
        }
    }
    
    public class Graph
    {

        private readonly int verticesCount;
        private readonly List<List<Node>> adjList;

        public Graph(int vertices)
        {
            this.verticesCount = vertices;

            this.adjList = new List<List<Node>>(vertices + 1);

            for (int i = 0; i < vertices + 1; i++)
            {
                this.adjList.Add(new List<Node>());
            }
        }

        public List<List<Node>> AdjListGraph
        {
            get { return this.adjList; }
        }

        public void ReadEdge(int from, int to, double weight)
        {
            var node = new Node();
            node.Vertex = to;
            node.Weight = weight;
            this.adjList[from].Add(node);

            var node2 = new Node();
            node2.Vertex = from;
            node2.Weight = weight;
            this.adjList[to].Add(node2);
        }
    }

    public class Node
    {
        public Node()
        {

        }

        public Node(int to, double weight)
        {
            this.Vertex = to;
            this.Weight = weight;
        }

        public int Vertex { get; set; }

        public double Weight { get; set; }
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
