using System;

namespace taskSeven
{
    class taskSeven
    {
        static void Main(
            string numbers = Console.ReadLine();
            int newdigits = int.Parse(ReverseDigits(numbers));

            Console.WriteLine(newdigits);
            Console.WriteLine(newdigits + 1);
        }

        static string ReverseDigits (string digits)
        {
            string reversed = null;

            for (int i = 0; i < digits.Length; i++)
            {
                reversed = digits[i] + reversed;
            }
            return reversed;
        }
    }
}
