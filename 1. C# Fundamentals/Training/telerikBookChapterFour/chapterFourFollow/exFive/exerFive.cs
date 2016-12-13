using System;

namespace exFive
{
    class exerFive
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a == b)
            {
                Console.WriteLine("Please enter different numbers");
            }
            else
            {
                if (a > b)
                {
                    for (int i = b; i < (a+1); i++)
                    {
                        if (i % 5 == 0)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
                else
                {
                    for (int i = a; i < (b + 1); i++)
                    {
                        if (i % 5 == 0)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }

        }
    }
}
