using System;

namespace UnionFind
{
    public class UnionFind
    {
        private int[] array;

        public UnionFind(int n)
        {
            array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = -1;
            }
        }

        public int Find(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }
            array[x] = Find(array[x]);
            return array[x];
        }

        public bool Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x == y)
            {
                return false;
            }

            array[x] = y;

            return true;
        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
