using System;
using System.Numerics;

namespace exEight
{
    class exerEight
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

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
