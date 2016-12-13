using System;
using System.Text;

namespace taskSixteen
{
    class taskSixteen
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var output = new StringBuilder(input.Length);
            output.Append(input);

            int cycles = GetCycles(input);

            for (int i = 0; i < cycles; i++)
            {
                output = SwapTags(output);
            }

            Console.WriteLine(output);
        }


        static StringBuilder SwapTags(StringBuilder output)
        {
            output = output.Replace("<a href=\"", "[URL=");
            output = output.Replace("\">", "]");
            output = output.Replace("</a>", "[/URL]");
            return output;
        }

        static int GetCycles(string input)
        {
            int result = 0;
            int index = input.IndexOf("</a>");

            while (index != -1)
            {
                ++result;
                index = input.IndexOf("</a>", index + 1);
            }
            return result;
        }



    }
}
