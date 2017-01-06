using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestString
{
    class Startup
    {
        static void Main(string[] args)
        {
            var array = new string[] { "Telerik", "Academy", "LINQ", "System", "Collectionssssss", "Threading" };
            string maxLength = array.OrderByDescending(x => x.Length).First();

            Console.WriteLine("The string with max length is: " + maxLength);
        }
    }
}