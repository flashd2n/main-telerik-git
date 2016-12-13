using System;
using System.Collections.Generic;

namespace tastTwentyTwo
{
    class taskTwentyTwo
    {
        static void Main()
        {
            string input = Console.ReadLine();
            input = input.ToLower();
            var chars = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {

                if (Char.IsLetter(input[i]) == true)
                {
                    chars.Add(input[i]);
                }
            }

            chars.Sort();

            var occurences = new List<int>();
            var uniqueChars = new List<char>();

            int counter = 1;

            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i] == chars[i + 1] && (i == chars.Count - 2))
                {
                    ++counter;
                    occurences.Add(counter);
                    uniqueChars.Add(chars[i]);
                    break;
                }
                else if (chars[i] != chars[i + 1] && (i == chars.Count - 2))
                {
                    occurences.Add(counter);
                    uniqueChars.Add(chars[i]);
                    counter = 1;
                    occurences.Add(counter);
                    uniqueChars.Add(chars[i + 1]);
                    break;
                }

                if (chars[i] == chars[i + 1])
                {
                    ++counter;
                }
                else
                {
                    occurences.Add(counter);
                    uniqueChars.Add(chars[i]);
                    counter = 1;
                }
            }

            for (int i = 0; i < occurences.Count; i++)
            {
                Console.WriteLine("Char {0} - Times {1}", uniqueChars[i], occurences[i]);
            }

        }
    }
}
