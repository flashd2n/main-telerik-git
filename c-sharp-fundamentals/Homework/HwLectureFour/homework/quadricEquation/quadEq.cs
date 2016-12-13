using System;

namespace quadricEquation
{
    class quadEq
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double x;
            double x2;

            double diskrim = (b * b) - (4D * a * c);

            if (diskrim < 0)
            {
                Console.WriteLine("no real roots");
            }
            else
            {
                if (diskrim == 0)
                {
                    x = -(b / (2D * a));
                    Console.WriteLine("{0:F2}" ,x);
                }
                else
                {
                    x = (-b + Math.Sqrt(diskrim)) / (2D * a);
                    x2 = (-b - Math.Sqrt(diskrim)) / (2D * a);

                    if (x > x2)
                    {
                        Console.WriteLine("{0:F2}", x2);
                        Console.WriteLine("{0:F2}", x);
                    }
                    else
                    {
                        Console.WriteLine("{0:F2}", x);
                        Console.WriteLine("{0:F2}", x2);
                    }
                }
            }
        }
    }
}
