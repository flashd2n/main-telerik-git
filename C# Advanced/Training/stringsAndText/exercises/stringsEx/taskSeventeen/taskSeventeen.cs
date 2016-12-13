using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskSeventeen
{
    class taskSeventeen
    {
        static void Main()
        {
            Console.Write("Enter the first date: ");
            var inputA = Console.ReadLine();
            var separator = new char[] { '.'};
            var tempA = inputA.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var dateA = new StringBuilder();
            dateA.Append(tempA[1] + '.');
            dateA.Append(tempA[0] + '.');
            dateA.Append(tempA[2]);



            Console.Write("Enter the second date: ");
            var inputB = Console.ReadLine();
            var tempB = inputB.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var dateB = new StringBuilder();
            dateB.Append(tempB[1] + '.');
            dateB.Append(tempB[0] + '.');
            dateB.Append(tempB[2]);



            var dateOne = DateTime.Parse(dateA.ToString());
            var dateTwo = DateTime.Parse(dateB.ToString());

            Console.WriteLine("{0}{1:dd}", "Distance: ", dateOne - dateTwo);

        }
    }
}
