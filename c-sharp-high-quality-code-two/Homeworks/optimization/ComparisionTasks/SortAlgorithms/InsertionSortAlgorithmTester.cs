using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    public static class InsertionSortAlgorithmTester
    {
        public static void InsertionSortAlgorithm<T>(T[] array)
            where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                T currentElement = array[i];
                int index = i;

                while (index > 0 && currentElement.CompareTo(array[index - 1]) == -1)
                {
                    array[index] = array[index - 1];
                    array[index - 1] = currentElement;
                    index--;
                }
            }
        }
    }
}
