using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MovingProblem
{
    class Startup
    {
        static void Main()
        {
            var matrix = new int[50, 50];
            matrix[1, 1] = 1;
            matrix[2, 2] = 1;
            matrix[2, 3] = 1;
            //matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] = 2;

            var memo = new BigInteger[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }

            //Console.WriteLine(CanReach(matrix, memo, 2, 0, 0));

            var result = DP(matrix, matrix.GetLength(0), matrix.GetLength(1));

            Console.WriteLine(result);

            var resultOptm = DPOptimized(matrix, matrix.GetLength(0), matrix.GetLength(1));

            Console.WriteLine(resultOptm);
        }

        public static BigInteger DPOptimized(int[,] matrix, int n, int m)
        {
            var dp = new BigInteger[2, m];
            dp[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    var fromUp = i == 0 ? 0 : dp[(i - 1) % 2, j];
                    var fromLeft = j == 0 ? 0 : dp[i % 2, j - 1];

                    dp[i % 2, j] = matrix[i, j] == 0 ? fromUp + fromLeft : 0;
                }
            }

            return dp[(n - 1) % 2, m - 1];
        }

        public static BigInteger DP(int[,] matrix, int n, int m)
        {
            var dp = new BigInteger[n, m];
            dp[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    if (i == 0)
                    {
                        dp[i, j] = matrix[i, j] == 0 ? dp[i, j - 1] : 0;
                        continue;
                    }

                    if (j == 0)
                    {
                        dp[i, j] = matrix[i, j] == 0 ? dp[i - 1, j] : 0;
                        continue;
                    }

                    dp[i, j] = matrix[i, j] == 0 ? dp[i - 1, j] + dp[i, j - 1] : 0;
                }
            }

            return dp[n - 1, m - 1];
        }

        private static BigInteger CanReach(int[,] matrix, BigInteger[,] memo, int value, int row, int col)
        {
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return 0;
            }

            if (matrix[row, col] == value)
            {
                return 1;
            }

            if (matrix[row, col] == 1)
            {
                return 0;
            }

            if (memo[row, col] == -1)
            {
                var result = CanReach(matrix, memo, value, row + 1, col) + CanReach(matrix, memo, value, row, col + 1);
                memo[row, col] = result;
            }

            return memo[row, col];
        }
    }
}
