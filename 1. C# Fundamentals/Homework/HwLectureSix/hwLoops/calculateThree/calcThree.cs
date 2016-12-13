using System;
using System.Numerics;

namespace exSix
{
    class exerSix
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger top = 1;

            for (int i = 1; i <= n - k; i++)
            {
                top *= k + i;
            }

            BigInteger bottom = 1;

            for (int i = 1; i <= n - k; i++)
            {
                bottom *= i;

            }

            BigInteger result = top / bottom;

            Console.WriteLine(result);

        }
    }
}
