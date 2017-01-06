using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtension
{
    public static class IEnumerableTask
    {
        // Sum 
        public static T SumExtension<T>(this IEnumerable<T> array)
        {
            if (array.Count() == 0)
            {
                throw new NullReferenceException("The given array is empty!");
            }
            else
            {
                dynamic sum = 0;

                foreach (var element in array)
                {
                    sum += element;
                }

                return sum;
            }
        }

        // Product
        public static T ProductExtension<T>(this IEnumerable<T> array)
        {
            if (array.Count() == 0)
            {
                throw new NullReferenceException("The given array is empty!");
            }
            else
            {
                dynamic product = 1;

                foreach (var element in array)
                {
                    product *= element;
                }

                return product;
            }
        }

        // Min
        public static T MinExtension<T>(this IEnumerable<T> array)
        {
            if (array.Count() == 0)
            {
                throw new NullReferenceException("The given array is empty!");
            }
            else
            {
                dynamic min = array.First();

                foreach (var element in array)
                {
                    if (min > element)
                    {
                        min = element;
                    }
                }

                return min;
            }
        }

        // Max
        public static T MaxExtension<T>(this IEnumerable<T> array)
        {
            if (array.Count() == 0)
            {
                throw new NullReferenceException("The given array is empty!");
            }
            else
            {
                dynamic max = array.First();

                foreach (var element in array)
                {
                    if (max < element)
                    {
                        max = element;
                    }
                }

                return max;
            }
        }

        // Average
        public static T AverageExtension<T>(this IEnumerable<T> array)
        {
            if (array.Count() == 0)
            {
                throw new NullReferenceException("The given array is empty!");
            }
            else
            {
                dynamic sum = 0;

                foreach (var element in array)
                {
                    sum += element;
                }

                return sum / array.Count();
            }
        }
    }
}