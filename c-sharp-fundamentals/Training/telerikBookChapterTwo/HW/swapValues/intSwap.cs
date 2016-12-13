using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapValues
{
    class intSwap
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.WriteLine("swapped");
            int container = a;
            a = b;
            b = container;
            Console.WriteLine(a);
            Console.WriteLine(b);




        }
    }
}
