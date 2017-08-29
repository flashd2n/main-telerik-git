using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfficientHuffmanCodingSortedInput
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var qOne = new Queue<Node>();
            var qTwo = new Queue<Node>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var occurences = int.Parse(input[1]);
                var value = char.Parse(input[0]);
                qOne.Enqueue(new Node(occurences, value));
            }

            do
            {
                if (qOne.Count == 0 && qTwo.Count == 1)
                {
                    break;
                }

                var nodeA = default(Node);
                var nodeB = default(Node);

                if (qTwo.Count == 0)
                {
                    nodeA = qOne.Dequeue();
                    nodeB = qOne.Dequeue();
                }
                else if (qOne.Count == 0)
                {
                    nodeA = qTwo.Dequeue();
                    nodeB = qTwo.Dequeue();
                }
                else
                {
                    nodeA = GetNode(qOne, qTwo);

                    if (qOne.Count != 0 && qTwo.Count != 0)
                    {
                        nodeB = GetNode(qOne, qTwo);
                    }
                    else if (qOne.Count == 0)
                    {
                        nodeB = qTwo.Dequeue();
                    }
                    else if (qTwo.Count == 0)
                    {
                        nodeB = qOne.Dequeue();
                    }
                }

                var newNode = new Node();
                newNode.Occurences = nodeA.Occurences + nodeB.Occurences;
                newNode.Left = nodeA;
                newNode.Right = nodeB;

                qTwo.Enqueue(newNode);

            } while (true);

            var arr = new Deque<int>();
            
            TraverseHuffman(qTwo.Peek(), arr);

        }

        private static Node GetNode(Queue<Node> qOne, Queue<Node> qTwo)
        {
            var possibleNodeA = qOne.Peek();
            var possibleNodeB = qTwo.Peek();

            if (possibleNodeA.Occurences < possibleNodeB.Occurences)
            {
                return qOne.Dequeue();
            }
            else
            {
                return qTwo.Dequeue();
            }
        }

        private static void TraverseHuffman(Node currentNode, Deque<int> arr)
        {
            if (currentNode.IsLeaf)
            {
                Console.WriteLine($"{currentNode.Value} -> {string.Join("", arr)}");
                arr.PopBack();
                return;
            }

            arr.PushBack(0);
            TraverseHuffman(currentNode.Left, arr);

            arr.PushBack(1);
            TraverseHuffman(currentNode.Right, arr);

            if (arr.Count > 0)
            {
                arr.PopBack();
            }
        }
    }

    class Node
    {
        public Node()
        {

        }

        public Node(int occurences, char value)
        {
            this.Left = null;
            this.Right = null;
            this.Value = value;
            this.Occurences = occurences;
        }

        public char Value { get; set; }
        public int Occurences { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public bool IsLeaf => this.Value != default(char);
    }

    public class Deque<T> : IEnumerable<T>
    {
        private const int DEFAULT_SIZE = 4;
        private T[] buffer;
        private int size;
        private int head;
        private int tail;

        public Deque()
            : this(DEFAULT_SIZE)
        {
        }

        public bool IsEmpty => this.size == 0;
        public T[] Buffer => this.buffer;
        public int Count => this.size;

        public Deque(int initLen)
        {
            this.buffer = new T[initLen];
            this.head = 0;
            this.tail = 0;
            this.size = 0;
        }

        public void PushFront(T item)
        {
            if (this.size == this.buffer.Length)
            {
                this.ResizeBuffer();
            }

            this.head = this.DecrementIndex(this.head);
            this.buffer[this.head] = item;

            ++this.size;
        }

        public void PushBack(T item)
        {
            if (this.size == this.buffer.Length)
            {
                this.ResizeBuffer();
            }

            this.buffer[this.tail] = item;
            this.tail = this.IncrementIndex(this.tail);

            ++this.size;
        }

        public T PopFront()
        {
            this.ValidatePop();
            var returnValue = this.buffer[this.head];
            this.head = this.IncrementIndex(this.head);

            --this.size;

            return returnValue;
        }

        public T PopBack()
        {
            this.ValidatePop();
            this.tail = this.DecrementIndex(this.tail);
            var returnValue = this.buffer[this.tail];

            --this.size;

            return returnValue;
        }

        private void ResizeBuffer()
        {
            var newBufferSize = this.buffer.Length * 2;
            var newBuffer = new T[newBufferSize];

            var index = this.head;

            for (var i = 0; i < this.buffer.Length; i++)
            {
                newBuffer[i] = this.buffer[index];
                index = this.IncrementIndex(index);
            }

            this.buffer = newBuffer;
            this.head = 0;
            this.tail = this.size;
        }

        private int IncrementIndex(int value)
        {
            var index = value + 1;

            if (index >= this.buffer.Length)
            {
                index = 0;
            }

            return index;
        }

        private int DecrementIndex(int value)
        {
            var index = value - 1;

            if (index < 0)
            {
                index = this.buffer.Length - 1;
            }

            return index;
        }

        private void ValidatePop()
        {
            if (this.size == 0)
            {
                throw new Exception("Deque is empty, cannot pop!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var index = this.head;

            for (var i = 0; i < this.size; i++)
            {
                yield return this.buffer[index];
                index = this.IncrementIndex(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.GetEnumerator();
        }
    }
}
