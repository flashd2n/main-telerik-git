using System;

namespace rectangles
{
    class rectangleEx
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = width * height;
            double perimeter = (width + height) * 2;
            Console.Write(string.Format("{0:0.00}", area) + " " + string.Format("{0:0.00}", perimeter));
        }
    }
}
