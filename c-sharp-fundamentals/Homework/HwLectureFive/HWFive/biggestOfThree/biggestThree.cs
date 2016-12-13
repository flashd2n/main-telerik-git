using System;

namespace biggestOfThree
{
    class biggestThree
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());

            double bigOne = Math.Max(a, b);
            double bigTwo = Math.Max(c, d);
            double bigThree = Math.Max(bigOne, bigTwo);
            double final = Math.Max(bigThree, e);

            Console.WriteLine(final);




        }
    }
}
