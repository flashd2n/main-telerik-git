using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitwiseOperators
{
    class bitwiseOperators
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine(a + " " + b);

            //int store = a;
            //a = b;
            //b = store;

            a = a ^ b; // a ^= b
            b = a ^ b; 
            a = a ^ b; // a ^= b

            Console.WriteLine(a + " " + b);

            Console.WriteLine((7 ^ 3) ^3);

            Console.WriteLine("even, odd, even");
            Console.WriteLine(6 & 1);
            Console.WriteLine(7 & 1);
            Console.WriteLine(8 & 1);

        }
    }
}
