using System;

namespace Lecture
{
    public class BinaryHeap<T>
        where T : IComparable<T>
    {
        private const int DEFAULT_SIZE = 4;
        private T[] heap;
        private int count;
        private Func<T, T, bool> compareFunc;

        public BinaryHeap(Func<T, T, bool> compFunc)
        {
            this.compareFunc = compFunc;
            this.heap = new T[DEFAULT_SIZE];
            heap[0] = default(T);
            this.count = 1;
        }

        public T Root => this.heap[1];
        public T[] RawHeap => this.heap;

        public void Insert(T value)
        {
            if (this.count == this.heap.Length)
            {
                this.DoubleHeap();
            }

            this.heap[this.count] = value;

            this.HeapifyUp(this.count);

            ++this.count;
        }

        public void RemoveRoot()
        {
            // swap root with last element
            this.SwapElements(1, this.count - 1);
            this.heap[this.count - 1] = default(T);
            --this.count;

            // do the same checks
            this.HeapifyDown(1);
        }

        private void DoubleHeap()
        {
            var newSize = this.heap.Length * 2;
            var newHeap = new T[newSize];

            for (int i = 0; i < this.heap.Length; i++)
            {
                newHeap[i] = this.heap[i];
            }
            this.heap = newHeap;
        }

        private void HeapifyUp(int startIndex)
        {
            for (int i = startIndex; i > 1; i /= 2)
            {
                var parentIndex = i / 2;

                if (this.compareFunc(heap[i], heap[parentIndex]))
                {
                    this.SwapElements(i, parentIndex);
                }
                else
                {
                    return;
                }
            }
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                var left = index * 2;
                var right = index * 2 + 1;

                if (left >= this.count)
                {
                    break;
                }

                if (right >= this.count)
                {
                    if (this.compareFunc(heap[index], heap[left]))
                    {
                        break;
                    }
                    else
                    {
                        this.SwapElements(index, left);
                        break;
                    }
                }

                var betterChildIndex = this.compareFunc(heap[left], heap[right]) ? left : right;

                if (this.compareFunc(heap[betterChildIndex], heap[index]))
                {
                    this.SwapElements(index, betterChildIndex);
                    index = betterChildIndex;
                    continue;
                }
                break;
            }
        }

        private void SwapElements(int first, int second)
        {
            var tmp = this.heap[first];
            this.heap[first] = this.heap[second];
            this.heap[second] = tmp;
        }

        public bool IsValidMinHeap(int current)
        {
            var left = current * 2;
            var right = current * 2 + 1;

            if (left >= this.count)
            {
                return true;
            }

            if (right >= this.count && this.heap[current].CompareTo(this.heap[left]) <= 0)
            {
                return true;
            }

            if (right >= this.count && this.heap[current].CompareTo(this.heap[left]) > 0)
            {
                return false;
            }

            if (this.heap[current].CompareTo(this.heap[left]) <= 0 &&
                this.heap[current].CompareTo(this.heap[right]) <= 0 &&
                this.IsValidMinHeap(current * 2) && this.IsValidMinHeap(current * 2 + 1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
