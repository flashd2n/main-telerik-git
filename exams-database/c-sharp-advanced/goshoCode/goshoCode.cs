using System;
using System.Text;

namespace goshoCode
{
    class goshoCode
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            var textInput = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                textInput.Append(Console.ReadLine());
            }

            string text = textInput.ToString();

            int indexKeyword = text.IndexOf(keyword);
            int indexDot = text.IndexOf('.', indexKeyword + 1);
            int indexQuestion = text.IndexOf('!', indexKeyword + 1);

            if (indexDot == -1)
            {
                indexDot = int.MaxValue;
            }
            else if (indexQuestion == -1)
            {
                indexQuestion = int.MaxValue;
            }

            string subString = null;

            if (indexDot < indexQuestion)
            {
                // statement
                subString = text.Substring(indexKeyword + keyword.Length, indexDot - (indexKeyword + keyword.Length));

            }
            else
            {
                // question
                int indexCap = 0;

                for (int i = indexKeyword; true; i--)
                {
                    if (char.IsUpper(text[i]))
                    {
                        indexCap = i;
                        break;
                    }
                }
                subString = text.Substring(indexCap, (indexKeyword - 1) - indexCap);
            }

            int sum = 0;

            foreach (var c in subString)
            {
                if (c == ' ')
                {
                    continue;
                }

                sum = sum + c * keyword.Length;
            }

            Console.WriteLine(sum);
        }
    }
}
