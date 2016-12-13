using System;

namespace exThree
{
    class exerThree
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int biggestNumber;

            if (a > b)
            {
                biggestNumber = a;
                if (b > c)
                {
                    Console.WriteLine(biggestNumber);
                }
                else
                {
                    if (a > c)
                    {
                        Console.WriteLine(biggestNumber);
                    }
                    else
                    {
                        biggestNumber = c;
                        Console.WriteLine(biggestNumber);
                    }
                }
            }
            else
            {
                biggestNumber = b;
                if (b > c)
                {
                    Console.WriteLine(biggestNumber);
                }
                else
                {
                    biggestNumber = c;
                    Console.WriteLine(biggestNumber);
                }
            }
        }
    }
}
