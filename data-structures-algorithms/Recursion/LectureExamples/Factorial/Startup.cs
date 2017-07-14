using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    public class Startup
    {
        static void Main()
        {

            Console.WriteLine(CalculateFactorial(5));

        }

        public static int CalculateFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * CalculateFactorial(n - 1); 

        }
    }
}
