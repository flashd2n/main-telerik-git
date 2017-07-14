using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public class Startup
    {
        static void Main()
        {

            Recursion(5);

        }

        public static void Recursion(int steps)
        {
            if (steps <= 0)
            {
                return;
            }
            Console.WriteLine($"Call at {steps}");


            Recursion(steps - 1);
            Console.WriteLine($"Returns at {steps}");
        }
    }
}
