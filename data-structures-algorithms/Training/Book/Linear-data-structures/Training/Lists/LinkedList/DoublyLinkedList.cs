using Lists.LinkedList;

namespace Lists
{
    public class DoublyLinkedList<T>
    {
        private int count;
        private Node<T> head;
        private Node<T> tail;

        public DoublyLinkedList()
        {
            this.count = 0;
        }

        public T this[int index]
        {
            get
            {

                var returnNode = this.head;

                var tempNextNode = default(Node<T>);

                for (int i = 0; i < index; i++)
                {
                    tempNextNode = returnNode.Next;

                    returnNode = tempNextNode;
                    
                }

                return returnNode.Value;

            }
            set
            {

            }
        }

        public int Count => this.count;

        public void Add(T value)
        {

            var node = new Node<T>(value);

            if (this.head == null)
            {
                this.head = node;
                ++this.count;
                return;
            }

            if (this.tail == null)
            {
                this.tail = node;

                this.tail.Previous = this.head;
                this.head.Next = this.tail;
                ++this.count;
                return;
            }

            this.tail.Next = node;

            node.Previous = this.tail;

            this.tail = node;

            ++this.count;
        }

        public void RemoveAt()
        {

        }

        public void Remove()
        {

        }

        public int IndexOf(T value)
        {
            return -1;
        }

    }
}
