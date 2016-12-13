using System;

namespace decimalToHex
{
    class decToHex
    {
        static void Main()
        {
            ulong input = ulong.Parse(Console.ReadLine());

            ulong remainder = 0;
            ulong hexadecimal = 0;
            string result = null;

            while (input != 0)
            {
                remainder = input / 16;
                hexadecimal = input % 16;
                input = remainder;

                if (hexadecimal > 9)
                {
                    hexadecimal += 55;
                    result += (char)hexadecimal;
                }
                else
                {
                    result += hexadecimal;
                }                
            }

            for (int i = (result.Length - 1); i >= 0; i--)
            {
                Console.Write(result[i]);
            }
        }
    }
}
