using System;

namespace sumN
{
    class sumN
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double temp = 0D;
            double tempTwo = 0D;
            double sum = 0D;

            for (int i = 0; i < n; i++)
            {
                temp = double.Parse(Console.ReadLine());

                sum = temp + tempTwo;

                tempTwo = sum;

            }

            Console.WriteLine(sum);

        }
    }
}
