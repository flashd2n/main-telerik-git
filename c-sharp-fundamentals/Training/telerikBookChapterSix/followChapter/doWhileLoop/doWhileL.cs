using System;
using System.Numerics;

namespace doWhileLoop
{
    class doWhileL
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //BigInteger factorial = 1;
            //do
            //{
            //    factorial *= n;
            //    n--;
            //} while (n > 0);
            //Console.WriteLine(factorial);

            int m = int.Parse(Console.ReadLine());

            int counter = n;
            long result = 1;
            do
            {
                result *= counter;
                counter++;
            } while (counter <= m);
            Console.WriteLine(result);





        }
    }
}
