using System;
using System.Collections.Generic;

namespace Task5
{
    class Startup
    {
        static void Main()
        {

            var input = new int[] { 19, -10, 12, -6, -3, 34, -2, 5 };

            var result = RemoveNegatives(input);

            Console.WriteLine(string.Join(" ", result));

        }

        public static int[] RemoveNegatives(int[] input)
        {
            var result = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] >= 0)
                {
                    result.Add(input[i]);
                }

            }

            return result.ToArray();

        }
    }
}
