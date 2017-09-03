using System;
using System.Collections.Generic;

namespace CoinChange
{
    class Startup
    {
        static void Main()
        {
            var targetSum = 11;
            var coins = new int[] { 1, 5, 6, 8 };

            var dp = new int[coins.Length, targetSum + 1];

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = coins[i] + j - 1;
                        continue;
                    }

                    var currentCoin = coins[i];

                    if (currentCoin <= j)
                    {
                        var currentBest = i - 1 < 0 ? 0 : dp[i - 1, j];

                        var newValue = 1 + dp[i, j - currentCoin];

                        dp[i, j] = Math.Min(currentBest, newValue);
                        continue;
                    }

                    dp[i, j] = i - 1 < 0 ? 0 : dp[i - 1, j];
                }
            }

            var minNumCoins = dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
            Console.WriteLine(minNumCoins);

            // get the coins that make up the min

            var bestCoins = new List<int>();
            var currentRow = dp.GetLength(0) - 1;
            var currentCol = dp.GetLength(1) - 1;

            while (dp[currentRow, currentCol] != 0)
            {

                if (dp[currentRow, currentCol] == dp[currentRow - 1, currentCol])
                {
                    --currentRow;
                    continue;
                }

                bestCoins.Add(coins[currentRow]);
                currentCol = currentCol - coins[currentRow];

            }

            Console.WriteLine(string.Join(" ", bestCoins));
        }
    }
}
