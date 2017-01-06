using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderTask
{
    class Startup
    {
        static void Main(string[] args)
        {
            // Testing with Substing method in StringBuilder class
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello Telerik Academy");
            Console.WriteLine(sb.Substring(3, 9));
        }
    }
}