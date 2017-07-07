using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    public class DynamicLinkedList<T> : IEnumerable<T>
        where T : IComparable
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public DynamicLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int Count => this.count;

        public Node<T> Head
        {
            get { return this.head; }
            set { this.head = value; }
        }

        public Node<T> Tail
        {
            get { return this.tail; }
            set { this.tail = value; }
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            if (this.count == 0)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else if (this.count == 1)
            {
                this.tail = newNode;
                this.tail.Previous = this.head;
                this.head.Next = this.tail;
            }
            else
            {
                var oldTail = this.tail;
                this.tail = newNode;
                this.tail.Previous = oldTail;
                oldTail.Next = this.tail;
            }

            ++this.count;
        }

        public void BubbleSort()
        {

            for (int i = 0; i < this.count - 1; i++)
            {
                var currentNode = this.head;

                var tempNextNode = default(Node<T>);

                for (int j = 0; j < this.count - 1; j++)
                {
                    tempNextNode = currentNode.Next;

                    if (currentNode.Value.CompareTo(tempNextNode.Value) > 0)
                    {
                        var temp = currentNode.Value;

                        currentNode.Value = tempNextNode.Value;

                        tempNextNode.Value = temp;

                    }

                    currentNode = tempNextNode;
                }

            }

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

    public class Node<T>
    {
        private T value;
        private Node<T> next;
        private Node<T> previous;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
            this.previous = null;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Node<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Node<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
    }
}
