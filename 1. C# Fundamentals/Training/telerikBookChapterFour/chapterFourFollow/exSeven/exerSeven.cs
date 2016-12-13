using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exSeven
{
    class exerSeven
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int c;
            int d;
            int e;

            bool isA = int.TryParse(Console.ReadLine(), out a);
            bool isB = int.TryParse(Console.ReadLine(), out b);
            bool isC = int.TryParse(Console.ReadLine(), out c);
            bool isD = int.TryParse(Console.ReadLine(), out d);
            bool isE = int.TryParse(Console.ReadLine(), out e);

            if ((isA && isB && isC && isD && isE) == false)
            {
                Console.WriteLine("not all numbers are valid");
            }
            else
            {
                Console.WriteLine(a + b + c + d + e);
            }

        }
    }
}
