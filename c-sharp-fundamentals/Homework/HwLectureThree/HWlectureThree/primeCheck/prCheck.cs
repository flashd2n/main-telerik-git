using System;

namespace primeCheck
{
    class prCheck
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number <= 1)
            {
                Console.WriteLine("false");
            }
            else
            {
                if ((number == 2) || (number == 3) || (number == 5) || (number == 7))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    if (((number % 2 == 0) || (number % 3 == 0)) || ((number % 5 == 0) || (number % 7 == 0)))
                    {
                        Console.WriteLine("false");
                    }
                    else
                    {
                        Console.WriteLine("true");
                    }
                }
            }
        }
    }
}
