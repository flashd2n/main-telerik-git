using System;

namespace increasingSequance
{
    class incSequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            int counter = 1;
            int maxCounter = 0;
            int bestIndex = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());

                if (i == 0)
                {
                    continue;
                }

                if (array[i] > array[i - 1])
                {
                    ++counter;

                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        bestIndex = i;
                    }
                }
                else
                {
                    counter = 1;
                }

            }

            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write("{0}{1}", array[bestIndex - i], i == (maxCounter - 1) ? "\n" : " ");
            }


            Console.Write("The counter is: ");

            Console.WriteLine(maxCounter);



        }
    }
}
