using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exSix
{
    class exerSix
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());



            //Console.WriteLine("Greater: {0}", (a + b + Math.Abs(a - b)) / 2);

            //Console.WriteLine(Math.Max(a, b));

            Console.WriteLine(a - ((a - b) & ((a - b) >> 31)));


        }
    }
}
