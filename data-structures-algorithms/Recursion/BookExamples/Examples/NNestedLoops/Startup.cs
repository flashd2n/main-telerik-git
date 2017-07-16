using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNestedLoops
{
    public class Startup
    {
        static void Main()
        {
            int n = 2;
            int k = 3;

            //for (int i = 0; i < k; i++)
            //{
            //    for (int j = 0; j < k; j++)
            //    {
            //        Console.WriteLine($"{i} {j}");
            //    }
            //}

            NestingLoopsRecursive(n, k);

        }

        public static void NestingLoopsRecursive(int numberOfLoops, int LoopSize)
        {
            var nums = new int[numberOfLoops];

            NestingLoopsRecursive(numberOfLoops, 0, LoopSize, nums);
        }

        public static void NestingLoopsRecursive(int numberOfLoops, int currentLoop, int LoopSize, int[] nums)
        {
            if (currentLoop == numberOfLoops)
            {
                Console.WriteLine(string.Join(" ", nums));
                return;
            }

            for (int i = 0; i < LoopSize; i++)
            {
                nums[currentLoop] = i;

                NestingLoopsRecursive(numberOfLoops, currentLoop + 1, LoopSize, nums);

            }
        }

    }
}
