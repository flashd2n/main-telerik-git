using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskFive
{
    class taskFive
    {
        static void Main()
        {

            string input = Console.ReadLine();
            string keyWord = "in";
            Console.WriteLine(CheckOccurences(input, keyWord));

        }

        static int CheckOccurences(string input, string keyWord)
        {
            int index = input.IndexOf(keyWord, StringComparison.CurrentCultureIgnoreCase);
            int counter = 0;

            while (index != -1)
            {
                ++counter;
                index = input.IndexOf(keyWord, index + 1, StringComparison.CurrentCultureIgnoreCase);
            }

            return counter;
        }
    }
}
