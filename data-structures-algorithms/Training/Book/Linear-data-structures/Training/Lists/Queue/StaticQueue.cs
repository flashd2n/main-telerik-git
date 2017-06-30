using System;

namespace Lists.Queue
{
    public class StaticQueue<T>
    {
        private T[] buffer;
        private int queueSize;
        private int start;
        private int end;

        public StaticQueue(int initialCapacity = 4)
        {
            this.buffer = new T[initialCapacity];
            this.queueSize = 0;
            this.start = 0;
            this.end = -1;
        }

        public void Enqueue(T value)
        {

            if (this.GetNextIndex(this.end) == this.start && this.queueSize != 0)
            {
                this.ResizeBuffer();
            }

            this.buffer[this.GetNextIndex(this.end)] = value;

            this.end = this.GetNextIndex(this.end);

            ++this.queueSize;
        }

        private void ResizeBuffer()
        {
            var currentBufferSize = this.buffer.Length;

            var newBuffer = new T[currentBufferSize * 2];

            for (int i = 0, j = this.start;
                i < this.queueSize;
                ++i, j = this.GetNextIndex(j))
            {
                newBuffer[i] = buffer[j];
            }

            this.start = 0;
            this.end = this.queueSize;
            this.buffer = newBuffer;

        }

        public T Dequeue()
        {
            if (this.queueSize <= 0)
            {
                throw new ArgumentException("Empty Queue, cannot remove");
            }

            var element = this.buffer[this.start];

            this.buffer[this.start] = default(T);

            this.start = this.GetNextIndex(this.start);

            --this.queueSize;

            return element;
        }

        public T Peek()
        {
            return this.buffer[this.end];
        }

        private int GetNextIndex(int index)
        {
            ++index;

            if (index >= this.buffer.Length)
            {
                index = 0;
            }

            return index;
        }
    }
}
