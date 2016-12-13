using System;
using System.Numerics;

namespace cryptoCS
{
    class cryptoCS
    {
        static void Main()
        {
            string inputOne = Console.ReadLine();
            string operation = Console.ReadLine();
            string inputTwo = Console.ReadLine();

            BigInteger numberOne = CoverToDec(inputOne, 26);
            BigInteger numberTwo = CoverToDec(inputTwo, 7);
            BigInteger resultToConvert = 0;

            if (operation == "+")
            {
                resultToConvert = numberOne + numberTwo;
            }
            else
            {
                resultToConvert = numberOne - numberTwo;
            }

            string result = ConvertToResult(resultToConvert, 9);

            Console.WriteLine(result);
            
        }

        static string ConvertToResult(BigInteger resultToConvert, int numBase)
        {
            
            string result = null;
            BigInteger remainder = 0;
            byte outputNum = 0;

            while (resultToConvert != 0)
            {
                remainder = resultToConvert / numBase;
                outputNum = (byte)(resultToConvert % numBase);
                resultToConvert = remainder;

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
            

            return result;
                
        }

        static BigInteger CoverToDec(string numOneCovert, int numBase)
        {
            
            BigInteger result = 0;
            byte hexValue;

            for (int i = 0; i < numOneCovert.Length; i++)
            {
                if (numOneCovert[i] >= 65)
                {
                    hexValue = (byte)(numOneCovert[i] - 97);
                    result = result * numBase + hexValue;
                }
                else
                {
                    result = result * numBase + (numOneCovert[i] - 48);
                }
            }

            return result;
            
        }
    }
}
