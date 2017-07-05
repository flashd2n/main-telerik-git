using System;

namespace Task12
{
    public class Startup
    {
        static void Main()
        {
            var test = new DynamicStack<int>();


            for (int i = 0; i < 100; i++)
            {
                test.Push(i);
            }

            var len = test.Count;

            for (int i = 0; i < len; i++)
            {

                Console.WriteLine(test.Pop() + " ");

            }
        }
    }

    public class DynamicStack<T>
    {
        private DynamicStackNode<T> last;
        private int count;

        public DynamicStack()
        {
            this.count = 0;
            this.last = null;
        }

        public int Count => this.count;

        public void Push(T value)
        {
            var node = new DynamicStackNode<T>(value);

            if (this.last == null)
            {
                this.last = node;

            }
            else
            {
                var oldLast = this.last;

                this.last = node;

                node.Previous = oldLast;
            }

            ++count;

        }

        public T Pop()
        {
            
            if (this.count == 1)
            {
                var returnValue = this.last.Value;

                this.Clear();

                return returnValue;
            }

            var returnedValue = this.last.Value;

            this.last = this.last.Previous;
            
            --count;

            return returnedValue;
        }

        public T Peek()
        {
            return this.last.Value;
        }

        public void Clear()
        {
            this.count = 0;
            this.last = null;
        }

    }

    public class DynamicStackNode<T>
    {
        private T value;
        private DynamicStackNode<T> previous;

        public DynamicStackNode(T value)
        {
            this.value = value;
            this.previous = null;
        }

        public T Value => this.value;
        public DynamicStackNode<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

    }

}
