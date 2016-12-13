using System;

namespace removeElements
{
    class remElements
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            int[] theFuckingSequence = new int[n];
            int[] longestSequenceLength = new int[n];
            int maxLength = 0;

            for (int i = 0; i < n; i++)
            {
                theFuckingSequence[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                longestSequenceLength[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                int currentBest = 0;
                for (int j = 0; j < i; j++)
                {

                    if (theFuckingSequence[i] >= theFuckingSequence[j])
                    {
                        longestSequenceLength[i] += longestSequenceLength[j];
                    }

                    if (longestSequenceLength[i] > currentBest)
                    {
                        currentBest = longestSequenceLength[i];
                    }

                    longestSequenceLength[i] = 1;

                    if (j == i - 1)
                    {
                        longestSequenceLength[i] = currentBest;
                    }

                    if (currentBest > maxLength)
                    {
                        maxLength = currentBest;
                    }
                }
            }
            Console.WriteLine(n - maxLength);
        }
    }
}
