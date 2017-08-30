using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubSequence
{
    class Startup
    {
        static void Main()
        {
            var first = "ABCBDAB";
            var second = "BDCABA";

            var dp = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {

                    if (first[i - 1] == second[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }

                }
            }

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int k = 0; k < dp.GetLength(1); k++)
                {
                    Console.Write(dp[i, k] + " ");
                }

                Console.WriteLine();
            }

            BackTrack(first, second, dp, "");
            Console.WriteLine("====");
            BackTrackAll(first, second, dp);
        }

        private static void BackTrackAll(string first, string second, int[,] dp)
        {
            BackTrackAll(first, second, dp, first.Length, second.Length, "");
        }

        private static void BackTrackAll(string first, string second, int[,] dp, int i, int j, string subSequence)
        {
            if (i == 0 || j == 0)
            {
                Console.WriteLine(subSequence);
                return;
            }

            if (first[i - 1] == second[j - 1])
            {
                BackTrackAll(first, second, dp, i - 1, j - 1, first[i - 1] + subSequence);
            }
            else if (dp[i - 1, j] > dp[i, j - 1])
            {
                BackTrackAll(first, second, dp, i - 1, j, subSequence);
            }
            else if (dp[i - 1, j] < dp[i, j - 1])
            {
                BackTrackAll(first, second, dp, i, j - 1, subSequence);
            }
            else
            {
                BackTrackAll(first, second, dp, i - 1, j, subSequence);
                BackTrackAll(first, second, dp, i, j - 1, subSequence);
            }

        }

        public static void BackTrack(string first, string second, int[,] dp, string subSequence)
        {
            var i = first.Length;
            var j = second.Length;

            while (i > 0 && j > 0)
            {
                if (first[i - 1] == second[j - 1])
                {
                    subSequence = first[i - 1] + subSequence;
                    --i;
                    --j;
                }
                else if (dp[i - 1, j] > dp[i, j - 1])
                {
                    --i;
                }
                else
                {
                    --j;
                }
            }

            Console.WriteLine(subSequence);
        }

    }
}
