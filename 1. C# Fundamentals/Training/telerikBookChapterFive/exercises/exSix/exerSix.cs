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
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double discriminant = (b * b) - (4 * a * c);
            double result;
            double resultB;

            if (discriminant < 0)
            {
                Console.WriteLine("There are no real roots");
            }
            else
            {
                if (discriminant == 0)
                {
                    result = -(b / (2 * a));
                    Console.WriteLine(result);
                }
                else
                {
                    result = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    resultB = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    Console.WriteLine(result);
                    Console.WriteLine(resultB);
                }
            }




        }
    }
}
