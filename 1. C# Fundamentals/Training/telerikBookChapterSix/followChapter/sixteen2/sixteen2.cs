using System;

namespace sixteen2
{
    class sixteen2
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int tempSwap = 0;

            //fill array with numbers 1 to N

            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }

            //generate random pairs

            int rngPosOne = 0;
            int rngPosTwo = 0;

            Random rndNum = new Random();

            for (int i = 1; i <= n; i++)
            {

                rngPosOne = rndNum.Next(0, n);
                rngPosTwo = rndNum.Next(0, n);

                tempSwap = array[rngPosOne];
                array[rngPosOne] = array[rngPosTwo];
                array[rngPosTwo] = tempSwap;

            }

            for (int i = 0; i <= n - 1; i++)
            {
                Console.Write("{0} ", array[i]);

            }
        }
    }
}
