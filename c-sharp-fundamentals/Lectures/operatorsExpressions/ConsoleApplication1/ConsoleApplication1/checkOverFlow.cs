using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class checkOverFlow
    {
        static void Main(string[] args)
        {
            /*
            
            int a;
            checked
            {
                a = int.MaxValue + int.Parse(Console.ReadLine());
            }
            Console.WriteLine(a);

            */
            int maxA = 10000;
            int maxB = 13121233;
            Console.WriteLine(checked(maxA * maxB));


        }
    }
}
