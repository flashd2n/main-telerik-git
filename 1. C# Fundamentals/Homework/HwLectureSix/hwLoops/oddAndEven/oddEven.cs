using System;
using System.Numerics;

namespace oddAndEven
{
    class oddEven
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] arrayNumbers = new int[n];
            string input = Console.ReadLine();
            string tempSwitch = null;
            int tempNumber = 0;
            int counterForIntArray = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 32)
                {
                    tempNumber = Convert.ToInt32(tempSwitch, 10);
                    arrayNumbers[counterForIntArray] = tempNumber;


                    tempSwitch = null;
                    ++counterForIntArray;
                    continue;
                }

                tempSwitch += input[i];

                if (i == (input.Length - 1))
                {
                    tempNumber = Convert.ToInt32(tempSwitch, 10);
                    arrayNumbers[counterForIntArray] = tempNumber;
                }
            }

            // tuk ve4e imam 4islata v array kato int

            BigInteger productOdd = 1;
            BigInteger productEven = 1;

            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    productEven *= arrayNumbers[i];
                }
                else
                {
                    productOdd *= arrayNumbers[i];
                }
            }

            if (productOdd == productEven)
            {
                Console.WriteLine("yes {0}", productOdd);
            }
            else
            {
                Console.WriteLine("no {0} {1}", productEven, productOdd);
            }




        }
    }
}
