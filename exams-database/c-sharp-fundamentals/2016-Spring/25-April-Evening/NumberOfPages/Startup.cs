using System;

namespace NumberOfPages
{
    class Startup
    {
        static void Main()
        {
            uint numberOfDigits = uint.Parse(Console.ReadLine());
            uint pages = 0;

            while (numberOfDigits > 0)
            {
                if (pages < 9)
                {
                    ++pages;
                    --numberOfDigits;
                }
                else if (pages >= 9 && pages < 99)
                {
                    ++pages;
                    numberOfDigits -= 2;
                }
                else if (pages >= 99 && pages < 999)
                {
                    ++pages;
                    numberOfDigits -= 3;
                }
                else if (pages >= 999 && pages < 9999)
                {
                    ++pages;
                    numberOfDigits -= 4;
                }
                else if (pages >= 9999 && pages < 99999)
                {
                    ++pages;
                    numberOfDigits -= 5;
                }
                else if (pages >= 99999 && pages <= 999999)
                {
                    ++pages;
                    numberOfDigits -= 6;
                }
            }

            Console.WriteLine(pages);
        }
    }
}
