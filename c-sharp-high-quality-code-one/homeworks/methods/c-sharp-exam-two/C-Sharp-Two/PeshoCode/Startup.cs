using System;
using System.Text;

namespace peshoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            int numberOfLines = int.Parse(Console.ReadLine());
            var text = GetText(numberOfLines).ToString();

            int indexKeyword = text.IndexOf(keyword);
            int nextPeriod = 0;
            int nextQuestion = 0;
            int indexCap = 0;
            string substring = null;

            nextPeriod = text.IndexOf('.', indexKeyword);
            nextQuestion = text.IndexOf('?', indexKeyword);

            if (nextQuestion == -1)
            {
                nextQuestion = int.MaxValue;
            }
            if (nextPeriod == -1)
            {
                nextPeriod = int.MaxValue;
            }

            if (nextPeriod < nextQuestion)
            {

                for (int j = indexKeyword; true; j--)
                {
                    if (text[j] >= 65 && text[j] <= 90)
                    {
                        indexCap = j;
                        break;
                    }
                }

                substring = text.Substring(indexCap, indexKeyword - indexCap);
            }
            else
            {
                int indexStart = indexKeyword + keyword.Length;

                substring = text.Substring(indexStart, nextQuestion - indexStart);
            }

            int result = GetCode(substring);

            Console.WriteLine(result);
        }

        public static StringBuilder GetText(int numberOfLines)
        {
            var text = new StringBuilder();
            for (int i = 0; i < numberOfLines; i++)
            {
                text.Append(Console.ReadLine());
            }
            return text;
        }

        public static int GetCode(string substring)
        {
            var code = 0;
            foreach (var character in substring)
            {
                if (character == ' ')
                {
                    continue;
                }

                code += Char.ToUpper(character);
            }
            return code;
        }
    }
}