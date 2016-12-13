using System;

namespace exSix
{
    class exerSix
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());


            int factorialN = 1;
            int factorialK = 1;

            for (int i = n; i > 0; i--)
            {
                factorialN *= i;
            }
            Console.WriteLine("Factorial N = " + factorialN);
            for (int j = k; j > 0; j--)
            {
                factorialK *= j;
            }
            Console.WriteLine("Factorial K = " + factorialK);


            Console.WriteLine("The final answer is {0}", (factorialN / factorialK));

        }
    }
}
