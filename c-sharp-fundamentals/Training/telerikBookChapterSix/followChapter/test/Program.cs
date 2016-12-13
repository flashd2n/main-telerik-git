using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "1234";

            int converted = Convert.ToInt32(str, 10);

            //Console.WriteLine(converted + 1);

            //char doThis = str[1];

            Console.WriteLine((int)str[1]);


        }
    }
}
