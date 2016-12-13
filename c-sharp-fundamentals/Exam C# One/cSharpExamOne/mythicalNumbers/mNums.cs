using System;

namespace mythicalNumbers
{
    class mNums
    {
        static void Main()
        {

            int number = int.Parse(Console.ReadLine());

            int lastDigit = number % 10;
            int middleDigit = (number / 10) % 10;
            int firstDigit = (number / 100) % 10;

            if (lastDigit == 0)
            {
                Console.WriteLine("{0:F2}", firstDigit * middleDigit);
            }
            else if (lastDigit <= 5)
            {
                int product = firstDigit * middleDigit;
                double result = (double)product / lastDigit;
                Console.WriteLine("{0:F2}", result);
            }
            else
            {
                Console.WriteLine("{0:F2}", (firstDigit + middleDigit) * lastDigit);
            }
        }
    }
}
