using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class Startup
    {
        static void Main()
        {
            var avl = new AVL<int>();
            avl.Add(10);
            avl.Add(5);
            avl.Add(15);
            avl.Add(13);
            avl.Add(20);
            avl.Add(12);

            DFS(avl.Root);
        }

        private static void DFS(AVL<int>.Node<int> root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine($"{root.Value} -> BF: {root.BalanceFactor}");
            DFS(root.Left);
            DFS(root.Right);
        }
    }
}
