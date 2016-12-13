using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskTwentySix
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var temp = new StringBuilder();
            var result = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '<')
                {
                    if (temp.Length != 0)
                    {
                        result.Add(temp.ToString());
                        temp.Clear();
                    }
                    
                    do
                    {
                        ++i;
                    } while (input[i] != '>');
                    continue;
                }
                temp.Append(input[i]);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
