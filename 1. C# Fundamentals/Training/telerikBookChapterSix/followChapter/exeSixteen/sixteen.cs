using System;

namespace exeSixteen
{
    class sixteen
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int randomNumber = 0;

            Random rndNum = new Random();

            for (int i = 0; i <= n - 1; i++)
            {

                redo:

                randomNumber = rndNum.Next(1, n + 1);
                array[i] = randomNumber;

                for (int j = 0; j < i; j++)
                {
                    if (i == 0)
                    {
                        break;
                    }

                    if (array[i] == array[j])
                    {
                        goto redo;
                    }

                }

            }

            for (int i = 0; i <= n - 1; i++)
            {
                Console.Write("{0} ", array[i]);

            }

        }
    }
}
