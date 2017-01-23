using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    class Startup
    {
        static void Main()
        {
            int n = 10;

            ulong fibNum = Fib(n);

            Console.WriteLine(fibNum);

        }

        static ulong Fib(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
