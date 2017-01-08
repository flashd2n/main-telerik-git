using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestString
{
    class Startup
    {
        static void Main()
        {
            var array = new string[] { "Telerik", "Academy", "LINQ", "System", "Collections", "Threading" };

            var temp = from str in array
                         orderby str.Length descending
                         select str;

            var result = temp.First();

            Console.WriteLine(result);
        }
    }
}
