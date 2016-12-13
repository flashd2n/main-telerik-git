using System;

namespace taskSeven
{
    class taskSeven
    {
        static void Main()
        {
            string input = Console.ReadLine();

            input = input.PadRight(20, '*');

            Console.WriteLine(input);

        }
    }
}
