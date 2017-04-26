using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    public static class SelectionSortAlgorithmTester
    {
        public static void SelectionSortAlgorithm<T>(T[] array)
            where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                T minElement = array[i];
                int minElementIndex = 0;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minElement) == -1)
                    {
                        minElement = array[j];
                        minElementIndex = j;
                    }
                }

                if (minElement.CompareTo(array[i]) != 0)
                {
                    array[minElementIndex] = array[i];
                    array[i] = minElement;
                }
            }
        }
    }
}
