using System;

namespace Algorithms.Searching
{
    public static class BinarySearch
    {
        public static int RunBinarySearch<T>(T[] array, T value)
            where T: IComparable<T>
        {
            var left = 0;
            var right = array.Length;

            while (right - left >= 1)
            {
                var middle = (left + right) / 2;

                if (array[middle].CompareTo(value) == 0)
                {
                    return middle;
                }

                if (array[middle].CompareTo(value) > 0)
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
    }
}
