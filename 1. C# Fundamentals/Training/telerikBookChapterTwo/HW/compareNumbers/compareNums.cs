using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compareNumbers
{
    class compareNums
    {
        static void Main(string[] args)
        {
            double numberOne = 231.21547547D;
            double numberTwo = 231.21547557D;

            bool compareNums = Math.Abs(numberOne - numberTwo) < 0.000001;

            Console.WriteLine(compareNums);

        }
    }
}
