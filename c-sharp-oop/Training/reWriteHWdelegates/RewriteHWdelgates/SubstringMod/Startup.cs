using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringMod
{
    class Startup
    {
        static void Main()
        {
            var testStringbuilder = new StringBuilder();

            testStringbuilder.Append("let's see just how well this works");

            var substring = testStringbuilder.Substring(0, 5);

            Console.WriteLine(substring);
        }
    }
}
