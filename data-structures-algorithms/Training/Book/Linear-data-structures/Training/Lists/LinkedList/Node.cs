using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists.LinkedList
{
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

        public T Value => this.value;

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
