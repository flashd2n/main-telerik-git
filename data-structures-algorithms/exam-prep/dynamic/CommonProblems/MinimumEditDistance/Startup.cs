using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{
    class Startup
    {
        static void Main()
        {
            var stringA = "abcdef";
            var stringB = "azced";

            var dp = new int[stringB.Length + 1, stringA.Length + 1];

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                        continue;
                    }

                    if (j == 0)
                    {
                        dp[i, j] = i;
                        continue;
                    }

                    var charA = stringA[j - 1];
                    var charB = stringB[i - 1];

                    if (charA == charB)
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                        continue;
                    }

                    dp[i, j] = 1 + GetMin(dp[i, j - 1], dp[i - 1, j - 1], dp[i - 1, j]);

                }
            }

            var result = dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
            Console.WriteLine(result);

            // get sample split count per operations
            var edits = 0;
            var deletes = 0;
            var adds = 0;

            var currentRow = dp.GetLength(0) - 1;
            var currentCol = dp.GetLength(1) - 1;

            while (dp[currentRow, currentCol] != 0)
            {
                var charA = stringA[currentCol - 1];
                var charB = stringB[currentRow - 1];

                if (charA == charB)
                {
                    --currentRow;
                    --currentCol;
                    continue;
                }

                var tmp = dp[currentRow, currentCol] - 1;
                if (dp[currentRow - 1, currentCol - 1] == tmp)
                {
                    ++edits;
                    --currentRow;
                    --currentCol;
                    continue;
                }
                if (dp[currentRow, currentCol - 1] == tmp)
                {
                    ++deletes;
                    --currentCol;
                    continue;
                }
                ++adds;
                --currentRow;

            }

            Console.WriteLine($"Edits: {edits}");
            Console.WriteLine($"Deletes: {deletes}");
            Console.WriteLine($"Adds: {adds}");

            // Can get all possible combinations if I make BFS from the start cell

        }

        private static int GetMin(int v1, int v2, int v3)
        {
            var tmp = Math.Min(v1, v2);
            return Math.Min(tmp, v3);
        }
    }
}
