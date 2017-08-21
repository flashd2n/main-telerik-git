using System.Collections;
using System.Collections.Generic;

namespace HashTables
{
    public class MyHashSet<T> : IEnumerable<T>
    {
        private LinkedList<T>[] buffer;

        public MyHashSet()
        {
            this.buffer = new LinkedList<T>[100];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = new LinkedList<T>();
                this.Count = 0;
            }
        }

        public int Count { get; set; }

        public bool Add(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % this.buffer.Length;

            if (this.Contains(value))
            {
                return false;
            }

            this.buffer[index].AddLast(value);
            ++this.Count;

            return true;
        }

        public bool Contains(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % this.buffer.Length;

            foreach (var item in this.buffer[index])
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % this.buffer.Length;

            if (this.Contains(value))
            {
                this.buffer[index].Remove(value);
                --this.Count;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var list in this.buffer)
            {
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.GetEnumerator();
        }
    }
}
