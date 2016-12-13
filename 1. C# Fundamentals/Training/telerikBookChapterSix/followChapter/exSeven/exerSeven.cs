using System;

namespace exSeven
{
    class exerSeven
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int nK = n - k;

            int factorialN = 1;
            int factorialK = 1;
            int factorialNK = 1;

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

            for (int z = nK; z > 0; z--)
            {
                factorialNK *= z;
            }


            int result = (factorialN * factorialK) / factorialNK;


            Console.WriteLine("The final answer is {0}", result);


        }
    }
}
