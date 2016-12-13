using System;
using System.Collections.Generic;

namespace extractSentences
{
    class extrSent
    {
        static void Main()
        {
            string keyWord = Console.ReadLine();
            string text = Console.ReadLine();
            string[] separator = new string[] { ". ", "." };

            string[] sentences = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> hasKeyWord = new List<string>();

            for (int i = 0; i < sentences.Length; i++)
            {
                int indexKeyWord = sentences[i].IndexOf(keyWord);

                while (indexKeyWord != -1)
                {
                    char before;
                    char after;
                    if (indexKeyWord == 0)
                    {
                        after = sentences[i][indexKeyWord + keyWord.Length];
                        if (indexKeyWord != -1 && !Char.IsLetter(after))
                        {
                            hasKeyWord.Add(sentences[i]);
                            break;
                        }
                    }
                    else if (indexKeyWord == (sentences[i].Length - keyWord.Length))
                    {
                        before = sentences[i][indexKeyWord - 1];
                        if (indexKeyWord != -1 && !Char.IsLetter(before))
                        {
                            hasKeyWord.Add(sentences[i]);
                            break;
                        }
                    }
                    else
                    {
                        before = sentences[i][indexKeyWord - 1];
                        after = sentences[i][indexKeyWord + keyWord.Length];
                        if (indexKeyWord != -1 && !Char.IsLetter(before) && !Char.IsLetter(after))
                        {
                            hasKeyWord.Add(sentences[i]);
                            break;
                        }
                    }
                    

                    indexKeyWord = sentences[i].IndexOf(keyWord, indexKeyWord + 1);

                }
            }
            string output = string.Join(". ", hasKeyWord);

            Console.WriteLine(output + ".");
        }
    }
}
