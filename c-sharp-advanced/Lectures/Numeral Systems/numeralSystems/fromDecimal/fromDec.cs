using System;
namespace fromDecimal
{
    class fromDec
    {
        static string FromDecTo(int value, int numberalBase)
        {
            string result = "";

            while (value > 0)
            {
                int digit = value % numberalBase;
                value /= numberalBase;

                result = digit + result;
            }


            return result;
        }

        static string DecToHex(int value)
        {
            string result = "";

            string hexDigits = "0123456789ABCDEF";

            while (value > 0)
            {
                int digitValue = value % 16;
                char digit = hexDigits[digitValue];
                value /= 16;

                result = digit + result;
            }


            return result;
        }


        static void Main()
        {

            Console.WriteLine(FromDecTo(13, 2));
        }
    }
}
