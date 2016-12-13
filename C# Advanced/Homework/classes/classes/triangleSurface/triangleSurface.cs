using System;

namespace triangleSurface
{
    class triangleSurface
    {
        static void Main()
        {
            double side = double.Parse(Console.ReadLine());

            double height = double.Parse(Console.ReadLine());

            double area = (height * side) / 2D;

            Console.WriteLine("{0:F2}", area);
        }
    }
}
