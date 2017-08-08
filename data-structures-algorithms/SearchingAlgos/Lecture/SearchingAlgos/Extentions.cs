using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    public static class Extentions
    {
        public static int LinearFindFirst(this int[] array, int value)
        {
            var index = 0;

            foreach (var element in array)
            {
                if (element == value)
                {
                    return index;
                }
                ++index;
            }
            return -1;
        }

        public static int LinearFindFirst(this int[] array, Func<int, bool> f)
        {
            var index = 0;

            foreach (var element in array)
            {
                if (f(element))
                {
                    return index;
                }
                ++index;
            }
            return -1;
        }

        public static int LowerBound(this int[] array, int value)
        {
            return array.Bound(x => x < value);
        }

        public static int UpperBound(this int[] array, int value)
        {
            return array.Bound(x => x <= value);
        }

        private static int Bound(this int[] array, Func<int, bool> f)
        {
            var left = 0;
            var right = array.Length;

            while (right - left != 0)
            {
                var middle = (left + right) / 2;

                if (f(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }

        public static int BinarySearch(this int[] array, int value)
        {
            var left = 0;
            var right = array.Length;

            while (right - left >= 1)
            {
                var middle = (left + right) / 2;

                if (array[middle] == value)
                {
                    return middle;
                }

                if (array[middle] > value)
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }

        public static int BinarySearchRecursive(this int[] array, int value)
        {
            var result = array.BinarySearchRecursive(0, array.Length, value);
            return result;
        }

        public static int BinarySearchRecursive(this int[] array, int start, int end, int value)
        {
            if (end - start <= 1 )
            {
                return -1;
            }

            var middle = (end + start) / 2;

            if (array[middle] == value)
            {
                return middle;
            }

            if (array[middle] > value)
            {
                return array.BinarySearchRecursive(start, middle + 1, value);
            }
            else if (array[middle] < value)
            {
                return array.BinarySearchRecursive(middle, end, value);
            }

            return middle;

        }
    }
}
