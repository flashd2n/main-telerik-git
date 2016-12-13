using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTwentyThree
{
    class taskTwentyThree
    {
        static void Main()
        {

            string input = Console.ReadLine();
            char[] separator = new char[] { ' ', '-' };
            var characters = new List<char>();
            var words = ExtractPureWords(input.Split(separator, StringSplitOptions.RemoveEmptyEntries), characters);

            Array.Sort(words);

            var occurences = new List<int>();
            var uniqueWords = new List<string>();

            int Lengther = 1;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == words[i + 1] && (i == words.Length - 2))
                {
                    ++Lengther;
                    occurences.Add(Lengther);
                    uniqueWords.Add(words[i]);
                    break;
                }
                else if (words[i] != words[i + 1] && (i == words.Length - 2))
                {
                    occurences.Add(Lengther);
                    uniqueWords.Add(words[i]);
                    Lengther = 1;
                    occurences.Add(Lengther);
                    uniqueWords.Add(words[i + 1]);
                    break;
                }

                if (words[i] == words[i + 1])
                {
                    ++Lengther;
                }
                else
                {
                    occurences.Add(Lengther);
                    uniqueWords.Add(words[i]);
                    Lengther = 1;
                }
            }

            for (int i = 0; i < occurences.Count; i++)
            {
                Console.WriteLine("Word {0} - Times {1}", uniqueWords[i], occurences[i]);
            }

        }

        static string[] ExtractPureWords(string[] words, List<char> characters)
        {
            for (int i = 0; i < words.Length; i++)
            {
                characters.Clear();
                var temp = words[i].ToCharArray();
                characters.AddRange(temp);

                for (int j = 0; j < characters.Count; j++)
                {
                    if (Char.IsLetter(characters[j]) == false)
                    {
                        characters.Remove(characters[j]);
                        j = j - 1;
                    }
                }

                words[i] = string.Join("", characters);
            }
            return words;
        }

    }
}
