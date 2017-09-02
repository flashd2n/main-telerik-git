using System;
using System.Linq;

namespace Apples
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var dp = new int[n, m];
            dp[0, 0] = matrix[0, 0];
            var maxResult = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    var fromUp = i == 0 ? 0 : dp[i - 1, j];
                    var fromLeft = j == 0 ? 0 : dp[i, j - 1];

                    dp[i, j] = matrix[i, j] + Math.Max(fromUp, fromLeft);

                    if (dp[i, j] > maxResult)
                    {
                        maxResult = dp[i, j];
                        
                    }
                }
            }

            Console.WriteLine(maxResult);
            Console.WriteLine(dp[n - 1, m - 1]);
        }
    }
}
