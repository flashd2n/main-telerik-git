using System;
using System.Numerics;

namespace exEight
{
    class exerEight
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //BigInteger factorialN = 1;
            //BigInteger factorial2n = 1;
            //BigInteger factorialN1 = 1;

            //for (int i = n; i > 0; i--)
            //{
            //    factorialN *= i;
            //}

            //Console.WriteLine("factorial N: {0}", factorialN);

            //for (int i = (2 * n); i > 0; i--)
            //{
            //    factorial2n *= i;
            //}

            //Console.WriteLine("factorial 2N: {0}", factorial2n);

            //for (int i = (n + 1); i > 0; i--)
            //{
            //    factorialN1 *= i;
            //}

            //Console.WriteLine("factorial n+1: {0}", factorialN1);

            //BigInteger catalan = factorial2n / (factorialN1 * factorialN);

            BigInteger factorialN = 1;
            BigInteger factorialTop = 1;

            for (BigInteger i = n; i > 0; i--)
            {
                factorialN *= i;
            }

            for (BigInteger j = (n + 2); j <= (2 * n); j++)
            {
                factorialTop *= j;
            }

            BigInteger catalan = factorialTop / factorialN;

            Console.WriteLine(catalan);

        }
    }
}
