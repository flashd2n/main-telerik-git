using System;
using System.Threading;
using System.Globalization;

namespace followChapter
{
    class bigAssOut
    {
        static void Main(string[] args)
        {

            Console.WriteLine("INDENTATION STARTS HERE");

            Console.WriteLine("{0, 6}", 1234567);
            Console.WriteLine("{0, 6}", 123456);
            Console.WriteLine("{0, 6}", 12345);
            Console.WriteLine("{0, 6}", 123);
            Console.WriteLine("{0, 6}", 12);
            Console.WriteLine("{0, 6}", 1);
            Console.Write("{0, -6}", 1234);
            Console.WriteLine("end");

            Console.WriteLine("NUMBERS STARTS HERE");

            Console.WriteLine("{0:C4} {1:C4}", 40.15, 35); // currency
            Console.WriteLine("{0:D4}", 234); // integer -> puts zeroes of not enough numbers
            Console.WriteLine("{0:E4}", 541); // exponential notation no idea
            Console.WriteLine("{0:F2}", 213.23623523); //integer or decimal -> precision after decimal point -> adds zeroes if not enough numbers, else ROUNDS the number
            Console.WriteLine("{0:F2}", 213.2); // see above
            Console.WriteLine("{0:N2}", 81756.17777); //same as F, but adds comma separation for thousands, millions, etc...
            Console.WriteLine("{0:P4}", 0.5); // multiplies the number by 100 and adds % mark...default is 2 precision after decimal point, but can be changed
            Console.WriteLine("{0:X5}", 254); // represents the number i hexadecimal...precision adds zeroes infront, if necessary

            Console.WriteLine("{0:0.000}", 231); // equal to 0:F3
            Console.WriteLine("{0:#.###}", 23.12377); // same as 0:F3, but it does not add zeroes - maybe better for simple rounding...maybe not
            Console.WriteLine("{0:###}", 9876); // useful when you do not want decimal point and rounds up
            Console.WriteLine("{0:###}", 9876.55555); // se above
            Console.WriteLine("{0:(0##) ### ## #}", 29784243); // can be used for formating phone numbers -> it checks the numbers from back to front
            Console.WriteLine("{0:%#}", 0.237); // some wierd ass percertage...better use 0:X

            Console.WriteLine("DATES START HERE");
            DateTime current = DateTime.Now;
            Console.WriteLine(current);
            Console.WriteLine("{0:d}", current);
            Console.WriteLine("{0:D}", current);
            Console.WriteLine("{0:t}", current);
            Console.WriteLine("{0:T}", current);
            Console.WriteLine("{0:Y}", current);

            Console.WriteLine("{0:dd/MM/yyyy}", current);
            Console.WriteLine("{0:dd/MM/yyyy HH:mm:ss}", current);

            Console.WriteLine("ENUMERATION STARTS HERE");

            Console.WriteLine("{0:D}", DayOfWeek.Wednesday);
            Console.WriteLine("{0:G}", DayOfWeek.Wednesday);
            Console.WriteLine("{0:X}", DayOfWeek.Wednesday); // hexadecimal with 8 digits (8 bits)

            Console.WriteLine("LOCALIZATION STARTS HERE");
            // add system.threading and system.globalization

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
            Console.WriteLine("{0:C2}", 500);



        }
    }
}
