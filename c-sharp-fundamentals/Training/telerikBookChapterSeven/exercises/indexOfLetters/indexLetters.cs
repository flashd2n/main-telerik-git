using System;

namespace indexOfLetters
{
    class indexLetters
    {
        static void Main()
        {
            char[] letters = new char[26];

            for (int i = 0; i < 26; i++)
            {
                letters[i] = (char)(97 + i);
            }

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (input[i] == letters[j])
                    {
                        Console.WriteLine(j);
                        break;
                    }
                }
            }
        }
    }
}
