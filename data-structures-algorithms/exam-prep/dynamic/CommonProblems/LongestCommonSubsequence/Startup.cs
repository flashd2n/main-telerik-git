using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    class Startup
    {
        static void Main()
        {
            var stringA = "abcdaf";
            var stringB = "acbcf";

            var dp = new int[stringB.Length + 1, stringA.Length + 1];

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = 0;
                        continue;
                    }

                    if (j == 0)
                    {
                        dp[i, j] = 0;
                        continue;
                    }

                    var charA = stringA[j - 1];
                    var charB = stringB[i - 1];

                    if (charA == charB)
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                        continue;
                    }

                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);

                }
            }

            var result = dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];

            Console.WriteLine(result);

            var sampleSequence = "";

            var currentRow = dp.GetLength(0) - 1;
            var currentCol = dp.GetLength(1) - 1;

            while (dp[currentRow, currentCol] != 0)
            {
                var charA = stringA[currentCol - 1];
                var charB = stringB[currentRow - 1];

                if (charA == charB)
                {
                    sampleSequence = charA + sampleSequence;
                    --currentRow;
                    --currentCol;
                    continue;
                }

                var tmp = dp[currentRow, currentCol];

                if (dp[currentRow, currentCol - 1] == tmp)
                {
                    --currentCol;
                    continue;
                }

                if (dp[currentRow - 1, currentCol] == tmp)
                {
                    --currentRow;
                    continue;
                }
            }

            Console.WriteLine(sampleSequence);

            // once again can get the total number of sequence or list all sequences by BFS from start

        }
    }
}
