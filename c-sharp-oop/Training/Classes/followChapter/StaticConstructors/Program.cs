using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticConstructors
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(PreCalculated.GetSqrt(254));
        }
    }

    static class PreCalculated
    {
        public const int MaxValue = 1000;

        private static int[] sqrtValues;

        static PreCalculated()
        {
            sqrtValues = new int[MaxValue + 1];
            for (int i = 0; i < sqrtValues.Length; i++)
            {
                sqrtValues[i] = (int)Math.Sqrt(i);
            }
        }

        public static int GetSqrt(int value)
        {
            if (value < 0 || value > MaxValue)
            {
                throw new ArgumentOutOfRangeException(string.Format($"The argument should be in rage [0...{MaxValue}]"));
            }

            return sqrtValues[value];
        }
    }
}
