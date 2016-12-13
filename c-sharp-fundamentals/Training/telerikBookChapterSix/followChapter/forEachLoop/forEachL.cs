using System;

namespace forEachLoop
{
    class forEachL
    {
        static void Main()
        {
            int[] numbers = { 2, 3, 5, 7, 11, 13, 17, 19 };
            string[] towns = { "London", "Paris", "Luxemburg", "Madrid", "Sofia"};

            foreach (int num in numbers)
            {
                Console.WriteLine("{0} ", num);
            }
            Console.WriteLine("");
            foreach (string town in towns)
            {
                Console.WriteLine("{0} ", town);
            }
            Console.WriteLine("");
        }
    }
}
