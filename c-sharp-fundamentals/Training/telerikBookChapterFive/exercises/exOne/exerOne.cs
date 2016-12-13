using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exOne
{
    class exerOne
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a < b)
            {
                a = b;
            }

            Console.WriteLine(a);
        }
    }
}
