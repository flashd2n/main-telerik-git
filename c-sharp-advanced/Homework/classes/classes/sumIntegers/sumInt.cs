using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace sumIntegers
{
    class sumInt
    {
        static void Main()
        {
            List<BigInteger> numbers = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList(); // vkarvame elementite v list-a
            BigInteger result = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                result += numbers[i];
            }

            Console.WriteLine(result);

        }
    }
}
