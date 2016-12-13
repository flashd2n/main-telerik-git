using System;
using System.Linq;

namespace taskSix
{
    class taskSix
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(GetOccurence(array));
        }

        static int GetOccurence(int[] array)
        {
            int index = -1;

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
