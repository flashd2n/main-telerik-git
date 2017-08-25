using System;
using System.Collections.Generic;
using System.Linq;

namespace Swapping
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var swaps = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var nodes = new Node[n + 1];

            for (int i = 1; i <= n; i++)
            {
                nodes[i] = new Node(nodes[i - 1], i);
            }

            var leftEnd = nodes[1];
            var rightEnd = nodes[n];

            foreach (var x in swaps)
            {
                var middle = nodes[x];

                var newLeft = middle.right;
                var newRight = middle.left;

                Node.Detach(middle);
                Node.Attach(rightEnd, middle);
                Node.Attach(middle, leftEnd);

                leftEnd = newLeft == null ? middle : newLeft;
                rightEnd = newRight == null ? middle : newRight;
            }

            var output = new int[n];

            for (int i = 0; i < n; i++)
            {
                output[i] = leftEnd.value;
                leftEnd = leftEnd.right;
            }

            Console.WriteLine(string.Join(" ", output));

        }
    }

    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(Node left, int value)
        {
            this.value = value;
            this.left = left;
            this.right = null;

            if (this.left != null)
            {
                this.left.right = this;
            }
        }

        public static void Detach(Node node)
        {
            if (node.left != null)
            {
                node.left.right = null;
            }

            if (node.right != null)
            {
                node.right.left = null;
            }

            node.left = null;
            node.right = null;
        }

        public static void Attach(Node left, Node right)
        {
            if (left == right)
            {
                return;
            }

            left.right = right;
            right.left = left;
        }
    }
}
