using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var q = new BinaryHeap<Node>((a, b) => a.Occurences < b.Occurences);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var occurences = int.Parse(input[1]);
                var value = char.Parse(input[0]);
                q.Enqueue(new Node(occurences, value));
            }

            while (q.Count > 1)
            {
                var nodeA = q.Dequeue();
                var nodeB = q.Dequeue();

                var newNode = new Node();
                newNode.Occurences = nodeA.Occurences + nodeB.Occurences;
                newNode.Left = nodeA;
                newNode.Right = nodeB;

                q.Enqueue(newNode);
            }

            var arr = new Stack<int>();
            TraverseHuffman(q.Root, arr);

        }

        // NOT WORKING PROPERLY, SEE OTHER HUFFMAN FOR CORRECT SOLUTION -> USE CUSTOM DEQUE
        private static void TraverseHuffman(Node currentNode, Stack<int> arr)
        {
            if (currentNode.IsLeaf)
            {
                Console.WriteLine($"{currentNode.Value} -> {string.Join("", arr)}");
                arr.Pop();
                return;
            }

            arr.Push(0);
            TraverseHuffman(currentNode.Left, arr);

            arr.Push(1);
            TraverseHuffman(currentNode.Right, arr);

            if (arr.Count > 0)
            {
                arr.Pop();
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
}
