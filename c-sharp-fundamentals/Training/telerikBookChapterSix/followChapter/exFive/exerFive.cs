using System;

namespace exFive
{
    class exerFive
    {
        static void Main()
        {

            //Fibo Sequence
            int n = int.Parse(Console.ReadLine());

            int first = 0;
            int second = 1;
            int third = 1;
            int fibo;
            int totalSum = 0;

            if (n < 4)
            {
                switch (n)
                {
                    case 0:
                        Console.WriteLine("Invalid input");
                        break;
                    case 1:
                        //Console.Write("{0}", first);
                        Console.WriteLine(first);
                        break;
                    case 2:
                        //Console.Write("{0}, {1}", first, second);
                        Console.WriteLine(first + second);
                        break;
                    case 3:
                        //Console.Write("{0}, {1}, {2}", first, second, third);
                        Console.WriteLine(first + second + third);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                for (int i = 4; i <= n; i++)
                {


                    //if (i == 1)
                    //{
                    //    Console.Write("{0}, ", first);
                    //    continue;
                    //}
                    //else if (i == 2)
                    //{
                    //    Console.Write("{0}, ", second);
                    //    continue;
                    //}
                    //else if (i == 3)
                    //{
                    //    Console.Write("{0}, ", third);
                    //}
                    //else
                    //{
                    //    fibo = second + third;
                    //    Console.Write("{0}, ", fibo);

                    //    second = third;
                    //    third = fibo;
                    //}
                    if (i == 4)
                    {
                        totalSum = first + second + third;
                    }
                    

                    fibo = second + third;
                    totalSum = totalSum + fibo;
                    //Console.Write("{0}, ", fibo);

                    second = third;
                    third = fibo;

                }

                Console.WriteLine(totalSum);
            }
        }
    }
}
