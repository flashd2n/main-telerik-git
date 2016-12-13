using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTwo
{
    class exerTwo
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * (radius * radius);

            Console.WriteLine("Perimeter is {0}; the area is {1}", perimeter, area);

        }
    }
}
