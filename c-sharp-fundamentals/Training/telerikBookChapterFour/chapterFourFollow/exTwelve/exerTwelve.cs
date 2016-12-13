using System;

namespace exTwelve
{
    class exerTwelve
    {
        static void Main(string[] args)
        {
            const double precision = 0.001D;

            double initiation = 1;
            double sumOne;
            double sumTwo;
            int i = 2;

            do
            {
                
                int mask = i % 2 == 0 ? i : i * -1;
                i++;

                double nextNumber = (1D / mask);

                sumOne = initiation + nextNumber;

                mask = i % 2 == 0 ? i : i * -1;
                i++;

                double nextNumberTwo = (1D / mask);

                sumTwo = sumOne + nextNumberTwo;

                initiation = sumTwo;


            } while (Math.Abs(sumOne - sumTwo) > precision);

            Console.WriteLine(sumTwo);
        }
    }
}