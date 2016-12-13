using System;

namespace exTwo
{
    class exerTwo
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            int negativeCount = 0;

            if (a >= 0 && b >= 0 && c >= 0)
            {
                Console.WriteLine("+");
            }
            else
            {
                if (a < 0)
                {
                    ++negativeCount;
                }
                if (b < 0)
                {
                    ++negativeCount;
                }
                if (c < 0)
                {
                    ++negativeCount;
                }
                if (negativeCount % 2 == 0)
                {
                    Console.WriteLine("+");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
        }
    }
}
