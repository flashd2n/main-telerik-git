using System;

namespace numberComparer
{
    class numCompare
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine(((a + b) + Math.Abs(a - b)) / 2);


        }
    }
}
