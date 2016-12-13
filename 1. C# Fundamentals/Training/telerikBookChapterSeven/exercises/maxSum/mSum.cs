using System;

namespace maxSum
{
    class mSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            int currentSum = 0;
            int bestSum = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }


            for (int i = 0; i < n; i++)
            {

                currentSum += array[i];

                if (currentSum < 0)
                {

                    currentSum = 0;
                }

                if (bestSum < currentSum)
                {
                    bestSum = currentSum;
                }


            }

            Console.WriteLine(bestSum);

        }
    }
}
