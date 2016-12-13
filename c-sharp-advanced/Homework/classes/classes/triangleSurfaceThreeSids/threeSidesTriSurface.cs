using System;

namespace triangleSurfaceThreeSids
{
    class threeSidesTriSurface
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double semiPeri = (a + b + c) / 2D;

            double area = Math.Sqrt(((semiPeri - a) * (semiPeri - b) * (semiPeri - c)) * semiPeri);

            Console.WriteLine("{0:F2}", area);

        }
    }
}
