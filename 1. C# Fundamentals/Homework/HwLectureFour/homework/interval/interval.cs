using System;

namespace interval
{
    class interval
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = n + 1; i < m; i++)
            {

                switch (i % 5)
                {
                    case 0:
                        ++result;
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(result);

        }
    }
}
