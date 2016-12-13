using System;

namespace oneSystemToAnyOther
{
    class Program
    {
        static void Main()
        {
            byte baseInput = byte.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            byte baseOutput = byte.Parse(Console.ReadLine());
            string result = null;

            //convert to base10

            ulong inputDec = 0;
            byte hexValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 65)
                {
                    hexValue = (byte)(input[i] - 55);
                    inputDec = inputDec * baseInput + hexValue;
                }
                else
                {
                    inputDec = inputDec * baseInput + ((ulong)input[i] - 48);
                }
            }


            Console.WriteLine(inputDec);
            //convert to baseoutput from base 10

            ulong remainder = 0;
            byte outputNum = 0;

            while (inputDec != 0)
            {
                remainder = inputDec / baseOutput;
                outputNum = (byte)(inputDec % baseOutput);
                inputDec = remainder;

                if (outputNum > 9)
                {
                    outputNum += 55;
                    result = (char)outputNum + result;
                }
                else
                {
                    result = outputNum + result;
                }
            }

            Console.WriteLine(result);
        }
    }
}
