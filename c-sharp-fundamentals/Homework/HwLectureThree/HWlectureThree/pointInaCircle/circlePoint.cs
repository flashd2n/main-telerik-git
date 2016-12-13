using System;

namespace pointInaCircle
{
    class circlePoint
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            double xSquared = x * x;
            double ySquared = y * y;
            double distance = Math.Sqrt(xSquared + ySquared);

            if ((xSquared + ySquared) <= 4)
            {
                
                Console.WriteLine("yes " + string.Format("{0:0.00}", distance));

            }
            else
            {
                Console.WriteLine("no " + string.Format("{0:0.00}", distance));
            }
        }
    }
}
