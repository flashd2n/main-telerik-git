using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public class Tree<T>
    {
        private T value;

        private Tree<T> left;
        private Tree<T> right;

        public Tree(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        public Tree(T value, Tree<T> left, Tree<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaf => left == null & right == null;

        public T Value => this.value;

        public Tree<T> Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public Tree<T> Right
        {
            get { return this.right; }
            set { this.right = value; }
        }
    }
}
