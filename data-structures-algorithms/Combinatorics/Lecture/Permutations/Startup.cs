using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class Startup
    {
        static void Main()
        {

            PrintPermutations(3);

        }

        public static void PrintPermutations(int n)
        {
            var permutation = new int[n];

            var used = new bool[n];

            PrintPermutations(0, permutation, used);
        }

        public static void PrintPermutations(int i, int[] permutation, bool[] used)
        {
            var n = permutation.Length;

            if (i == n)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (used[j])
                {
                    continue;
                }

                permutation[i] = j + 1;

                used[j] = true;

                PrintPermutations(i + 1, permutation, used);

                used[j] = false;
            }


        }

    }
}
