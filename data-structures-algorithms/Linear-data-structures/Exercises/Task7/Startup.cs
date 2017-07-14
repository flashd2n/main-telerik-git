using System;

namespace Task7
{
    class Startup
    {
        static void Main(string[] args)
        {

            var input = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var collection = new int[1000];

            for (int i = 0; i < input.Length; i++)
            {
                ++collection[input[i]];
            }

            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] != 0)
                {
                    Console.WriteLine($"{i} -> {collection[i]} times");
                }
            }

        }
    }
}
