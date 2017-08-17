namespace Structures
{
    public class LLNode<T>
    {
        private T value;
        private LLNode<T> previous;
        private LLNode<T> next;

        public LLNode(T value)
        {
            this.value = value;
            this.previous = null;
            this.next = null;
        }

        public LLNode(T value, LLNode<T> previous, LLNode<T> next)
        {
            this.value = value;
            this.previous = previous;
            this.next = next;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public LLNode<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
        public LLNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }
}
