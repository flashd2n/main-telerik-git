using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Startup
    {
        static void Main()
        {
            //var coins = new int[] { 1, 3, 5};
            //var targetSum = 11;

            //var dp = new int[targetSum + 1];
            //dp[0] = 0;

            //for (int i = 1; i <= targetSum; i++)
            //{
            //    var indexBc = LowerBound<int>(coins, i);
            //    var biggestCoin = indexBc >= coins.Length || coins[indexBc] > i ? coins[--indexBc] : coins[indexBc];

            //    var solution = i - biggestCoin;

            //    dp[i] = dp[solution] + 1;
            //}

            //Console.WriteLine(dp[targetSum]);

            // PURE DP

            var coins = new int[] { 1, 3, 5 };
            var targetSum = 11;

            var path = new int[targetSum + 1];
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = -1;
            }

            var dp = new int[targetSum + 1];
            dp[0] = 0;

            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }

            for (int i = 1; i <= targetSum; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i && (dp[i - coins[j]] + 1) < dp[i])
                    {
                        dp[i] = dp[i - coins[j]] + 1;
                        // adding coin[j] to solution sum - coin[j]
                        //Console.WriteLine($"Sum {i} -> {coins[j]} + {i - coins[j]}");
                        path[i] = i - coins[j];
                    }
                }
            }

            Console.WriteLine("Minimum number of coins: " + dp[targetSum]);

            var usedCoins = new List<int>();

            var current = targetSum;
            while (current != 0)
            {
                usedCoins.Add(current - path[current]);
                current = path[current];
            }

            usedCoins.Reverse();
            Console.WriteLine("Sum " + targetSum + " = " + string.Join(" ", usedCoins));
        }

        public static int LowerBound<T>(T[] array, T value)
            where T : IComparable<T>
        {
            return Bound(array, x => x.CompareTo(value) < 0);
        }

        private static int Bound<T>(T[] array, Func<T, bool> f)
        {
            var left = 0;
            var right = array.Length;

            while (right - left != 0)
            {
                var middle = (left + right) / 2;

                if (f(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }
}
