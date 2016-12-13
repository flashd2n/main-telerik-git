using System;

namespace fourDigits
{
    class fDigits
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int maskFirst = number;
            int maskSecond = number / 10;
            int maskThird = number / 100;
            int maskFourth = number / 1000;
            int numberD = number % 10;
            int numberC = maskSecond % 10;
            int numberB = maskThird % 10;
            int numberA = maskFourth;

            int sumOfDigits = numberA + numberB + numberC + numberD;
            Console.WriteLine(sumOfDigits);
            Console.WriteLine(numberD.ToString() + numberC.ToString() + numberB.ToString() + numberA.ToString());
            Console.WriteLine(numberD.ToString() + numberA.ToString() + numberB.ToString() + numberC.ToString());
            Console.WriteLine(numberA.ToString() + numberC.ToString() + numberB.ToString() + numberD.ToString());


        }
    }
}
