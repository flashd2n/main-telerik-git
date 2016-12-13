using System;

namespace primeNumbers
{
    class pNums
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] array = new bool[n + 1];
            int thisIndex = 0;

            for (int i = 2; i <= n; i++)
            {
                array[i] = true;
            }

            for (int i = 2; i * i <= n; i++)
            {
                if (array[i] == true)
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        array[j] = false;
                    }
                }
            }

            for (int i = (array.Length - 1); i >= 0; i--)
            {
                if (array[i] == true)
                {
                    thisIndex = i;
                    break;
                }
            }
            Console.WriteLine(thisIndex);
         
        }
    }
}
