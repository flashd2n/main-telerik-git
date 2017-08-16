using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
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

        public int[] Array => this.array;

        public int Find(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }
            x = Find(array[x]);
            return x;
        }

        public int FindAndRoot(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }
            array[x] = Find(array[x]);
            return array[x];
        }

        public bool UnionToRoot(int x, int y)
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

        public bool UnionToElement(int x, int y)
        {
            var xRoot = Find(x);
            var yRoot = Find(y);

            if (xRoot == yRoot)
            {
                return false;
            }

            array[xRoot] = y;

            return true;
        }
    }
}
