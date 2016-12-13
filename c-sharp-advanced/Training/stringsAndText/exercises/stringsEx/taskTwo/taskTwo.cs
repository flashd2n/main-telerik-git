using System;
using System.Text;

namespace taskTwo
{
    class taskTwo
    {
        static void Main()
        {

            string input = Console.ReadLine();

            Console.WriteLine(ReverseString(input));

        }

        static string ReverseString(string input)
        {
            var result = new StringBuilder(input.Length);
            for (int i = input.Length - 1 ; i >= 0; i--)
            {
                result.Append(input[i]);
            }

            return result.ToString();
        }
    }
}
