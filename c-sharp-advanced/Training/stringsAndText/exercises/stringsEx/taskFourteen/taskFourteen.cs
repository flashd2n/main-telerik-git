using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskFourteen
{
    class taskFourteen
    {
        static void Main()
        {
            string input = Console.ReadLine();
            char[] separators = new char[] { ' ' };
            var words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var output = new StringBuilder(input.Length);

            for (int i = (words.Length - 1); i >= 0; i--)
            {
                output.Append(words[i]);
                output.Append(" ");
            }

            Console.WriteLine(output.ToString());
        }
    }
}
