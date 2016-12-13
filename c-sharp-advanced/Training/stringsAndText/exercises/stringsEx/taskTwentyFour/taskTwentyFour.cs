using System;

namespace taskTwentyFour
{
    class taskTwentyFour
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string result = null;

            for (int i = 0; i < input.Length; i++)
            {
                result += input[i];
                if (i == input.Length - 1)
                {
                    break;
                }

                while (input[i] == input[i + 1])
                {
                    ++i;
                    if (i == input.Length - 1)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
