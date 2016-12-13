using System;

namespace pointCircleRectangle
{
    class pointCircleRec
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double circleRadiusSq = 2.25D;

            double xCircleSq = (x - 1) * (x - 1);
            double yCircleSq = (y - 1) * (y - 1);

            bool isCircle = (xCircleSq + yCircleSq) <= circleRadiusSq;

            bool isRectangle = (x >= -1 && x <= 5) && (y <= 1 && y >= -1);

            if (isCircle)
            {
                Console.Write("inside circle ");
            }
            else
            {
                Console.Write("outside circle ");
            }

            if (isRectangle)
            {
                Console.Write("inside rectangle");
            }
            else
            {
                Console.Write("outside rectangle");
            }
        }
    }
}
