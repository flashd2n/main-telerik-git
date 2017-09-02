namespace FlowerGarden
{
    public class FlowerGarden
    {
        class Flower
        {
            public Flower(int height, int bloom, int wilt)
            {
                this.Height = height;
                this.Bloom = bloom;
                this.Wilt = wilt;
            }

            public int Height { get; set; }
            public int Bloom { get; set; }
            public int Wilt { get; set; }
        }

        public class BinaryHeap<T>
        {
            private const int DEFAULT_SIZE = 4;
            private T[] heap;
            private int count;
            private System.Func<T, T, bool> compareFunc;

            public BinaryHeap(System.Func<T, T, bool> compFunc)
            {
                this.compareFunc = compFunc;
                this.heap = new T[DEFAULT_SIZE];
                this.count = 0;
            }

            public bool IsEmpty
            {
                get { return this.count <= 0; }
            }

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

            private void HeapifyDown(System.Collections.Generic.IList<T> array, int index)
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

            private void SwapElements(System.Collections.Generic.IList<T> array, int first, int second)
            {
                var tmp = array[first];
                array[first] = array[second];
                array[second] = tmp;
            }
        }

        public int[] getOrdering(int[] height, int[] bloom, int[] wilt)
        {
            var q = new BinaryHeap<Flower>((a, b) => a.Height > b.Height);

            for (int i = 0; i < height.Length; i++)
            {
                var flower = new Flower(height[i], bloom[i], wilt[i]);
                q.Enqueue(flower);
            }

            var dp = new System.Collections.Generic.List<Flower>();
            dp.Add(q.Dequeue());

            while (!q.IsEmpty)
            {
                var flower = q.Dequeue();

                var len = dp.Count;

                for (int i = 0; i < len; i++)
                {
                    var currentFlower = dp[i];

                    if (!(flower.Wilt < currentFlower.Bloom || flower.Bloom > currentFlower.Wilt))
                    {
                        dp.Insert(i, flower);
                        break;
                    }

                    if (i == dp.Count - 1)
                    {
                        dp.Add(flower);
                    }

                }
            }

            var result = new int[height.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = dp[i].Height;
            }

            return result;
        }
    }
}
