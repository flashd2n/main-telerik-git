using System;

namespace comparingFloats
{
    class compareFloats
    {
        static void Main(string[] args)
        {
            float constant = 0.000001F;
            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());

            bool compareNumbers = Math.Abs(numberOne - numberTwo) < constant;

            if (compareNumbers)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
