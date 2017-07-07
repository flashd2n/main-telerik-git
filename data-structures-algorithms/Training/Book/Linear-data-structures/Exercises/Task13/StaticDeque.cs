using System;

namespace Task13
{
    public class StaticDeque<T>
    {
        private int initialCapacity;
        private T[] buffer;
        private int start;
        private int end;
        private int size;

        public StaticDeque(int initialCapacity = 4)
        {
            this.initialCapacity = initialCapacity;
            this.buffer = new T[this.initialCapacity];
            this.size = 0;
            this.start = 0;
            this.end = 0;
        }

        public int Count => this.size;

        public void AddBack(T value)
        {

            this.ResizeIfNecessary();

            this.buffer[this.end] = value;

            ++this.size;

            if (this.size != this.buffer.Length)
            {
                this.end = this.IncremendIndex(this.end);
            }
            else
            {
                ++this.end;
            }
        }

        public void AddFront(T value)
        {

            this.ResizeIfNecessary();

            this.start = this.DecrementIndex(this.start);

            this.buffer[this.start] = value;

            ++this.size;

        }

        public T RemoveBack()
        {
            if (this.size == 0)
            {
                throw new Exception("Deque is empty, cannot remove");
            }

            this.end = this.DecrementIndex(this.end);

            var returnValue = this.buffer[end];

            this.buffer[end] = default(T);

            --this.size;

            return returnValue;
        }

        public T RemoveFront()
        {
            if (this.size == 0)
            {
                throw new Exception("Deque is empty, cannot remove");
            }

            var returnValue = this.buffer[this.start];

            this.buffer[this.start] = default(T);

            this.start = this.IncremendIndex(this.start);

            --this.size;

            return returnValue;
        }

        public T PeekBack()
        {
            return this.buffer[this.end - 1];
        }

        public T PeekFront()
        {
            return this.buffer[this.start];
        }

        public void Clear()
        {
            this.buffer = new T[this.initialCapacity];
            this.size = 0;
            this.start = 0;
            this.end = 0;
        }

        private int DecrementIndex(int index)
        {
            var result = --index;

            if (result < 0)
            {
                result = this.buffer.Length - 1;
            }

            return result;
        }

        private int IncremendIndex(int index)
        {
            var result = ++index;

            if (result >= this.buffer.Length)
            {
                result = 0;
            }

            return result;
        }

        private void ResizeIfNecessary()
        {
            if (this.size >= this.buffer.Length)
            {
                var newBuffer = new T[this.buffer.Length * 2];

                for (int i = 0, j = this.start; i < size; i++)
                {
                    newBuffer[i] = this.buffer[j];

                    j = this.IncremendIndex(j);
                }

                this.buffer = newBuffer;
                this.start = 0;
                this.end = this.size;
            }
        }
    }
}
