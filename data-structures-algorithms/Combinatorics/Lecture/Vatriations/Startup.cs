using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vatriations
{
    public class Startup
    {
        static void Main()
        {
            // without repetition -> repetition was done in the recusion traning with vectors example
            PrintVariations(5, 3);

        }

        public static void PrintVariations(int n, int k)
        {
            var variation = new int[k];

            var used = new bool[n];

            PrintVariations(0, variation, used);
        }

        public static void PrintVariations(int i, int[] variation, bool[] used)
        {
            var k = variation.Length;
            var n = used.Length;

            if (i == k)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (used[j])
                {
                    continue;
                }

                variation[i] = j + 1;

                used[j] = true;

                PrintVariations(i + 1, variation, used);

                used[j] = false;
            }


        }

    }
}
