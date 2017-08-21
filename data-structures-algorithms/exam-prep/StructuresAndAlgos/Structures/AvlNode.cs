using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class AvlNode<T>
    {
        public T data;
        private AvlNode<T> left;
        private AvlNode<T> right;
        private AvlNode<T> parent;


        public AvlNode(T data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
            this.parent = null;
        }

        public AvlNode<T> Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public AvlNode<T> Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        public AvlNode<T> Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
    }
}
