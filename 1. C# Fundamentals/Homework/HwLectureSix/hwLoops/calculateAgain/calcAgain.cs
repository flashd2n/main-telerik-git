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

            BigInteger result = 1;

            for (int i = 1; i <= n - k; i++)
            {
                result *= k + i; 
            }

            Console.WriteLine(result);

        }
    }
}
