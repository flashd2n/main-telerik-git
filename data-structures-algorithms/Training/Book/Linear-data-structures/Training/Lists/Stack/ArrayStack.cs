using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists.Stack
{
    public class ArrayStack<T>
    {
        private T[] buffer;
        private int count;
        
        public ArrayStack(int initialCapacity = 4)
        {
            this.buffer = new T[initialCapacity];
            this.count = 0;
        }

        public int Count => this.count;
        private int BufferSize => this.buffer.Length;
        private int StackTop => this.count - 1;

        public void Push(T value)
        {
            this.ResizeIfNeeded();

            this.buffer[this.count] = value;

            ++count;        
        }


        public T Pop()
        {
            var element = this.buffer[StackTop];

            this.buffer[StackTop] = default(T);

            --count;

            return element;
        }

        public T Peek()
        {
            if (this.StackTop < 0)
            {
                throw new ArgumentException("Empty Stack");
            }

            return this.buffer[this.StackTop];
        }

        private void ResizeIfNeeded()
        {
            if (this.count >= this.BufferSize)
            {

                var newBuffer = new T[this.BufferSize * 2];

                for (int i = 0; i < this.BufferSize; i++)
                {
                    newBuffer[i] = this.buffer[i];
                }

                this.buffer = newBuffer;

            }
        }
    }
}
