using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Startup
    {
        static void Main()
        {
            var bagWeight = 7;
            var items = new List<Item>();

            var item = new Item(1, 1);
            var itemTwo = new Item(4, 3);
            var itemThree = new Item(5, 4);
            var itemFour = new Item(7, 5);

            items.Add(item);
            items.Add(itemTwo);
            items.Add(itemThree);
            items.Add(itemFour);

            var dp = new int[items.Count, bagWeight + 1];

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    var currentItem = items[i];

                    if (currentItem.Weight <= j)
                    {
                        var currentBest = i - 1 < 0 ? 0 : dp[i - 1, j];

                        var newValue = i - 1 < 0 ? 0 : currentItem.Value + dp[i - 1, j - currentItem.Weight];

                        dp[i, j] = Math.Max(currentBest, newValue);

                        continue;
                    }

                    dp[i, j] = i - 1 < 0 ? 0 : dp[i - 1, j];

                }
            }

            var maxValue = dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
            Console.WriteLine(maxValue);

            // get items that make up the max value

            var bestItems = new List<Item>();

            var currentRow = dp.GetLength(0) - 1;
            var currentCol = dp.GetLength(1) - 1;

            while (dp[currentRow, currentCol] != 0)
            {
                if (dp[currentRow, currentCol] == dp[currentRow - 1, currentCol])
                {
                    --currentRow;
                    continue;
                }

                bestItems.Add(items[currentRow]);
                currentCol = currentCol - items[currentRow].Weight;
            }

            Console.WriteLine(string.Join("\n", bestItems));
        }
    }

    internal class Item
    {
        public Item(int value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
        }

        public int Value { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Weight:{this.Weight} | Value: {this.Value}";
        }
    }
}
