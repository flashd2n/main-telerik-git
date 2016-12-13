using System;

namespace exEleven
{
    class exerEleven
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int zeroCount = 0;

            const int fives = 5;
            int fiveSquare = 1;

            while (n > fiveSquare)
            {
                fiveSquare *= fives;
                if (n <= fiveSquare)
                {
                    break;
                }
                zeroCount += n / fiveSquare;
            }
            Console.WriteLine(zeroCount);
        }
    }
}
