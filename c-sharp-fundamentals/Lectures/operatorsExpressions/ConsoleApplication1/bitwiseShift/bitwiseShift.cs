using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitwiseShift
{
    class bitwiseShift
    {
        static void Main(string[] args)
        {
            // 7 is 111
            Console.WriteLine(7 << 1); // 7*2^1
            Console.WriteLine(7 << 2); // 7*2^2
            Console.WriteLine(7 << 3); // 7*2^3

            // select a given position in binary
            int n = 17;
            int mask = 1 << 4;
            Console.WriteLine((n & mask) >> 4);
            Console.WriteLine(Convert.ToString(n, 2));

            int t = 17;
            Console.WriteLine(Convert.ToString(t, 2));
            Console.WriteLine((t >> 4) & 1);  // 4-th pos

            Console.WriteLine(t & ~(1 << 4));


        }
    }
}
