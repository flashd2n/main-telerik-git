using System;

namespace frequentNumber
{
    class frequentNum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int counter = 0;
            int bestCount = 0;
            int currentIndex = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    if (array[i] == array[j])
                    {
                        ++counter;
                    }
                }
                if (counter > bestCount)
                {
                    bestCount = counter;
                    currentIndex = i;
                }
                counter = 0;
            }
            Console.WriteLine("{0} ({1} times)", array[currentIndex], bestCount);
        }
    }
}
