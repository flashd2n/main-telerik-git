using System;

namespace hexadecimalToBinary
{
    class hexTobin
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string result = null;

            for (int i = 0; i < input.Length; i++)
            {
                ulong remainder;
                ulong binary;
                ulong hexValue;
                string tempResult = null;

                if (input[i] >= 65)
                {
                    hexValue = (ulong)input[i] - 55;
                }
                else
                {
                    hexValue = (ulong)input[i] - 48;
                }

                do
                {
                    remainder = hexValue / 2;
                    binary = hexValue % 2;
                    hexValue = remainder;
                    tempResult += binary;
                } while (hexValue != 0);                

                if (i != 0)
                {
                    // zeroes to 4-set
                    tempResult = tempResult.PadRight(4, '0');
                }

                // revert contents of a string

                char[] arr = tempResult.ToCharArray();
                Array.Reverse(arr);
                tempResult = new string(arr);

                result += tempResult;
            }
            Console.WriteLine(result);
        }
    }
}
