using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class AVL<T>
        where T : IComparable<T>
    {
        public class Node<K>
        {
            private K value;
            private Node<K> left;
            private Node<K> right;
            private Node<K> parent;
            private int balanceFactor;

            public Node(K value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
                this.parent = null;
                this.balanceFactor = 0;
            }

            public K Value => this.value;
            public Node<K> Left
            {
                get { return this.left; }
                set { this.left = value; }
            }
            public Node<K> Right
            {
                get { return this.right; }
                set { this.right = value; }
            }
            public Node<K> Parent
            {
                get { return this.parent; }
                set { this.parent = value; }
            }
            public int BalanceFactor
            {
                get { return this.balanceFactor; }
                set { this.balanceFactor = value; }
            }
        }

        private Node<T> root;
        private int count;

        public AVL()
        {
            this.root = null;
            this.count = 0;
        }

        public int Count => this.count;
        public Node<T> Root => this.root;

        public void Add(T value)
        {
            if (this.root == null)
            {
                var node = new Node<T>(value);
                this.root = node;
                return;
            }

            this.attach(value, this.root);
            ++this.count;
        }

        private void attach(T value, Node<T> node)
        {
            if (value.CompareTo(node.Value) <= 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                    node.Left.Parent = node;

                    this.balanceTree(node.Left, node);

                    return;
                }
                this.attach(value, node.Left);
                return;
            }

            if (node.Right == null)
            {
                node.Right = new Node<T>(value);
                node.Right.Parent = node;

                this.balanceTree(node.Right, node);

                return;
            }

            this.attach(value, node.Right);
            return;
        }

        private void balanceTree(Node<T> child, Node<T> parent)
        {
            if (parent == null)
            {
                return;
            }

            if (parent.Left != null && parent.Left == child)
            {
                parent.BalanceFactor += 1;

            }

            if (parent.Right != null && parent.Right == child)
            {
                parent.BalanceFactor -= 1;
            }

            if (parent.BalanceFactor == 0)
            {
                return;
            }

            if (parent.BalanceFactor >= 2)
            {
                if (child.BalanceFactor > 0)
                {
                    this.LeftRotation(child, parent);
                }
                else
                {
                    this.RightRotation(child.Right, child);

                    this.LeftRotation(parent.Left, parent);
                }
                this.resetBalanceFactors(this.root);
                return;
            }

            if (parent.BalanceFactor <= -2)
            {
                if (child.BalanceFactor < 0)
                {
                    this.RightRotation(child, parent);
                }
                else
                {
                    this.LeftRotation(child.Left, child);

                    this.RightRotation(parent.Right, parent);
                }
                this.resetBalanceFactors(this.root);
                return;
            }

            this.balanceTree(parent, parent.Parent);

        }

        private void RightRotation(Node<T> pivot, Node<T> root)
        {
            pivot.Parent = root.Parent;
            root.Parent = pivot;

            if (pivot.Parent != null && pivot.Parent.Left == root)
            {
                pivot.Parent.Left = pivot;
            }
            else if (pivot.Parent != null && pivot.Parent.Right == root)
            {
                pivot.Parent.Right = pivot;
            }
            else
            {
                this.root = pivot;
            }

            root.Right = pivot.Left;
            pivot.Left = root;
        }

        private void LeftRotation(Node<T> pivot, Node<T> root)
        {
            pivot.Parent = root.Parent;
            root.Parent = pivot;

            if (pivot.Parent != null && pivot.Parent.Left == root)
            {
                pivot.Parent.Left = pivot;
            }
            else if (pivot.Parent != null && pivot.Parent.Right == root)
            {
                pivot.Parent.Right = pivot;
            }
            else
            {
                this.root = pivot;
            }

            root.Left = pivot.Right;
            pivot.Right = root;
        }

        private int resetBalanceFactors(Node<T> node)
        {
            var leftDepth = 0;
            var rightDepth = 0;            

            if (node.Left != null)
            {
                leftDepth = this.resetBalanceFactors(node.Left);
            }

            if (node.Right != null)
            {
                rightDepth = this.resetBalanceFactors(node.Right);
            }
            node.BalanceFactor = leftDepth - rightDepth;

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public bool Contains(T value)
        {
            return this.findNode(value, this.root);
        }

        private bool findNode(T value, Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (value.CompareTo(node.Value) == 0)
            {
                return true;
            }
            if (value.CompareTo(node.Value) < 0)
            {
                return this.findNode(value, node.Left);
            }

            return this.findNode(value, node.Right);
        }

        public void Remove(T value)
        {

        }
    }
}
