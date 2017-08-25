using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    class Startup
    {
        static void Main()
        {
            var p = int.Parse(Console.ReadLine());
            var numsToCheck = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            var numbersToCheck = new HashSet<long>(numsToCheck);

            var tree = new HashSet<long>();
            tree.Add(1);

            var maxValue = numbersToCheck.Max();

            GenerateTree(tree, 1, p, maxValue);

            var result = new int[numbersToCheck.Count];
            var resultIndex = 0;

            foreach (var checkNum in numbersToCheck)
            {
                var counter = 0;
                foreach (var item in tree)
                {
                    if (tree.Contains(checkNum - item))
                    {
                        ++counter;
                    }
                }

                if (counter == 2)
                {
                    result[resultIndex] = 1;
                    ++resultIndex;
                }
                else
                {
                    result[resultIndex] = 0;
                    ++resultIndex;
                }

            }

            Console.WriteLine(string.Join(" ", result));

        }

        private static void GenerateTree(HashSet<long> tree, long current, int p,long maxValue)
        {
            if (current >= maxValue)
            {
                return;
            }

            var leftChild = current * p;
            var rightChild = current * p + 1;
            tree.Add(leftChild);
            tree.Add(rightChild);
            GenerateTree(tree, leftChild, p, maxValue);
            GenerateTree(tree, rightChild, p, maxValue);
        }
    }
}
