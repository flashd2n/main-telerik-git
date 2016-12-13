using System;
using System.Numerics;

namespace examples
{
    class exampls
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //for (int row = 1; row <= n; row++)
            //{
            //    for (int col = 1; col <= row; col++)
            //    {
            //        Console.Write("{0} ", col);
            //    }
            //    Console.WriteLine("");
            //}

            //int m = int.Parse(Console.ReadLine());

            //for (int num = n; num <= m; num++)
            //{

            //    bool isPrime = true;

            //    for (int divider = 2; divider <= (int)Math.Sqrt(num); divider++)
            //    {
            //        if (num % divider == 0)
            //        {
            //            isPrime = false;
            //            break;
            //        }
            //        divider++;
            //    }

            //    //while (divider <= maxDivider)
            //    //{

            //    //    if (num % divider == 0)
            //    //    {
            //    //        isPrime = false;
            //    //        break;
            //    //    }
            //    //    divider++;
            //    //}

            //    if (isPrime)
            //    {
            //        Console.WriteLine(num);
            //    }
            //}

            //int d;

            //for (int a = 1; a <= 9; a++)
            //{
            //    for (int b = 0; b <= 9; b++)
            //    {
            //        for (int c = 0; c <= 9; c++)
            //        {

            //            d = (a + b) - c;
            //            if (d <= 9 && d >= 1)
            //            {
            //                if ((a + b) == (c + d))
            //                {
            //                    Console.WriteLine("{0}{1}{2}{3}", a, b, c, d);
            //                }
            //            }
            //        }
            //    }
            //}

            BigInteger counter = 0;

            for (int i1 = 1; i1 < 44; i1++)
            {
                for (int i2 = i1 + 1; i2 < 45; i2++)
                {
                    for (int i3 = i2 + 1; i3 < 46; i3++)
                    {
                        for (int i4 = i3 + 1; i4 < 47; i4++)
                        {
                            for (int i5 = i4 + 1; i5 < 48; i5++)
                            {
                                for (int i6 = i5 + 1; i6 < 49; i6++)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);





        }
    }
}
