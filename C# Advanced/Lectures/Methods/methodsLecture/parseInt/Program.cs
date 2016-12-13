using System;

namespace parseInt
{
    class Program
    {
        static int ParseInt(string numberAsString)
        {
            int result = 0;

            //for (int i = 0; i < numberAsString.Length; i++)
            //{
            //    int digitValue = numberAsString[i] - '0';

            //    result += (int)(digitValue * Math.Pow(10, (numberAsString.Length - 1 - i)));
            //}


            foreach (char digit in numberAsString)
            {
                result = result * 10 + (digit - '0');
                Console.WriteLine(result);
            }

            return result;
        }

        static void Main()
        {

            int number = ParseInt("12412");

            Console.WriteLine(number * 2);

        }
    }
}
