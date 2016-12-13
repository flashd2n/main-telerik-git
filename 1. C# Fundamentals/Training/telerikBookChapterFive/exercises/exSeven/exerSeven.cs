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
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            //int level1 = Math.Max(a, b);
            //int level11 = Math.Max(c, d);
            //int level2 = Math.Max(level1, level11);
            //int result = Math.Max(e, level2);

            int result = Math.Max(e, Math.Max(Math.Max(a, b), Math.Max(c, d)));

            Console.WriteLine(result);




        }
    }
}
