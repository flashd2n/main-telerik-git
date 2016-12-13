using System;
using System.Numerics;

namespace doWhileLoop
{
    class doWhileL
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            do
            {
                factorial *= n;
                n--;
            } while (n > 0);

            Console.WriteLine(factorial);

        }
    }
}
