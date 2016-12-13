using System;

namespace binarySearch
{
    class bSearch
    {
        static void Main()
        {
            //int n = int.Parse(Console.ReadLine());
            //int[] array = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    array[i] = int.Parse(Console.ReadLine());
            //}

            //int x = int.Parse(Console.ReadLine());
            //int thisIndex = -1;

            //for (int i = 0; i < n; i++)
            //{
            //    if (array[i] == x)
            //    {
            //        thisIndex = i;
            //        break;
            //    }
            //}

            //Console.WriteLine(thisIndex);

            //LOGARITHMIC SEARCH

            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int x = int.Parse(Console.ReadLine());
            int thisIndex = 0;
            bool isValid = false;

            if (x <= array[n / 2])
            {
                for (int i = 0; i <= (n / 2); i++)
                {
                    if (array[i] == x)
                    {
                        thisIndex = i;
                        isValid = true;
                        break;
                    }
                }
            }
            else if (x > array[n / 2])
            {
                for (int i = ((n / 2) + 1); i < n; i++)
                {
                    if (array[i] == x)
                    {
                        thisIndex = i;
                        isValid = true;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine(thisIndex);
            }
            else
            {
                Console.WriteLine("-1");
            }

        }
    }
}
