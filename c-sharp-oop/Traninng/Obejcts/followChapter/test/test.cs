using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class test
    {
        static void Main(string[] args)
        {
            var rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(rnd.Next(0));
            }


        }
    }
}
