using System;

namespace substringInText
{
    class subStringText
    {
        static void Main()
        {
            string pattern = Console.ReadLine();
            string input = Console.ReadLine();

            Console.WriteLine(CheckOccurences(pattern, input));
        }

        static int CheckOccurences(string pattern, string input)
        {
            int result = 0;
            int index = 0;

            index = input.IndexOf(pattern, StringComparison.CurrentCultureIgnoreCase);

            while (index != -1)
            {
                ++result;

                index = input.IndexOf(pattern, index + 1, StringComparison.CurrentCultureIgnoreCase);          
            }

            return result;
        }
    }
}
