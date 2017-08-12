using System;
using System.Collections;
using System.Collections.Generic;

namespace IndexedTrees
{
    public class BinaryIndexedTree<T>
    {
        private Func<T, T, T> combineFunc;
        private T[] tree;
        private readonly int totalLeafCount;

        public BinaryIndexedTree(int valuesCount, Func<T, T, T>combineFunc)
        {
            // ignoring index 0

            this.combineFunc = combineFunc;

            var n = 1;

            while (n < valuesCount)
            {
                n *= 2;
            }

            this.totalLeafCount = n;
            this.tree = new T[n * 2];
        }

        public BinaryIndexedTree(ICollection<T> initial, Func<T, T, T> combineFunc)
        {
            // ignoring index 0

            this.combineFunc = combineFunc;
            var valuesCount = initial.Count;

            var n = 1;

            while (n < valuesCount)
            {
                n *= 2;
            }

            this.totalLeafCount = n;
            this.tree = new T[n * 2];

            var index = 0;
            foreach (var element in initial)
            {
                this[index] = element;
                ++index;
            }

        }

        public T[] RawTree => this.tree;

        public T this[int index]
        {
            get
            {
                var leafIndex = index + this.totalLeafCount;
                return this.tree[leafIndex];
            }

            set
            {
                var leafIndex = index + this.totalLeafCount;
                this.tree[leafIndex] = value;

                while (leafIndex > 1)
                {
                    var parentIndex = leafIndex / 2;
                    var siblingIndex = leafIndex  ^ 1;
                    this.tree[parentIndex] = combineFunc(this.tree[leafIndex], this.tree[siblingIndex]);
                    leafIndex = parentIndex;
                }

            }
        }

        public T GetInterval(int left, int right)
        {
            var initParent = 1;
            var leftRange = 0;
            var rightRange = totalLeafCount;

            var result = this.GetInterval(left, right, initParent, leftRange, rightRange);

            return result;
        }

        private T GetInterval(int left, int right, int parent, int leftRange, int rightRange)
        {
            if (left == leftRange && right == rightRange)
            {
                return this.tree[parent];
            }

            var middle = (leftRange + rightRange) / 2;

            if (right <= middle)
            {
                return GetInterval(left, right, parent * 2, leftRange, middle);
            }

            if (left >= middle)
            {
                return GetInterval(left, right, parent * 2 + 1, middle, rightRange);
            }

            var leftRes = GetInterval(left, middle, parent * 2, leftRange, middle);
            var rightRes = GetInterval(middle, right, parent * 2 + 1, middle, rightRange);

            return combineFunc(leftRes, rightRes);


        }
    }
}
