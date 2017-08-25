using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeTwo
{
    class Startup
    {
        static void Main()
        {
            var allRows = int.Parse(Console.ReadLine());
            var allCols = int.Parse(Console.ReadLine());
            var verticesCount = allRows * allCols;

            var matrix = ReadMatrix(allRows, allCols);

            double damage = RunDijkstra(allRows, allCols, matrix);

            damage = Math.Abs(matrix[0, 0]) + Math.Abs(matrix[allRows - 1, allCols - 1]) + damage;

            Console.WriteLine("{0:f2}", damage);
        }

        private static double RunDijkstra(int allRows, int allCols, double[,] matrix)
        {
            var verticesCount = allRows * allCols;

            var distances = new double[verticesCount + 1];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = double.MaxValue;
            }
            distances[1] = 0;

            var used = new HashSet<int>();
            var queue = new BinaryHeap<Node>((a, b) => a.EdgeWeight < b.EdgeWeight);
            queue.Enqueue(new Node(1, 0));

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (used.Contains(node.Vertex))
                {
                    continue;
                }
                if (node.Vertex == verticesCount)
                {
                    break;
                }
                used.Add(node.Vertex);

                // get coords

                var coords = GetCoords(node.Vertex, allCols);
                var currentRow = coords[0];
                var currentCol = coords[1];
                // traverse neightbours

                // right
                var newRow = currentRow;
                var newCol = currentCol + 1;
                if (CheckPath(newRow, newCol, matrix))
                {
                    RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);                    
                }

                newRow = currentRow;
                newCol = currentCol - 1;
                // left
                if (CheckPath(newRow, newCol, matrix))
                {
                    RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);
                }

                newRow = currentRow + 1;
                newCol = currentCol;
                // down
                if (CheckPath(newRow, newCol, matrix))
                {
                    RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);
                }

                newRow = currentRow - 1;
                newCol = currentCol;
                // up
                if (CheckPath(newRow, newCol, matrix))
                {
                    RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);
                }

                // if current row % 2 == 0 -> up left + down left
                if (currentRow % 2 == 0)
                {
                    newRow = currentRow - 1;
                    newCol = currentCol - 1;
                    if (CheckPath(newRow, newCol, matrix))
                    {
                        RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);
                    }

                    newRow = currentRow + 1;
                    newCol = currentCol - 1;
                    if (CheckPath(newRow, newCol, matrix))
                    {
                        RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);
                    }
                }
                else
                {
                    // if current row % 2 == 1 -> up right + down right
                    newRow = currentRow - 1;
                    newCol = currentCol + 1;
                    if (CheckPath(newRow, newCol, matrix))
                    {
                        RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);
                    }

                    newRow = currentRow + 1;
                    newCol = currentCol + 1;
                    if (CheckPath(newRow, newCol, matrix))
                    {
                        RunMagic(queue, distances, matrix, currentRow, currentCol, newRow, newCol, allCols, node.Vertex);
                    }
                }               
                
            }

            return distances[verticesCount];
        }

        private static void RunMagic(BinaryHeap<Node> queue, double[] distances, double[,] matrix, int currentRow, int currentCol, int newRow, int newCol, int allCols, int nodeVertex)
        {
            var vertex = GetVertex(newRow, newCol, allCols);
            var currentDistance = distances[vertex];
            var heigthFrom = matrix[currentRow, currentCol];
            var heightTo = matrix[newRow, newCol];
            var newDistance = GetNewDistance(heigthFrom, heightTo, distances[nodeVertex]);
            if (currentDistance > newDistance)
            {
                distances[vertex] = newDistance;
                queue.Enqueue(new Node(vertex, newDistance));
            }
        }

        private static double GetNewDistance(double heigthFrom, double heightTo, double parent)
        {
            var weight = Math.Abs(heigthFrom - heightTo);
            return parent + weight;
        }

        private static int GetVertex(int currentRow, int currentCol, int allCols)
        {
            return (allCols * currentRow) + currentCol + 1;
        }

        private static bool CheckPath(int row, int col, double[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }

            if (col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static int[] GetCoords(int vertex, int allCols)
        {
            var result = new int[2];

            var col = (vertex % allCols) - 1;
            if (col < 0)
            {
                col += allCols;
            }

            var row = (vertex - col - 1) / allCols;

            result[0] = row;
            result[1] = col;

            return result;
        }

        private static double[,] ReadMatrix(int allRows, int allCols)
        {
            var result = new double[allRows, allCols];

            for (int i = 0; i < allRows; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                for (int j = 0; j < allCols; j++)
                {
                    result[i, j] = input[j];
                }
            }

            return result;
        }
    }

    public class Node
    {
        public Node(int to, double weight)
        {
            this.Vertex = to;
            this.EdgeWeight = weight;
        }

        public int Vertex { get; set; }
        public double EdgeWeight { get; set; }
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
    }
}
