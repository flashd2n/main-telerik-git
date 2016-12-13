using System;

namespace maximalSum
{
    class maxSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);
            int maxSum = 0;


            for (int i = 0; i < k; i++)
            {
                maxSum += array[n - 1 - i];
            }

            Console.WriteLine(maxSum);







        }
    }
}
