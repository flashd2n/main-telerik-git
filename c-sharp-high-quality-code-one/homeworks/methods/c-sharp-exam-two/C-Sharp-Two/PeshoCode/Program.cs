using System;
using System.Text;

namespace peshoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            var text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                text.Append(Console.ReadLine());
            }

            // imam celiq text kato string
            string myText = text.ToString();

            int indexKeyword = myText.IndexOf(keyword);
            int nextPeriod = 0;
            int nextQuestion = 0;
            int indexCap = 0;
            string substring = null;

            nextPeriod = myText.IndexOf('.', indexKeyword);
            nextQuestion = myText.IndexOf('?', indexKeyword);

            if (nextQuestion == -1)
            {
                nextQuestion = int.MaxValue;
            }
            if (nextPeriod == -1)
            {
                nextPeriod = int.MaxValue;
            }

            if (nextPeriod < nextQuestion) // az sum v statement
            {

                for (int j = indexKeyword; true; j--)
                {
                    if (myText[j] >= 65 && myText[j] <= 90)
                    {
                        indexCap = j;
                        break;
                    }
                }

                substring = myText.Substring(indexCap, indexKeyword - indexCap);
            }
            else // az sum v question
            {
                int indexStart = indexKeyword + keyword.Length;

                substring = myText.Substring(indexStart, nextQuestion - indexStart);
            }

            int result = 0;

            foreach (var c in substring)
            {
                if (c == ' ')
                {
                    continue;
                }

                result += Char.ToUpper(c);
            }

            Console.WriteLine(result);
        }
    }
}