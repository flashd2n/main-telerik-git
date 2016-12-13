using System;

namespace selectionSort
{
    class selectionSort
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int tempSwitch = 0;
            int switchIndex = 0;
            int minValue = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (array[j] < minValue)
                    {
                        minValue = array[j];
                        switchIndex = j;
                    }                    
                }

                tempSwitch = array[i];
                array[i] = minValue;
                array[switchIndex] = tempSwitch;
                minValue = int.MaxValue;

            }

            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
