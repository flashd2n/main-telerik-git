using System;

namespace GenericClass
{
    class GenericList<T> where T : IComparable<T>
    {
        private T[] array;
        private int capacity;
        private int count;

        public GenericList(int capacity)
        {
            this.array = new T[capacity];
            this.Capacity = capacity;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }
        public T this[int index]
        {
            get
            {
                return this.array[index];
            }
            set
            {
                this.array[index] = value;
            }
        }



        public void Add(T item)
        {
            if (this.Count >= this.Capacity)
            {
                this.Resize();
            }
            this.array[this.Count] = item;
            ++count;
        }
        public void Print()
        {
            Console.WriteLine(string.Join(", ", this.array));
        }
        public void RemoveByIndex(int index)
        {
            if (index > count)
            {
                throw new ArgumentOutOfRangeException("Index is greater than count");
            }

            for (int i = index; i < count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.array[count - 1] = default(T);
            --count;
        }
        public void InsertItem(int index, T item)
        {
            if (index >= capacity)
            {
                throw new ArgumentOutOfRangeException("index is greater than capacity");
            }

            if (count == capacity)
            {
                this.Resize();
            }

            for (int i = count - 1; i >= index; i--)
            {
                this.array[i + 1] = this.array[i];
            }
            this.array[index] = item;
            ++count;
        }
        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                this.array[i] = default(T);
            }
            this.count = 0;
        }
        public int IndexOf(T item)
        {
            int returnIndex = -1;
            for (int i = 0; i < count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    returnIndex = i;
                    return returnIndex;
                }
            }

            return returnIndex;
        }
        protected void Resize()
        {
            capacity *= 2;
            var newArray = new T[capacity];

            for (int i = 0; i < count; i++)
            {
                newArray[i] = this.array[i];
            }
            this.array = newArray;
            newArray = null;
        }

        public override string ToString()
        {
            return string.Format(", ", this.array);
        }

        public T Min()
        {
            if (array.Length == 0)
            {
                throw new Exception("The list is empty");
            }
            else if (array.Length == 1)
            {
                return array[0];
            }
            else
            {
                T minValue = array[0];

                for (int i = 1; i < array.Length; i++)
                {

                    if (minValue.CompareTo(array[i]) > 0)
                    {
                        minValue = array[i];
                    }
                }

                return minValue;
            }
        }

        public T Max()
        {
            if (array.Length == 0)
            {
                throw new Exception("The list is empty");
            }
            else if (array.Length == 1)
            {
                return array[0];
            }
            else
            {
                T maxValue = array[0];

                for (int i = 1; i < array.Length; i++)
                {

                    if (maxValue.CompareTo(array[i]) < 0)
                    {
                        maxValue = array[i];
                    }
                }

                return maxValue;
            }
        }
    }
}
