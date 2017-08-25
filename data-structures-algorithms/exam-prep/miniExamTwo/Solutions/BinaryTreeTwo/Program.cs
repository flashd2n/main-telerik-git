using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeTwo
{
    class Program
    {
        static void Main()
        {
            var p = int.Parse(Console.ReadLine());
            var allNums = new HashSet<long>();

            var numsInput = Console.ReadLine().Split(' ').Select(long.Parse);

            foreach (var item in numsInput)
            {
                allNums.Add(item);
            }

            var maxNum = allNums.Max();

            var pool = new HashSet<long>();
            pool.Add(1);
            GeneratePool(pool, 1, maxNum, p);

            var result = new int[allNums.Count];
            var resultIndex = 0;

            foreach (var num in allNums)
            {
                var counter = 0;
                foreach (var item in pool)
                {
                    if (pool.Contains(num - item))
                    {
                        ++counter;
                    }
                }

                if (counter == 2)
                {
                    result[resultIndex] = 1;
                }
                else
                {
                    result[resultIndex] = 0;
                }
                ++resultIndex;
            }

            Console.WriteLine(string.Join(" ", result));

        }

        private static void GeneratePool(HashSet<long> pool, long current, long maxNum, int p)
        {
            if (current >= maxNum)
            {
                return;
            }

            var left = current * p;
            var right = current * p + 1;

            pool.Add(left);
            pool.Add(right);

            GeneratePool(pool, left, maxNum, p);
            GeneratePool(pool, right, maxNum, p);
        }
    }
}
