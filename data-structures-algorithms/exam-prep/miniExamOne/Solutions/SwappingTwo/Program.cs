using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwappingTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = new Node[n + 1];

            for (int i = 1; i <= n; i++)
            {
                numbers[i] = new Node(numbers[i - 1], i);
            }

            var swaps = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var leftEnd = numbers[1];
            var rightEnd = numbers[n];

            foreach (var x in swaps)
            {
                var middle = numbers[x];

                var newLeft = middle.Right;
                var newRight = middle.Left;

                Node.Detach(middle);
                Node.Attach(rightEnd, middle);
                Node.Attach(middle, leftEnd);

                leftEnd = newLeft == null ? middle : newLeft;
                rightEnd = newRight == null ? middle : newRight;
            }

            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = leftEnd.Value;
                leftEnd = leftEnd.Right;
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }

    class Node
    {
        public Node(Node left, int value)
        {
            this.Value = value;
            this.Left = left;

            if (left != null)
            {
                left.Right = this;
            }
        }

        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public static void Detach(Node node)
        {
            if (node.Left != null)
            {
                node.Left.Right = null;
            }

            if (node.Right != null)
            {
                node.Right.Left = null;
            }

            node.Left = null;
            node.Right = null;
        }

        public static void Attach(Node left, Node right)
        {
            if (left == right)
            {
                return;
            }

            left.Right = right;
            right.Left = left;
        }
    }
}
