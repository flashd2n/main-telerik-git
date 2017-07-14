using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bracekts
{
    public class Startup
    {
        static void Main()
        {
            var input = "1 + (2 - (2+3) * 4 / (3+1)) * 5";

            var stack = new Stack<int>();


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    var start = stack.Peek();
                    var len = i + 1 - start;
                    Console.WriteLine(input.Substring(start, len));
                    stack.Pop();
                }
            }

            Console.WriteLine("=============");

            FindBrackets(input, 0);

        }

        public static int FindBrackets(string input, int index)
        {
            if (index >= input.Length)
            {
                return 0;
            }

            if (input[index] == '(')
            {
                var close = FindBrackets(input, index + 1);

                var len = close - index + 1;

                Console.WriteLine(input.Substring(index, len));

                return FindBrackets(input, close + 1);
            }

            if (input[index] == ')')
            {
                return index;
            }

            return FindBrackets(input, index + 1);

        }



    }
}
