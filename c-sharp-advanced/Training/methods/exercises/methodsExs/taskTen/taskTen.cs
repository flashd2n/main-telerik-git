using System;
using System.Numerics;

namespace taskTen
{
    class taskTen
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(CalcFactorial(input));
        }

        static BigInteger CalcFactorial (int number)
        {
            BigInteger result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
