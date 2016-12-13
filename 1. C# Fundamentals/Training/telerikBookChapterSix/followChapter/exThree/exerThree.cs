using System;

namespace exThree
{
    class exerThree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers?");
            int n = int.Parse(Console.ReadLine());
            int minNum = int.MinValue;
            int maxNum = int.MaxValue;


            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter number {0}", i);
                int m = int.Parse(Console.ReadLine());

                if (m < minNum)
                {
                    minNum = m;
                }
                if (m > maxNum)
                {
                    maxNum = m;
                }
            }
            Console.WriteLine("The biggest number is {0}", maxNum);
            Console.WriteLine("The smallest number is {0}", minNum);
        }
    }
}
