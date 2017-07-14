using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class ArrayList<T> : IEnumerable<T>
    {
        private const int DefaultInitialCapacity = 4;
        private const int ResizeCoeficient = 2;
        private T[] buffer;
        private int count;

        public ArrayList(int initialCapacity = DefaultInitialCapacity)
        {
            this.buffer = new T[initialCapacity];
            this.count = 0;
        }

        public int Capacity => buffer.Length;
        public int Count => this.count;

        public T this[int index]
        {
            get
            {
                return buffer[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException("Not cool bro");
                }

                buffer[index] = value;
            }
        }

        public void Add(T value)
        {

            this.IncreaseBufferIfNeeded();

            buffer[this.count] = value;
            ++this.count;
        }

        public void Insert(int position, T value)
        {
            if (position < 0 || position > this.count)
            {
                throw new ArgumentOutOfRangeException("Not cool bro");
            }

            if (position == this.Count)
            {
                this.Add(value);
                return;
            }

            this.IncreaseBufferIfNeeded();

            for (int i = this.count; i > position; i--)
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[position] = value;
            ++this.count;

        }

        public void Clear()
        {
            this.buffer = new T[DefaultInitialCapacity];
            this.count = 0;
        }

        public bool Contains(T value)
        {
            if (this.IndexOf(value) != -1)
            {
                return true;
            }

            return false;
        }

        public void Remove(T value)
        {
            var indexToRemove = -1;

            for (int i = 0; i < this.count; i++)
            {
                if (buffer[i].Equals(value))
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove == -1)
            {
                throw new ArgumentException("No such element");
            }

            this.RemoveAt(indexToRemove);

        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= this.count)
            {
                throw new ArgumentException("Not a valid position");
            }

            if (position == this.count - 1)
            {
                this.buffer[position] = default(T);
            }

            for (int i = position; i < this.count - 1; i++)
            {
                this.buffer[i] = buffer[i + 1];
            }

            this.buffer[this.count - 1] = default(T);
            --this.count;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < count; i++)
            {

                if (Object.Equals(this.buffer[i], value))
                {
                    return i;
                }

            }

            return -1;
        }

        private void IncreaseBufferIfNeeded()
        {
            if (this.Count == this.Capacity)
            {

                var newCapacity = this.Capacity * ResizeCoeficient;

                var newBuffer = new T[newCapacity];

                for (int i = 0; i < this.buffer.Length; i++)
                {

                    newBuffer[i] = buffer[i];

                    buffer[i] = default(T);

                }

                this.buffer = newBuffer;
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this.buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
