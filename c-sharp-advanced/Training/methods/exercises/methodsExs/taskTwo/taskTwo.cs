using System;

namespace taskTwo
{
    class taskTwo
    {
        static void Main()
        {
            var numbers = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(GetMax(GetMax(numbers[0], numbers[1]), numbers[2]));
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
