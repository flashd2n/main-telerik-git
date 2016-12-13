using System;
using System.Text;

namespace _08.ExtractSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            // take input values; split sentences, go through each sentence, extract the non-letter chars from that sentence, make them char[] and split that sentence by those char[]. The result is that sentence is split by words.
            // Search the words and if you find the keyword -> append the sentence + trim and append a "." -> move next sentence.


            //input and values
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string[] sentences = text.Split('.');
            StringBuilder temp = new StringBuilder();
            StringBuilder result = new StringBuilder();
            //calculation
            foreach (var sentence in sentences)
            {
                temp.Clear();
                for (int i = 0; i < sentence.Length; i++)
                {
                    if (char.IsLetter(sentence[i]) == false)
                    {
                        temp.Append(sentence[i]); //parse NON-letter symbols
                    }
                }
                char[] splitChars = temp.ToString().ToCharArray();
                string[] words = sentence.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

                if (Array.IndexOf(words, word) > -1)
                {
                    result.Append(sentence.Trim());
                    result.Append(". ");
                }
            }
            //print
            Console.WriteLine(result.ToString().Trim());
        }
    }
}