using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exFour
{
    class exerFour
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer to be converted into hexadecimal");
            int a = int.Parse(Console.ReadLine());        

            Console.WriteLine("Enter a floating point number");
            double b = double.Parse(Console.ReadLine());


            Console.WriteLine("Enter a negative floating point number");
            double c = double.Parse(Console.ReadLine());

            Console.Write("{0,-10}{1,-10}{2,-10}", a, b, c);

        }
    }
}
