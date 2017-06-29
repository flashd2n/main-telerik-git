using Lists.LinkedList;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Lists
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private int count;
        private Node<T> head;
        private Node<T> tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public T this[int index]
        {
            get
            {

                return this.GetNode(index).Value;

            }
            set
            {
                var oldNode = this.GetNode(index);
                var newNode = new Node<T>(value);

                oldNode.Previous.Next = newNode;
                oldNode.Next.Previous = newNode;

            }
        }

        public int Count => this.count;

        public void Add(T value)
        {

            var node = new Node<T>(value);

            if (this.head == null)
            {
                this.head = node;
                ++this.count;
                return;
            }

            if (this.tail == null)
            {
                this.tail = node;

                this.tail.Previous = this.head;
                this.head.Next = this.tail;
                ++this.count;
                return;
            }

            this.tail.Next = node;

            node.Previous = this.tail;

            this.tail = node;

            ++this.count;
        }

        public void RemoveAt(int index)
        {
            var nodeToRemove = this.GetNode(index);

            this.DeleteNode(nodeToRemove);
        }

        public void Remove(T value)
        {
            var nodeToRemove = this.GetNode(value);

            this.DeleteNode(nodeToRemove);
        }

        public int IndexOf(T value)
        {
            return -1;
        }

        private Node<T> GetNode(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new System.Exception("Invalid index");
            }

            var returnNode = this.head;

            var tempNextNode = default(Node<T>);

            for (int i = 0; i < index; i++)
            {
                tempNextNode = returnNode.Next;

                returnNode = tempNextNode;

            }


            return returnNode;
        }

        private Node<T> GetNode(T value)
        {

            var returnNode = this.head;

            if (returnNode.Value.Equals(value))
            {
                return returnNode;
            }

            var tempNextNode = default(Node<T>);

            for (int i = 0; i < this.count; i++)
            {

                tempNextNode = returnNode.Next;

                if (tempNextNode.Value.Equals(value))
                {
                    returnNode = tempNextNode;
                    break;
                }
                else
                {
                    returnNode = tempNextNode;
                }

            }

            if (returnNode.Equals(this.head))
            {
                return default(Node<T>);
            }

            return returnNode;


        }

        private void DeleteNode(Node<T> nodeToRemove)
        {
            if (nodeToRemove.Equals(this.head))
            {
                this.head = nodeToRemove.Next;

            }
            else if (nodeToRemove.Equals(this.tail))
            {
                this.tail = nodeToRemove.Previous;
            }
            else
            {
                nodeToRemove.Previous.Next = nodeToRemove.Next;
                nodeToRemove.Next.Previous = nodeToRemove.Previous;

            }


            --this.count;
        }

        public IEnumerator<T> GetEnumerator()
        {

            var returnNode = this.head;

            var tempNextNode = default(Node<T>);

            for (int i = 0; i < this.count - 1; i++)
            {
                if (i == 0)
                {
                    yield return returnNode.Value;
                }

                tempNextNode = returnNode.Next;

                returnNode = tempNextNode;

                yield return returnNode.Value;
            }



        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.GetEnumerator();
        }
    }
}
