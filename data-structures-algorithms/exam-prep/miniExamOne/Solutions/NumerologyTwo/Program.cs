using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerologyTwo
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var result = new int[10];
            RunAlgo(input, result);
            Console.WriteLine(string.Join(" ", result));
        }

        private static void RunAlgo(string input, int[] result)
        {
            if (input.Length == 1)
            {
                var digit = int.Parse(input);
                ++result[digit];
                return;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                var a = (int)input[i] - 48;
                var b = (int)input[i + 1] - 48;
                var newDigit = (a + b) * (a ^ b) % 10;
                var newInput = input.Substring(0, i) + newDigit + input.Substring(i + 2);
                RunAlgo(newInput, result);
            }

        }
    }
}
