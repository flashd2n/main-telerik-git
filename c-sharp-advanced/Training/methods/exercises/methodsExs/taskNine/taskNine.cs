using System;
using System.Linq;

namespace taskNine
{
    class taskNine
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int switchIndex = GetLargestElement(array, i);
                temp = array[i];
                array[i] = array[switchIndex];
                array[switchIndex] = temp;
            }

            Console.WriteLine(string.Join(" ", array));

        }

        static int GetLargestElement(int[] array, int startIndex)
        {
            int index = 0;
            int biggest = int.MinValue;
            for (int i = startIndex; i < array.Length; i++)
            {
                if (array[i] > biggest)
                {
                    index = i;
                    biggest = array[i];
                }
            }
            return index;
        }
    }
}
