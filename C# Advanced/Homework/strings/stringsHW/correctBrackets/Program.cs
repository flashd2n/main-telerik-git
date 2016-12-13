using System;

namespace correctBrackets
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (CheckBrackets(input))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }

        static bool CheckBrackets(string input)
        {
            if (input[0] == ')')
            {
                return false;
            }

            if (input[input.Length - 1] == '(')
            {
                return false;
            }

            int openBrakcetsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    ++openBrakcetsCount;
                }

                if (input[i] == ')')
                {
                    --openBrakcetsCount;
                }

                if (openBrakcetsCount < 0 || (i == (input.Length - 1) && openBrakcetsCount != 0))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
