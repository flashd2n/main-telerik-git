using System;

namespace Task13
{
    public class DynamicDeque<T>
    {
        private int count;
        private Node<T> head;
        private Node<T> tail;

        public DynamicDeque(int initialCapacity = 4)
        {
            this.count = 0;
            this.head = null;
            this.tail = null;
        }

        public int Count => this.count;

        public void AddBack(T value)
        {
            var newNode = new Node<T>(value);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else if (this.tail == null)
            {
                this.tail = newNode;
                this.tail.Previous = this.head;
                this.head.Next = this.tail;
            }
            else
            {
                var oldTail = this.tail;
                this.tail = newNode;

                oldTail.Next = this.tail;

                this.tail.Previous = oldTail;
            }

            ++this.count;
        }

        public void AddFront(T value)
        {
            var newNode = new Node<T>(value);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else if (this.tail == null)
            {
                var oldHead = this.head;
                this.head = newNode;
                this.tail = oldHead;

                this.head.Next = this.tail;
                this.tail.Previous = this.head;

            }
            else
            {
                var oldHead = this.head;
                this.head = newNode;

                this.head.Next = oldHead;
                oldHead.Previous = this.head;
            }

            ++this.count;
        }

        public T RemoveBack()
        {
            if (this.count == 0)
            {
                throw new Exception("No elements in the deque");
            }

            if (this.count == 1)
            {
                var removedValue = this.head.Value;
                this.head = null;
                this.tail = null;
                this.count = 0;
                return removedValue;
            }
            else
            {
                var removedValue = this.tail.Value;

                var oldTail = this.tail;
                this.tail = oldTail.Previous;

                this.tail.Next = null;
                oldTail.Previous = null;

                --this.count;
                
                return removedValue;
            }
        }

        public T RemoveFront()
        {
            if (this.count == 0)
            {
                throw new Exception("No elements in the deque");
            }

            if (this.count == 1)
            {
                var removedValue = this.head.Value;
                this.head = null;
                this.tail = null;
                this.count = 0;
                return removedValue;
            }
            else
            {
                var removedValue = this.head.Value;

                var oldHead = this.head;
                this.head = oldHead.Next;

                this.head.Previous = null;
                oldHead.Next = null;

                --this.count;

                return removedValue;
            }
        }

        public T PeekBack()
        {
            return this.tail.Value;
        }

        public T PeekFront()
        {
            return this.head.Value;
        }

        public void ClearDeque()
        {
            this.count = 0;
            this.head = null;
            this.tail = null;
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
