using System;

namespace fibonacci
{
    class fibo
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int first = 0;
            long second = 1;
            long third = 1;

            switch (n)
            {
                case 1 :

                    Console.WriteLine(first);

                    break;
                case 2:

                    Console.WriteLine("0, 1");

                    break;
                case 3:

                    Console.WriteLine("0, 1, 1");

                    break;
                default:

                    Console.Write("0, 1, 1");

                    for (int i = 3; i < n; i++)
                    {

                        long nextNumber = second + third;

                        second = third;
                        third = nextNumber;

                        Console.Write(", {0}", nextNumber);
                    }

                    break;
            }
        }
    }
}
