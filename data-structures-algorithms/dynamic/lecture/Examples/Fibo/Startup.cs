using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fibo
{
    class Startup
    {
        public static BigInteger[] memory = new BigInteger[10000];

        static void Main()
        {
            Console.WriteLine(Fibonacci(40));

            var n = 40;
            var fibs = new BigInteger[n + 1];
            fibs[0] = 1;
            fibs[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fibs[i] = fibs[i - 1] + fibs[i - 2];
            }

            Console.WriteLine(fibs[n]);
        }

        public static BigInteger Fibonacci(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            if (memory[n] != default(BigInteger))
            {
                return memory[n];
            }

            var result = Fibonacci(n - 1) + Fibonacci(n - 2);
            memory[n] = result;

            return result;
        }
    }
}
