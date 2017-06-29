using System;
using System.Collections.Generic;

namespace Lists
{
    public static class Examples
    {
        public static IList<int> GetPrimes(int start, int end)
        {
            var result = new List<int>();

            for (int i = start; i <= end; i++)
            {

                if (IsPrime(i))
                {
                    result.Add(i);
                }

            }

            return result;

        }

        public static IList<int> Intersect(IList<int> left, IList<int> right)
        {
            var result = new List<int>();

            var length = Math.Min(left.Count, right.Count);

            if (left.Count <= right.Count)
            {
                for (int i = 0; i < length; i++)
                {
                    if (right.Contains(left[i]))
                    {
                        result.Add(left[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (left.Contains(right[i]))
                    {
                        result.Add(right[i]);
                    }
                }
            }

            return result;

        }

        public static IList<int> Union(IList<int> left, IList<int> right)
        {
            var result = new List<int>(left);

            for (int i = 0; i < right.Count; i++)
            {
                if (result.Contains(right[i]))
                {
                    continue;
                }
                result.Add(right[i]);
            }

            return result;
        }


        private static bool IsPrime(int number)
        {
            if (number == 1 || number == 2)
            {
                return true;
            }

            var endRange = Math.Ceiling(Math.Sqrt(number));


            for (int i = 2; i < endRange; i++)
            {

                if (number % i == 0)
                {
                    return false;
                }
                
            }

            return true;
        }

    }
}
