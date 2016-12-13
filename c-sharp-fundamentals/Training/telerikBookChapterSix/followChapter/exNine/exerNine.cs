using System;

namespace exNine
{
    class exerNine
    {
        static void Main()
        {
            //Console.WriteLine("Enter n");
            double n = double.Parse(Console.ReadLine());
            //Console.WriteLine("Enter x");
            double x = double.Parse(Console.ReadLine());
            double factorialN = 1;
            double xSquare = x;
            double sum = 1;


            //SOLUTION WITH TWO LOOPS
            //for (double i = 0; i <= n; i++)
            //{
            //    if (i == 0)
            //    {
            //        factorialN = 0;
            //    }
            //    for (double j = i; j > 0; j--)
            //    {
            //        factorialN *= j;
            //        xSquare *= x;
            //    }                
            //    sum = sum + (factorialN / xSquare);
            //    factorialN = 1;
            //    xSquare = 1;
            //}
            //Console.WriteLine("{0:F5}", sum);


            sum += (1 / x);

            for (double i = 2; i <= n; i++)
            {
                factorialN *= i;
                xSquare *= x;

                sum += (factorialN / xSquare);

            }

            Console.WriteLine("{0:F5}", sum);



        }
    }
}
