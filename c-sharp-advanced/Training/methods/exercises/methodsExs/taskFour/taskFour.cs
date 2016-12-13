using System;
using System.Linq;

namespace taskFour
{
    class taskFour
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetOccurences(array, number));
        }

        static int GetOccurences(int[] array, int number)
        {
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                {
                    ++counter;
                }
            }
            return counter;
        }
    }
}
