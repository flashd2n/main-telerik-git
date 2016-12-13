using System;

namespace binaryToHexadecimal
{
    class binToHEx
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int remDivision = 0;
            string finalResult = null;

            // make sure the binary input groups all have 4 elements

            if (input.Length % 4 != 0)
            {
                remDivision = 4 - (input.Length % 4);

                for (int i = 0; i < remDivision; i++)
                {
                    input = '0' + input;
                }
            }

            // take a set of 4 at a time

            for (int i = 0; i < input.Length - 1; i = i + 4)
            {
                var temp = new char[4];
                input.CopyTo(i, temp, 0, 4); 
                string oneByte = new string(temp);

                ulong result = 0;

                for (int j = 0; j < oneByte.Length; j++)
                {
                    result = result * 2 + ((ulong)oneByte[j] - 48);
                }

                if (result >= 10)
                {
                    char hexValue = (char)(result + 55);
                    finalResult += hexValue;
                }
                else
                {
                    finalResult += result;
                }
            }
            Console.WriteLine(finalResult);
        }
    }
}
