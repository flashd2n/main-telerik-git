using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    class Startup
    {
        static void Main()
        {
            var array = new int[] { 5, 8, 3, 6, 0, 4, 7, 8, 8, 8 };

            //Console.WriteLine(array.LinearFindFirst(8));
            //Console.WriteLine(array.LinearFindFirst(x => x % 3 == 0));
            Array.Sort(array);
            Console.WriteLine(string.Join(" ", array));
            Console.WriteLine(array.BinarySearch(8));
            Console.WriteLine(array.BinarySearchRecursive(18));
            Console.WriteLine(array.LowerBound(8));
            Console.WriteLine(array.UpperBound(8));
        }
    }
}
