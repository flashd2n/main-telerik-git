using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    using Node = Tree<int>;

    public class Startup
    {
        static void Main()
        {
            var tree = new Node(5);

            tree.Left = new Node(3);
            tree.Left.Left = new Node(1);
            tree.Left.Right = new Node(2);

            tree.Right = new Node(4);
            tree.Right.Right = new Node(7);
            tree.Right.Right.Left = new Node(8);

            //DFSStack(tree);

            var myHeap = new BinaryHeap<int>((a, b) => a < b);
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var value = rnd.Next(1, 51);
                myHeap.Insert(value);
            }

            Console.WriteLine(string.Join(" ", myHeap.RawHeap));
            Console.WriteLine(myHeap.IsValidMinHeap(1));
            myHeap.RemoveRoot();
            Console.WriteLine(string.Join(" ", myHeap.RawHeap));
            Console.WriteLine(myHeap.IsValidMinHeap(1));

            // Sort with heap

            //var sorted = new int[10];

            //for (int i = 0; i < 10; i++)
            //{
            //    sorted[i] = myHeap.Root;
            //    myHeap.RemoveRoot();
            //}

            //Console.WriteLine(string.Join(" ", sorted));

            var array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = rnd.Next(0, 51);
            }
            Console.WriteLine("BEFORE ARRAY");
            Console.WriteLine(string.Join(" ", array));
            Console.WriteLine(CheckHeap(array, 0));

            MakeHeap(array, (a, b) => a < b);

            Console.WriteLine("AFTER MAKE HEAP");
            Console.WriteLine(CheckHeap(array, 0));

            Console.WriteLine("SORTED");

            var sorted = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                sorted[i] = array[0];
                var el = PopRoot(array, array.Length - 1 - i, (a, b) => a < b);
                array[array.Length - 1 - i] = el;
            }

            Console.WriteLine(string.Join(" ", array));
            //Console.WriteLine(string.Join(" ", sorted));

        }

        public static void DFS(Node root)
        {
            if (root == null)
            {
                return;
            }
            /*Console.WriteLine(root.Value);*/ // 5 3 1 2 4 7 8 -> activates when entering a node
            DFS(root.Left);
            /*Console.WriteLine(root.Value);*/ // 1 3 2 5 4 8 7 -> activates when no more left moves
            DFS(root.Right);
            //Console.WriteLine(root.Value); // 1 2 3 8 7 4 5 -> activaes when no more left or right moves
        }

        public static void DFSStack(Node root)
        {
            var q = new Stack<Node>();
            q.Push(root);

            while (q.Count != 0)
            {
                var node = q.Pop();

                Console.WriteLine(node.Value); // 5 3 1 2 4 7 8 -> activates when entering a node
                                               // goes to the left first, because right is pushed first on the stack
                if (node.Right != null)
                {
                    q.Push(node.Right);
                }

                if (node.Left != null)
                {
                    q.Push(node.Left);
                }
            }
        }

        public static void BFS(Node root)
        {
            var q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                var node = q.Dequeue();

                Console.WriteLine(node.Value); // 5 3 4 1 2 7 8 -> childred are added left to right, so they are traversed left to right

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public static void MakeHeap(int[] array, Func<int, int, bool> compareFunc)
        {
            var firstRoot = (array.Length - 2) / 2;

            for (int i = firstRoot; i >= 0; i--)
            {
                HeapifyDown(array, i, compareFunc);
            }
        }

        public static void HeapifyDown(int[] array, int index, Func<int, int, bool> compareFunc)
        {
            var count = array.Length;
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

        public static void HeapifyDown(int[] array, int index, int count, Func<int, int, bool> compareFunc)
        {
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

        public static int PopRoot(int[] heap, int lastIndex, Func<int, int, bool> compareFunc)
        {
            var result = heap[0];
            SwapElements(heap, 0, lastIndex);
            heap[lastIndex] = -1;

            HeapifyDown(heap, 0, lastIndex, compareFunc);
            return result;
        }

        public static bool CheckHeap<T>(T[] heap, int current)
            where T : IComparable<T>
        {
            var count = heap.Length;
            var left = current * 2 + 1;
            var right = current * 2 + 2;

            if (left >= count)
            {
                return true;
            }

            if (right >= count && heap[current].CompareTo(heap[left]) <= 0)
            {
                return true;
            }

            if (right >= count && heap[current].CompareTo(heap[left]) > 0)
            {
                return false;
            }

            if (heap[current].CompareTo(heap[left]) <= 0 &&
                heap[current].CompareTo(heap[right]) <= 0 &&
                CheckHeap(heap, current * 2 + 1) && CheckHeap(heap, current * 2 + 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static void SwapElements<T>(T[] array, int first, int second)
        {
            var tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }
    }
}
