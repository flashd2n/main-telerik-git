using System;

namespace mmsaOfNnumbers
{
    class mmsa
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double[] values = new double[n];

            for (int i = 0; i < n; i++)
            {
                values[i] = double.Parse(Console.ReadLine());
            }

            // get the smallest number

            double smallest = double.MaxValue;

            foreach (double currentNum in values)
            {
                if (currentNum < smallest)
                {
                    smallest = currentNum;
                }
            }

            // get the biggest number

            double biggest = double.MinValue;

            foreach (double currentNum in values)
            {
                if (currentNum > biggest)
                {
                    biggest = currentNum;
                }
            }

            // get the sum

            double sum = 0;

            foreach (double currentNum in values)
            {
                sum += currentNum;
            }

            // get the average

            double average = sum / n;

            Console.WriteLine("min={0:F2}", smallest);
            Console.WriteLine("max={0:F2}", biggest);
            Console.WriteLine("sum={0:F2}", sum);
            Console.WriteLine("avg={0:F2}", average);
        }
    }
}
