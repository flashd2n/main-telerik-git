using System;

namespace taskSix
{
    class taskSix
    {
        static void Main()
        {
            Console.WriteLine(@"Type one of the following:
1: Three sides
2: Side and altitiude to it
3: Two sides and the angle between them in degrees");

            int options = int.Parse(Console.ReadLine());
            double area = 0; ;
            double a = 0;
            double b = 0;
            if (options == 1)
            {
                Console.WriteLine("Enter Side A");
                a = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Side B");
                b = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Side C");
                double c = double.Parse(Console.ReadLine());
                double halfPerimeter = GetHalfPer(a, b, c);
                area = GetArea(halfPerimeter, a, b, c);
            }
            else if (options == 2)
            {
                Console.WriteLine("Enter Side A");
                a = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Altitude");
                double altitude = double.Parse(Console.ReadLine());
                area = GetArea(a, altitude);
            }
            else
            {
                Console.WriteLine("Enter Side A");
                a = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Side B");
                b = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Side Angle");
                double angle = double.Parse(Console.ReadLine());
                area = GetArea(a, b, angle);
            }

            Console.WriteLine($"The area of the triangle is {area}");
        }

        private static double GetArea(double a, double b, double angle)
        {
            double result = (a * b * Math.Sin((angle * Math.PI) / 180)) / 2D;
            return result;
        }

        private static double GetArea(double a, double altitude)
        {
            double result = (a * altitude) / 2D;
            return result;
        }

        private static double GetArea(double halfPerimeter, double a, double b, double c)
        {
            double result = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return result;
        }

        private static double GetHalfPer(double a, double b, double c)
        {
            double result = (a + b + c) / 2D;
            return result;
        }
    }
}
