using System;

namespace multiplicationSign
{
    class multiSign
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            int negativeCounter = 0;


            if (a == 0 || b == 0 || c == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (a < 0)
                {
                    negativeCounter++;
                }
                if (b < 0)
                {
                    negativeCounter++;
                }
                if (c < 0)
                {
                    negativeCounter++;
                }
                if (negativeCounter % 2 == 0)
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
