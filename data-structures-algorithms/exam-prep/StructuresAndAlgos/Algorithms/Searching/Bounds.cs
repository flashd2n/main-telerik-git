using System;

namespace Algorithms.Searching
{
    public static class Bounds
    {
        public static int LowerBound<T>(T[] array, T value)
            where T: IComparable<T>
        {
            return Bound(array, x => x.CompareTo(value) < 0);
        }

        public static int UpperBound<T>(T[] array, T value)
            where T: IComparable<T>
        {
            return Bound(array, x => x.CompareTo(value) <= 0);
        }

        private static int Bound<T>(T[] array, Func<T, bool> f)
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
    }
}
