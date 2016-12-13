using System;
using System.Collections.Generic;

namespace taskTen
{
    class taskTen
    {
        static List<string> result = new List<string>();

        static void Main()
        {
            string keyWord = Console.ReadLine();
            string input = Console.ReadLine();
            var separator = new string[] { ". ", "." };
            var sentences = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentences.Length; i++)
            {
                char before;
                char after;
                int index = sentences[i].IndexOf(keyWord);

                while (index != -1)
                {
                    if (index == 0)
                    {
                        after = sentences[i][index + keyWord.Length];

                        if (index != -1 && !Char.IsLetter(after))
                        {
                            result.Add(sentences[i]);
                            break;
                        }
                    }
                    else if (index == (sentences[i].Length - keyWord.Length))
                    {
                        before = sentences[i][index - 1];

                        if (index != -1 && !Char.IsLetter(before))
                        {
                            result.Add(sentences[i]);
                            break;
                        }
                    }
                    else
                    {
                        before = sentences[i][index - 1];
                        after = sentences[i][index + keyWord.Length];

                        if (index != -1 && !Char.IsLetter(before) && !Char.IsLetter(after))
                        {
                            result.Add(sentences[i]);
                            break;
                        }
                    }

                    index = sentences[i].IndexOf(keyWord, index + 1);
                }
            }
            if (result.Count > 0)
            {
                result[result.Count - 1] += ".";
            }

            Console.WriteLine(string.Join(". ", result));

        }
    }
}
