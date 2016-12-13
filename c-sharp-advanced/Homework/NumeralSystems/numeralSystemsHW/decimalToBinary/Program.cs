using System;

namespace decimalToBinary
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int remainder = 0;
            int binary = 0;
            string result = null;

            while (input != 0)
            {

                remainder = input / 2;
                binary = input % 2;
                input = remainder;
                result = binary + result;
            }
            
                Console.WriteLine(result.PadLeft(32, '0'));
            

        }
    }
}
