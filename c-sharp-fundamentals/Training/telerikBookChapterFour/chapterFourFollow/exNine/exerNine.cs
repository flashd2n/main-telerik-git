using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exNine
{
    class exerNine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the first integer");
            int n = int.Parse(Console.ReadLine());

            int sum = 0;


            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Type integer numer {0}", i);
                sum = int.Parse(Console.ReadLine()) + sum;

            }

            Console.WriteLine(sum);
        }
    }
}
