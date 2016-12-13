using System;

namespace binaryToDecimal
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            ulong result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                result = result * 2 + ((ulong)input[i] - 48);
            }
            Console.WriteLine(result);
        }
    }
}
