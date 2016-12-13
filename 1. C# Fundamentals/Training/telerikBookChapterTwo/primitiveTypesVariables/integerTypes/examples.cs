using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integerTypes
{
    class examples
    {
        static void Main(string[] args)
        {
            int i = 5;
            int? ni = i;

            Console.WriteLine(ni);

            Console.WriteLine(ni.HasValue);

            i = ni.Value;

            Console.WriteLine(i);

            ni = null;

            Console.WriteLine(ni.HasValue);

            i = ni.GetValueOrDefault();

            Console.WriteLine(i);

            float number = 12.5F;

            Console.WriteLine(number);

            char someChar = '\u0077';

            Console.WriteLine(someChar);

            Console.WriteLine("doing something different");

            char anotherChar = 'a';

            Console.WriteLine(anotherChar);

            anotherChar = '\'';

            Console.WriteLine(anotherChar);

            anotherChar = '\\';

            Console.WriteLine(anotherChar);


        }
    }
}
