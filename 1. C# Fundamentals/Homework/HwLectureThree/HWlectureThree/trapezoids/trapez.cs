using System;

namespace trapezoids
{
    class trapez
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double sideH = double.Parse(Console.ReadLine());

            double area = ((sideA + sideB) / 2) * sideH;
            Console.WriteLine(string.Format("{0:0.0000000}", area));
        }
    }
}
