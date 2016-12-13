using System;

namespace exTen
{
    class exerTen
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < n + i; j++)
                {
                    Console.Write("{0,2:} ", j);
                }
                Console.WriteLine("");

            }


        }
    }
}
