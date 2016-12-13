using System;
using System.Collections.Generic;

namespace taskTwentyOne
{
    class taskTwentyOne
    {
        static void Main()
        {
            string input = Console.ReadLine();
            char[] separator = new char[] { ' ', '-' };
            var characters = new List<char>();
            var words = ExtractPureWords(input.Split(separator, StringSplitOptions.RemoveEmptyEntries), characters);
            var palindromes = new List<string>();

            palindromes = GetPalindromes(words, palindromes);

            Console.WriteLine(string.Join("\n", palindromes));
        }

        static List<string> GetPalindromes(string[] words, List<string> palindromes)
        {

            foreach (var word in words)
            {
                bool isPalindrome = true;

                for (int i = 0; i < (word.Length / 2); i++)
                {
                    if (word[i] != word[word.Length - 1 - i])
                    {
                        isPalindrome = false;
                    }
                }

                if (isPalindrome)
                {
                    palindromes.Add(word);
                }
            }
            return palindromes;
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
