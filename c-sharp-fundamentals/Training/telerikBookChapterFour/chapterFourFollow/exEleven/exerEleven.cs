using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exEleven
{
    class exerEleven
    {
        static void Main(string[] args)
        {
            double first = 0;
            double second = 1;
            double third = 1;

            Console.Write("{0}, {1}, {2}, ", first, second, third);

            for (int i = 0; i < 97; i++)
            {

                double fibo = second + third; // next loop --->  new fibo = third + fibo

                Console.Write("{0}, ", fibo);

                second = third;
                third = fibo;

            }


        }
    }
}
