using System;

namespace circleEx
{
    class circle
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * (radius * radius);

            Console.Write("{0:F2} {1:F2}", perimeter, area);

        }
    }
}
