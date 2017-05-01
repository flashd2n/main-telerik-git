using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertPlay
{
    class Startup
    {
        static void Main(string[] args)
        {
            int a = 7;


            Debug.Assert(a > 8, "Assert is fired");

        }
    }
}
