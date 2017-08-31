using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestNonDecreasingSequence
{
    class Startup
    {
        static void Main()
        {
            var sequence = new int[] { 5, 3, 4, 8, 6, 7 };
            var dp = new int[sequence.Length];

            for (int i = 0; i < sequence.Length; i++)
            {
                var couter = 1;

                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] > sequence[i])
                    {
                        continue;
                    }

                    if (dp[i] == 0 || (dp[j] + 1) > dp[i])
                    {
                        couter = dp[j] + 1;
                    }
                }
                dp[i] = couter;
            }


        }
    }
}
