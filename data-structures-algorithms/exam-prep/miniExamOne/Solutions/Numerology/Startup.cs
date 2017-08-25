using System;

namespace Numerology
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var result = new int[10];
            RunCalc(input, result);
            Console.WriteLine(string.Join(" ", result));
        }

        public static void RunCalc(string input, int[] result)
        {
            if (input.Length == 1)
            {
                var digit = int.Parse(input);
                ++result[digit];
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                var firstDigit = (int)input[i] - 48;
                var secondDigit = (int)input[i + 1] - 48;

                var newDigit = (firstDigit + secondDigit) * (firstDigit ^ secondDigit) % 10;
                var newInput = input.Substring(0, i) + newDigit + input.Substring(i + 2);

                RunCalc(newInput, result);
            }
        }
    }
}
