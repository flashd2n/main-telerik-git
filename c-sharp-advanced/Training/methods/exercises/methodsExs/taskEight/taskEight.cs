using System;
using System.Linq;
using System.Numerics;

namespace taskEight
{
    class taskEight
    {
        static void Main()
        {
            var arrayOne = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arrayTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(GetSum(arrayOne, arrayTwo));
        }

        static BigInteger GetSum (int[] arrayOne, int[] arrayTwo)
        {
            string numberOne = null;
            string numberTwo = null;
            for (int i = 0; i < arrayOne.Length; i++)
            {

                numberOne = arrayOne[i].ToString() + numberOne;

            }
            BigInteger nOne = BigInteger.Parse(numberOne);
            for (int i = 0; i < arrayTwo.Length; i++)
            {

                numberTwo = arrayTwo[i].ToString() + numberTwo;

            }
            BigInteger nTwo = BigInteger.Parse(numberTwo);

            BigInteger sum = nOne + nTwo;
            return sum;
        }

    }
}
