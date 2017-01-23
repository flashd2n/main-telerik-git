using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Startup
    {
        static void Main()
        {
            int n = 5;
            int factorialN = Fact(n);

            Console.WriteLine(factorialN);
        }

        static int Fact(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Fact(n - 1);
            }
        }
    }
}
