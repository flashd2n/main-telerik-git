using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FastPower
{
    public class Startup
    {
        static void Main()
        {

            Console.WriteLine(FastPower(2, 3));
            Console.WriteLine(SlowPower(2, 3));
            Console.WriteLine(Math.Pow(2, 3));
        }

        public static BigInteger FastPower(int n, int p)
        {
            if (p == 0)
            {
                return 1;
            }

            if (p % 2 == 1)
            {
                return n * FastPower(n, p - 1);
            }

            BigInteger half = FastPower(n, p / 2);

            return half * half;

        }

        public static BigInteger SlowPower(int n, int p)
        {
            if (p == 0)
            {
                return 1;
            }

            return n * SlowPower(n, p - 1);

        }
    }
}
