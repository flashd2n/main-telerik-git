using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    class Startup
    {
        static void Main()
        {
            string testing = "Hello, this is my first extension method!";
            int count = testing.WordCount();
            Console.WriteLine(count);

            Console.WriteLine("=====");

            var myList = new List<int>() { 1, 2, 3, 4, 5, 6};
            myList.IncreaseWith(3);
            Console.WriteLine(string.Join("-", myList));

            Console.WriteLine(myList.ToString<int>());
        }
    }
}
