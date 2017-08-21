using System;

namespace Structures
{
    public class AVL<T>
        where T : IComparable<T>
    {
        private AvlNode<T> root;

        public AVL()
        {
            this.root = null;
        }

        public AvlNode<T> Root => this.root;

        public void Add(T data)
        {
            var newItem = new AvlNode<T>(data);

            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
                root.Parent = null;
            }
        }

        private AvlNode<T> RecursiveInsert(AvlNode<T> current, AvlNode<T> newNode)
        {
            if (current == null)
            {
                current = newNode;
                return current;
            }
            else if (newNode.Data.CompareTo(current.Data) < 0)
            {
                var item = RecursiveInsert(current.Left, newNode);
                item.Parent = current;
                current.Left = item;
                current = balance_tree(current);
            }
            else if (newNode.Data.CompareTo(current.Data) > 0)
            {
                var item = RecursiveInsert(current.Right, newNode);
                item.Parent = current;
                current.Right = item;
                current = balance_tree(current);
            }

            return current;
        }

        private AvlNode<T> balance_tree(AvlNode<T> current)
        {
            int b_factor = balance_factor(current);

            if (b_factor > 1)
            {
                if (balance_factor(current.Left) > 0)
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
                if (balance_factor(current.Right) > 0)
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

        private AvlNode<T> Delete(AvlNode<T> current, T target)
        {
            AvlNode<T> parent;

            if (current == null)
            {
                return null;
            }
            else
            {
                if (target.CompareTo(current.Data) < 0)
                {
                    current.Left = Delete(current.Left, target);

                    if (balance_factor(current) == -2)
                    {
                        if (balance_factor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                else if (target.CompareTo(current.Data) > 0)
                {
                    current.Right = Delete(current.Right, target);

                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.Left) >= 0)
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
                    if (current.Right != null)
                    {
                        parent = current.Right;

                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }

                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent.Data);

                        if (balance_factor(current) == 2)
                        {
                            if (balance_factor(current.Left) >= 0)
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
                        return current.Left;
                    }
                }
            }

            return current;
        }

        public AvlNode<T> Find(T key)
        {
            var foundItem = Find(key, root);
            var foundKey = foundItem.Data;

            if (foundKey.CompareTo(key) == 0)
            {
                return foundItem;
            }
            else
            {
                return null;
            }
        }

        private AvlNode<T> Find(T target, AvlNode<T> current)
        {
            if (target.CompareTo(current.Data) < 0)
            {
                if (current.Left == null)
                {
                    return current;
                }

                return Find(target, current.Left);
            }
            else
            {
                if (target.CompareTo(current.Data) == 0 || current.Right == null)
                {
                    return current;
                }

                return Find(target, current.Right);
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

        private void InOrderDisplayTree(AvlNode<T> current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.Left);
                Console.Write("({0}) ", current.Data);
                InOrderDisplayTree(current.Right);
            }
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int getHeight(AvlNode<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.Left);
                int r = getHeight(current.Right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int balance_factor(AvlNode<T> current)
        {
            int l = getHeight(current.Left);
            int r = getHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }

        private AvlNode<T> RotateRR(AvlNode<T> root)
        {
            AvlNode<T> pivot = root.Right;
            root.Right = pivot.Left;
            if (pivot.Left != null)
            {
                pivot.Left.Parent = root;
            }
            pivot.Left = root;
            root.Parent = pivot;
            return pivot;
        }

        private AvlNode<T> RotateLL(AvlNode<T> root)
        {
            AvlNode<T> pivot = root.Left;
            root.Left = pivot.Right;
            if (pivot.Right != null)
            {
                pivot.Right.Parent = root;
            }
            pivot.Right = root;
            root.Parent = pivot;
            return pivot;
        }

        private AvlNode<T> RotateLR(AvlNode<T> root)
        {
            AvlNode<T> pivot = root.Left;
            root.Left = RotateRR(pivot);
            return RotateLL(root);
        }

        private AvlNode<T> RotateRL(AvlNode<T> root)
        {
            AvlNode<T> pivot = root.Right;
            root.Right = RotateLL(pivot);
            return RotateRR(root);
        }
    }
}
