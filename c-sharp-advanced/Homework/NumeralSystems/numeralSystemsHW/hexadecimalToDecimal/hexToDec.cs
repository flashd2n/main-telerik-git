using System;

namespace hexadecimalToDecimal
{
    class hexToDec
    {
        static void Main()
        {
            string input = Console.ReadLine();
            ulong result = 0;
            ulong hexValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 65)
                {
                    hexValue = (ulong)input[i] - 55;
                    result = result * 16 + hexValue;
                }
                else
                {
                    result = result * 16 + ((ulong)input[i] - 48);
                }                
            }
            Console.WriteLine(result);
        }
    }
}
