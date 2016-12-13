using System;
using System.Collections.Generic;

namespace taskSix
{
    class taskSix
    {
        static List<string> tags = new List<string>() { "<upcase>", "</upcase>" };

        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(ModifyString(input));

        }

        static string ModifyString(string input)
        {
            int indexOpen = input.IndexOf(tags[0]);
            int indexClose = 0;
            string subString = null;
            int tempIndex = 0;

            while (indexOpen != -1)
            {
                indexClose = input.IndexOf(tags[1], indexOpen + 1);
                tempIndex = input.IndexOf(tags[0], indexOpen + 1);
                if (tempIndex < indexClose && tempIndex != -1)
                {
                    indexOpen = tempIndex;
                }
                subString = GetSubstring(input, indexOpen, indexClose);
                input = ExecuteTags(input, indexOpen, subString);
                indexOpen = input.IndexOf(tags[0], indexOpen + 1);
            }

            return input;
        }

        static string ExecuteTags(string input, int indexOpen, string subString)
        {
            input = input.Remove(indexOpen, tags[0].Length + subString.Length + tags[1].Length);
            input = input.Insert(indexOpen, subString.ToUpper());
            return input;
        }

        static string GetSubstring(string input, int indexOpen, int indexClose)
        {
            int subStringLength = indexClose - (indexOpen + tags[0].Length);
            string subString = input.Substring(indexOpen + tags[0].Length, subStringLength);
            return subString;
        }
    }
}
