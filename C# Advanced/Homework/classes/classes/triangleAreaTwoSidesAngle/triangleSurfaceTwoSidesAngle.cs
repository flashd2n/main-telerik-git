using System;

namespace triangleAreaTwoSidesAngle
{
    class triangleSurfaceTwoSidesAngle
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());
            double sinAngle = Math.Sin(angle * Math.PI / 180);

            double area = (a * b * sinAngle) / 2D;

            Console.WriteLine("{0:F2}", area);
        }
    }
}
