using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intHex
{
    class intH
    {
        static void Main(string[] args)
        {
            int? one = null;
            double? two = null;

            Console.WriteLine(one.HasValue);
            Console.WriteLine(two.HasValue);

            int three = 45;
            double four = 21.54512D;

            three = one.GetValueOrDefault();
            four = two.GetValueOrDefault();
            Console.WriteLine(three);
            Console.WriteLine(four);


        }
    }
}
