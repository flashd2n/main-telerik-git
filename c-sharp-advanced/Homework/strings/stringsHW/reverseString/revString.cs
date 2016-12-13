using System;
using System.Text;

namespace reverseString
{
    class revString
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(ReverseString(input));
        }

        static string ReverseString(string input)
        {
            var result = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.Append(input[i]);
            }
            return result.ToString();
        }
    }
}
