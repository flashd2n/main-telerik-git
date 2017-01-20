using System;
using System.Collections.Generic;
using System.Numerics;

namespace messages
{
    class Startup
    {
        public static List<string> keys = new List<string>() { "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan"};

        static void Main()
        {
            string numberOne = Console.ReadLine();
            string operand = Console.ReadLine();
            string numberTwo = Console.ReadLine();
            var numOne = CodeAsDigit(numberOne);
            var numTwo = CodeAsDigit(numberTwo);
            var result = new BigInteger();


            if (operand == "+")
            {
                result = numOne + numTwo;
            }
            else
            {
                result = numOne - numTwo;
            }
            Console.WriteLine(CodeAsString(result));
        }

        static BigInteger CodeAsDigit(string input)
        {
            string tempResult = null;

            for (int i = 0; i < input.Length; i += 3)
            {
                for (int j = 0; j < keys.Count; j++)
                {
                    if (input.Substring(i, 3) == keys[j])
                    {
                        tempResult += j;
                        break;
                    }
                }
            }
            BigInteger result = BigInteger.Parse(tempResult);
            return result;
        }

        static string CodeAsString(BigInteger number)
        {
            string result = null;
            string numberAsString = number.ToString();
            for (int i = 0; i < numberAsString.Length; i++)
            {
                result += keys[int.Parse(numberAsString[i].ToString())];
            }
            return result;
        }
    }
}
