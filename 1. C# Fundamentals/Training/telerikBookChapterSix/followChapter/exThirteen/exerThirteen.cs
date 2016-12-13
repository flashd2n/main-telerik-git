using System;

namespace exThirteen
{
    class exerThirteen
    {
        static void Main()
        {

            string binary = Console.ReadLine();
            int decimalBase = 1;
            int finalDecimal = 0;

            for (int i = 0; i <= binary.Length - 1; i++)
            {
                char value = binary[binary.Length - 1 - i];
                if (value == 48)
                {
                    continue;
                }
                decimalBase = (int)Math.Pow(2, i);
                finalDecimal += decimalBase;
            }
            Console.WriteLine(finalDecimal);
        }
    }
}
