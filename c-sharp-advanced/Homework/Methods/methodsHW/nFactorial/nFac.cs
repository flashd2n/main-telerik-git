using System;
using System.Numerics;

namespace nFactorial
{
    class nFac
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());


            Console.WriteLine(CalculateFactorial(number));


        }

        static BigInteger CalculateFactorial(int number)
        {
            BigInteger factorial = 1;

            for (int i = number; i >= 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
