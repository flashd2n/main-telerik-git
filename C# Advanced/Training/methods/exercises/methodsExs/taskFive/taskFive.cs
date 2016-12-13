using System;
using System.Linq;

namespace taskFive
{
    class taskFive
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int element = int.Parse(Console.ReadLine());
            int indexOfElement = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (element == array[i])
                {
                    indexOfElement = i;
                    break;
                }
            }

            if (CheckElement(array, indexOfElement))
            {
                Console.WriteLine("It is greater");
            }
            else
            {
                Console.WriteLine("NOT");
            }
        }

        static bool CheckElement(int[] array, int indexOfElement)
        {

            if (indexOfElement == 0)
            {
                if (array[indexOfElement] > array[indexOfElement + 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (indexOfElement == array.Length - 1)
            {
                if (array[indexOfElement] > array[indexOfElement - 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (array[indexOfElement] > array[indexOfElement - 1] && array[indexOfElement] > array[indexOfElement + 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
