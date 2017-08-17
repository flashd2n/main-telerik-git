using System;

namespace Structures
{
    public class AVL<T>
        where T : IComparable<T>
    {
        class Node<R>
        {
            public R data;
            public Node<R> left;
            public Node<R> right;
            public Node(R data)
            {
                this.data = data;
            }
        }

        Node<T> root;

        public AVL()
        {
        }

        public void Add(T data)
        {
            var newItem = new Node<T>(data);

            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }

        private Node<T> RecursiveInsert(Node<T> current, Node<T> n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data.CompareTo(current.data) < 0)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n.data.CompareTo(current.data) > 0)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }

            return current;
        }

        private Node<T> balance_tree(Node<T> current)
        {
            int b_factor = balance_factor(current);

            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }

            return current;
        }

        public void Delete(T target)
        {
            root = Delete(root, target);
        }

        private Node<T> Delete(Node<T> current, T target)
        {
            Node<T> parent;

            if (current == null)
            {
                return null;
            }
            else
            {
                if (target.CompareTo(current.data) < 0)
                {
                    current.left = Delete(current.left, target);

                    if (balance_factor(current) == -2)
                    {
                        if (balance_factor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                else if (target.CompareTo(current.data) > 0)
                {
                    current.right = Delete(current.right, target);

                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    if (current.right != null)
                    {
                        parent = current.right;

                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }

                        current.data = parent.data;
                        current.right = Delete(current.right, parent.data);

                        if (balance_factor(current) == 2)
                        {
                            if (balance_factor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else
                            {
                                current = RotateLR(current);
                            }
                        }
                    }
                    else
                    {
                        return current.left;
                    }
                }
            }

            return current;
        }

        public bool Find(T key)
        {
            var foundKey = Find(key, root).data;

            if (foundKey.CompareTo(key) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node<T> Find(T target, Node<T> current)
        {
            if (target.CompareTo(current.data) < 0)
            {
                if (current.left == null)
                {
                    return current;
                }

                return Find(target, current.left);
            }
            else
            {
                if (target.CompareTo(current.data) == 0 || current.right == null)
                {
                    return current;
                }

                return Find(target, current.right);
            }

        }

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            InOrderDisplayTree(root);

            Console.WriteLine();
        }

        private void InOrderDisplayTree(Node<T> current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplayTree(current.right);
            }
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int getHeight(Node<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int balance_factor(Node<T> current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }

        private Node<T> RotateRR(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }

        private Node<T> RotateLL(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        private Node<T> RotateLR(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }

        private Node<T> RotateRL(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}
