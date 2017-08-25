using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    public class BinaryHeap<T>
    {
        private const int DEFAULT_SIZE = 4;
        private T[] heap;
        private int count;
        private Func<T, T, bool> compareFunc;

        public BinaryHeap(Func<T, T, bool> compFunc)
        {
            this.compareFunc = compFunc;
            this.heap = new T[DEFAULT_SIZE];
            this.count = 0;
        }

        public BinaryHeap(T[] array, Func<T, T, bool> compFunc)
        {
            this.compareFunc = compFunc;

            var firstRoot = (array.Length - 2) / 2;

            for (int i = firstRoot; i >= 0; i--)
            {
                HeapifyDown(array, i);
            }

            this.heap = array;
            this.count = array.Length;
        }

        public bool IsEmpty => this.count <= 0;

        public void Enqueue(T value)
        {
            if (this.count == this.heap.Length)
            {
                this.DoubleHeap();
            }

            this.heap[this.count] = value;

            this.HeapifyUp(this.count);

            ++this.count;
        }

        public T Dequeue()
        {
            var root = this.heap[0];

            this.SwapElements(0, this.count - 1);
            this.heap[this.count - 1] = default(T);
            --this.count;

            this.HeapifyDown(0);

            return root;
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
            for (int i = startIndex; i > 0; i = (i - 1) / 2)
            {
                var parentIndex = (i - 1) / 2;

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
                var left = index * 2 + 1;
                var right = index * 2 + 2;

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

        private void HeapifyDown(IList<T> array, int index)
        {
            var count = array.Count;
            while (true)
            {
                var left = index * 2 + 1;
                var right = index * 2 + 2;

                if (left >= count)
                {
                    break;
                }

                if (right >= count)
                {
                    if (compareFunc(array[index], array[left]))
                    {
                        break;
                    }
                    else
                    {
                        SwapElements(array, index, left);
                        break;
                    }
                }

                var betterChildIndex = compareFunc(array[left], array[right]) ? left : right;

                if (compareFunc(array[betterChildIndex], array[index]))
                {
                    SwapElements(array, index, betterChildIndex);
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

        private void SwapElements(IList<T> array, int first, int second)
        {
            var tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }

        public bool IsValidHeap(int current)
        {
            var left = current * 2 + 1;
            var right = current * 2 + 2;

            if (left >= this.count)
            {
                return true;
            }

            if (right >= this.count && this.compareFunc(this.heap[current], this.heap[left]))
            {
                return true;
            }

            if (right >= this.count && !this.compareFunc(this.heap[current], this.heap[left]))
            {
                return false;
            }

            if (this.compareFunc(this.heap[current], this.heap[left]) &&
                this.compareFunc(this.heap[current], this.heap[right]) &&
                this.IsValidHeap(current * 2 + 1) && this.IsValidHeap(current * 2 + 2))
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
