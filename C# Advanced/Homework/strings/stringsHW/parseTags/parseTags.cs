using System;
using System.Collections.Generic;

namespace parseTags
{
    class parseTags
    {
        static List<string> tags = new List<string>() { "<upcase>", "</upcase>" };

        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(ModifyInput(input));
        }

        static string ModifyInput(string input)
        {
            int indexOpen = input.IndexOf(tags[0]);
            int indexClose = 0;
            int tempIndex = 0;
            string subString = null;

            while (indexOpen != -1)
            {
                tempIndex = input.IndexOf(tags[0], indexOpen + 1);
                indexClose = input.IndexOf(tags[1], indexOpen + 1);

                while (tempIndex < indexClose)
                {
                    indexOpen = tempIndex;
                    tempIndex = input.IndexOf(tags[0], indexOpen + 1);
                }

                subString = ExtractSubstring(input, indexOpen, indexClose);
                input = ExecuteTags(input, indexOpen, subString);
                indexOpen = input.IndexOf(tags[0], indexOpen + 1);
            }

            return input;
        }

        static string ExecuteTags(string input, int indexOpen, string subString)
        {
            input = input.Remove(indexOpen, tags[0].Length + tags[1].Length + subString.Length);
            input = input.Insert(indexOpen, subString.ToUpper());
            return input;
        }

        static string ExtractSubstring(string input, int indexOpen, int indexClose)
        {
            int substringLength = indexClose - (indexOpen + tags[0].Length);
            string subString = input.Substring(indexOpen + tags[0].Length, substringLength);

            return subString;
        }
    }
}
