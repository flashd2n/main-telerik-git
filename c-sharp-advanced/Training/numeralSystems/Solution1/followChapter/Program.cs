using System;

namespace followChapter
{
    class Program
    {
        static void Main()
        {
            int integer = 25;
            int intHex = 0x002A; // moga da store-vam hexadec values direktno v int, za razlika ot binary
            int y = Convert.ToInt32("110111", 2); // covert binary string to int

            Console.WriteLine(intHex);
            Console.WriteLine(y);


            //checked // throws exception if overflow, if not works normally
            //{
            //    int a = int.MaxValue/* - 1*/;
            //    ++a;
            //    Console.WriteLine(a);
            //}


            float b = 0.3F;
            Console.WriteLine(b);
            Console.WriteLine(b + 0.3F + 0.3F);


            float sum = 0.0F;
            for (int i = 0; i < 1000; i++)
            {
                sum += 0.1F;
            }

            Console.WriteLine(sum);
        }
    }
}
