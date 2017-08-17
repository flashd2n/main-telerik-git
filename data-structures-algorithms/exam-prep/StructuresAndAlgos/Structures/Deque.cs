using System;
using System.Collections;
using System.Collections.Generic;

namespace Structures
{
    public class Deque<T> : IEnumerable<T>
    {
        private const int DEFAULT_SIZE = 4;
        private T[] buffer;
        private int size;
        private int head;
        private int tail;

        public Deque()
            : this(DEFAULT_SIZE)
        {
        }

        public bool IsEmpty => this.size == 0;
        public T[] Buffer => this.buffer;

        public Deque(int initLen)
        {
            this.buffer = new T[initLen];
            this.head = 0;
            this.tail = 0;
            this.size = 0;
        }

        public void PushFront(T item)
        {
            if (this.size == this.buffer.Length)
            {
                this.ResizeBuffer();
            }

            this.head = this.DecrementIndex(this.head);
            this.buffer[this.head] = item;

            ++this.size;
        }

        public void PushBack(T item)
        {
            if (this.size == this.buffer.Length)
            {
                this.ResizeBuffer();
            }

            this.buffer[this.tail] = item;
            this.tail = this.IncrementIndex(this.tail);

            ++this.size;
        }

        public T PopFront()
        {
            this.ValidatePop();
            var returnValue = this.buffer[this.head];
            this.head = this.IncrementIndex(this.head);

            --this.size;

            return returnValue;
        }

        public T PopBack()
        {
            this.ValidatePop();
            this.tail = this.DecrementIndex(this.tail);
            var returnValue = this.buffer[this.tail];

            --this.size;

            return returnValue;
        }

        private void ResizeBuffer()
        {
            var newBufferSize = this.buffer.Length * 2;
            var newBuffer = new T[newBufferSize];

            var index = this.head;

            for (var i = 0; i < this.buffer.Length; i++)
            {
                newBuffer[i] = this.buffer[index];
                index = this.IncrementIndex(index);
            }

            this.buffer = newBuffer;
            this.head = 0;
            this.tail = this.size;
        }

        private int IncrementIndex(int value)
        {
            var index = value + 1;

            if (index >= this.buffer.Length)
            {
                index = 0;
            }

            return index;
        }

        private int DecrementIndex(int value)
        {
            var index = value - 1;

            if (index < 0)
            {
                index = this.buffer.Length - 1;
            }

            return index;
        }

        private void ValidatePop()
        {
            if (this.size == 0)
            {
                throw new Exception("Deque is empty, cannot pop!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var index = this.head;

            for (var i = 0; i < this.size; i++)
            {
                yield return this.buffer[index];
                index = this.IncrementIndex(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.GetEnumerator();
        }
    }
}
