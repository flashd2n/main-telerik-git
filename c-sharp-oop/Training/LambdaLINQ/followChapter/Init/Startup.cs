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
            string testString = "this is my super, duper! awesome? bugged string";
            Console.WriteLine(testString.CountWords());


            Console.WriteLine("===next case====");

            var myList = new List<double>() { 2.3, 3.2, 4.1, 5.3, 6.4 };

            myList.IncreaseBy(5.3);

            Console.WriteLine(string.Join(" - ", myList));

            Console.WriteLine(myList.ToString<double>());

            var myStack = new Stack<int>();
            myStack.Push(4);
            Console.WriteLine(myStack.ToString<int>());

        }
    }
}
