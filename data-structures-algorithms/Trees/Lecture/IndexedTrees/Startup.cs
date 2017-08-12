using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexedTrees
{
    class Startup
    {
        static void Main()
        {
            var tree = new BinaryIndexedTree<int>(4, (a, b) => a + b);

            tree[0] = 5;
            tree[1] = 4;
            tree[2] = 2;
            tree[3] = 3;

            Console.WriteLine(string.Join(" ", tree.RawTree));

            //var array = new int[] { 5, 4, 2, 3 };
            //var treeTwo = new BinaryIndexedTree<int>(array, (a, b) => a + b);

            //Console.WriteLine(string.Join(" ", treeTwo.RawTree));

            var result = tree.GetInterval(1, 4);
            Console.WriteLine(result);
        }
    }
}
