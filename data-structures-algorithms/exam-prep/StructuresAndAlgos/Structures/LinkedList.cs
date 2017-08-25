using System;
using System.Collections;
using System.Collections.Generic;

namespace Structures
{
    public class LinkedList<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private int count;
        private LLNode<T> head;
        private LLNode<T> tail;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public bool IsEmpty
        {
            get { return this.count == 0; }
        }
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
        public LLNode<T> Head
        {
            get { return this.head; }
            set { this.head = value; }
        }
        public LLNode<T> Tail
        {
            get { return this.tail; }
            set { this.tail = value; }
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index is outside linked list range");
                }
                return this.GetNode(index).Value;
            }
            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index is outside linked list range");
                }

                var oldNode = this.GetNode(index);
                oldNode.Value = value;            
            }
        }        

        public void AddFront(T value)
        {
            var node = new LLNode<T>(value);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
                ++this.count;
                return;
            }

            node.Next = this.head;
            this.head.Previous = node;
            this.head = node;
            ++this.count;
        }

        public void AddBack(T value)
        {
            var node = new LLNode<T>(value);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
                ++this.count;
                return;
            }

            node.Previous = this.tail;
            this.tail.Next = node;
            this.tail = node;
            ++this.count;
        }

        public void InsertNodeAt(int index, T value)
        {
            if (index >= this.count || index < 0)
            {
                throw new IndexOutOfRangeException("Index is outside linked list range");
            }

            var node = new LLNode<T>(value);

            this.InsertNodeAt(index, node);
        }

        public void InsertNodeAt(int index, LLNode<T> node)
        {
            if (index >= this.count || index < 0)
            {
                throw new IndexOutOfRangeException("Index is outside linked list range");
            }
            if (index == 0)
            {
                this.AddFront(node.Value);
                return;
            }

            if (index == this.count - 1)
            {
                this.AddBack(node.Value);
                return;
            }

            var previousNode = this.GetNodeAt(index - 1);
            var nextNode = this.GetNodeAt(index);

            node.Previous = previousNode;
            node.Next = nextNode;

            previousNode.Next = node;
            nextNode.Previous = node;
            ++this.count;
        }

        public LLNode<T> GetNodeAt(int index)
        {
            return this.GetNode(index);
        }

        public LLNode<T> GetNode(T value)
        {
            var returnNode = this.head;
            var nextNode = default(LLNode<T>);

            for (int i = 0; i < this.count; i++)
            {
                if (returnNode.Value.CompareTo(value) == 0)
                {
                    return returnNode;
                }
                nextNode = returnNode.Next;
                returnNode = nextNode;
            }

            return null;
        }

        public void Remove(T value)
        {
            var index = this.IndexOf(value);
            if (index == - 1)
            {
                throw new ArgumentException("No such element in the linked list");
            }
            this.RemoveAt(index);
        }

        public T RemoveAt(int index)
        {
            var returnValue = default(T);

            if (index == 0)
            {
                returnValue = this.head.Value;
                this.head = this.head.Next;
                this.head.Previous = null;
                --this.count;
                return returnValue;
            }

            if (index == this.count - 1)
            {
                returnValue = this.tail.Value;
                this.tail = this.tail.Previous;
                this.tail.Next = null;
                --this.count;
                return returnValue;
            }
            
            var node = this.GetNode(index);
            returnValue = node.Value;

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node = null;
            --this.count;
            return returnValue;
        }

        public int IndexOf(T value)
        {
            var currentNode = this.head;
            var nextNode = default(LLNode<T>);

            if (currentNode.Value.Equals(value))
            {
                return 0;
            }

            for (int i = 1; i < this.count; i++)
            {
                nextNode = currentNode.Next;
                currentNode = nextNode;

                if (currentNode.Value.Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public LinkedList<T> DetachRange(int startInclusive, int endExclusive)
        {
            if (startInclusive < 0 || endExclusive > this.count)
            {
                throw new IndexOutOfRangeException("Provided index is outside linked list range");
            }

            if (startInclusive == 0 && endExclusive == this.count)
            {
                return this;
            }

            if (startInclusive == this.count)
            {
                return null;
            }

            if (endExclusive == 0)
            {
                return null;
            }

            var returnList = new LinkedList<T>();

            if (startInclusive == 0)
            {
                var newHead = this.GetNode(endExclusive);
                returnList.Head = this.head;
                returnList.Tail = this.GetNode(endExclusive - 1);
                returnList.Tail.Next = null;
                returnList.Count = endExclusive - startInclusive;

                this.head = newHead;
                newHead.Previous = null;
                this.count = this.count - returnList.count;

                return returnList;
            }

            if (endExclusive == this.count)
            {
                var newTail = this.GetNode(startInclusive - 1);
                returnList.head = this.GetNode(startInclusive);
                returnList.head.Previous = null;
                returnList.tail = this.tail;
                returnList.count = endExclusive - startInclusive;

                this.tail = newTail;
                this.tail.Next = null;
                this.count = this.count - returnList.count;

                return returnList;
            }
            var nodeOne = this.GetNode(startInclusive - 1);
            var nodeTwo = this.GetNode(endExclusive);

            returnList.head = this.GetNode(startInclusive);
            returnList.head.Previous = null;
            returnList.tail = this.GetNode(endExclusive - 1);
            returnList.tail.Next = null;
            returnList.count = endExclusive - startInclusive;

            nodeOne.Next = nodeTwo;
            nodeTwo.Previous = nodeOne;
            this.count = this.count - returnList.count;

            return returnList;
        }

        public void AttachRange(int position, LinkedList<T> collection)
        {
            if (position < 0 || position > this.count)
            {
                throw new IndexOutOfRangeException("Index is outside linked list range");
            }

            if (position == 0)
            {
                this.head.Previous = collection.tail;
                collection.tail.Next = this.head;
                this.head = collection.head;
                this.count += collection.count;
                return;
            }

            if (position == this.count)
            {
                this.tail.Next = collection.head;
                collection.head.Previous = this.tail;
                this.tail = collection.tail;
                this.count += collection.count;
                return;
            }

            var backNode = this.GetNode(position - 1);
            var frontNode = this.GetNode(position);

            backNode.Next = collection.head;
            collection.head.Previous = backNode;

            frontNode.Previous = collection.tail;
            collection.tail.Next = frontNode;

            this.count += collection.count;
            return;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var returnNode = this.head;

            var tempNextNode = default(LLNode<T>);

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

        private LLNode<T> GetNode(int index)
        {
            var returnNode = this.head;
            var nextNode = default(LLNode<T>);

            for (int i = 0; i < index; i++)
            {
                nextNode = returnNode.Next;
                returnNode = nextNode;
            }

            return returnNode;
        }
    }
}
