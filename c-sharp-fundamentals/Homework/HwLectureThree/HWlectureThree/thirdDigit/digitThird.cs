using System;

namespace thirdDigit
{
    class digitThird
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int d = n / 100;
            int thirdDigit = d % 10;

            if (thirdDigit == 7)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false " + thirdDigit);
            }
        }
    }
}
