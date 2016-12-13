using System;

namespace taskThree
{
    class taskThree
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (CheckBrackets(input))
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }

        static bool CheckBrackets(string input)
        {
            int bracketsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    ++bracketsCount;
                }
                else if (input[i] == ')')
                {
                    --bracketsCount;
                }

                if (bracketsCount < 0)
                {
                    return false;
                }

                if (i == (input.Length - 1) && bracketsCount != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
