using System;
    class SortingArray
    {
        static int[] SortArray(int[] array)
        {
            Array.Sort(array);
            return array;

        }
        static int[] GetArray(int arrLength)
        {
            int[] array = new int[arrLength];
            string[] arrayAsString = Console.ReadLine().Split(' ');
            for (int i = 0; i < arrLength; i++)
            {
                array[i] = int.Parse(arrayAsString[i]);
            }
            return array;
        }
        static void Main()
        {
            int[] myArray = GetArray(int.Parse(Console.ReadLine()));
            SortArray(myArray);
            foreach (int element in myArray)
            {
                Console.Write("{0} ", element);
            }

        }
    }