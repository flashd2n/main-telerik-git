using System;

namespace taskFive
{
    class taskFive
    {
        static void Main()
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double result = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            Console.WriteLine(result);
        }
    }
}
