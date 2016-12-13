using System;

namespace birdsAndFeathers
{
    class birdsFeathers
    {
        static void Main()
        {
            int b = int.Parse(Console.ReadLine());
            double f = double.Parse(Console.ReadLine());

            double averageFeathers = f / b;

            //Console.WriteLine(averageFeathers);

            //correct average feathers

            double finalResult = 1;

            if (b % 2 == 0)
            {
                finalResult = averageFeathers * 123123123123;
                Console.WriteLine("{0:F4}", finalResult);
            }
            else
            {
                finalResult = averageFeathers / 317;
                Console.WriteLine("{0:F4}", finalResult);
            }

        }
    }
}
