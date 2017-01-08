using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtentions
{
    public static class IEnumerableExtentions
    {
        public static T CalcSum<T>(this IEnumerable<T> collection)
        {
            dynamic result = 0;

            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static T CalcProduct<T>(this IEnumerable<T> collection)
        {
            dynamic result = 1;

            foreach (var item in collection)
            {
                result *= (dynamic)item;
            }
            return result;
        }

        public static T GetAverage<T>(this IEnumerable<T> collection)
        {
            dynamic result = 0;

            foreach (var item in collection)
            {
                result += item;
            }

            return (result / collection.Count());

        }

        public static T GetMin<T>(this IEnumerable<T> collection)
        {
            dynamic min = collection.ElementAt(0);

            foreach (var item in collection)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static T GetMax<T>(this IEnumerable<T> collection)
        {
            dynamic max = collection.ElementAt(0);

            foreach (var item in collection)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

    }
}
