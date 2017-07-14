using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    public class Startup
    {
        static void Main()
        {
            PrintCombinations(5, 3); // without repetition
        }

        public static void PrintCombinations(int n, int k)
        {
            var combination = new int[k];

            PrintCombinations(0, n, combination);
        }

        public static void PrintCombinations(int i, int n, int[] combination)
        {
            var k = combination.Length;

            if (i == k)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            var start = i == 0 ? 1 : combination[i - 1] + 1;

            for (int j = start; j <= n; j++)
            {

                combination[i] = j;

                PrintCombinations(i + 1, n, combination);

            }

        }
    }
}
