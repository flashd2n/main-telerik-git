using System;

namespace stringJoin
{
    class strJoin
    {
        static string Join(int[] numbers, string separator)
        {
            string result = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];

                if (i != numbers.Length - 1)
                {
                    result += separator;
                }
            }

            return result;
        }

        static void Main()
        {

            int[] numbers = { 1, 2, 3, 10, 15, 33};

            Console.WriteLine(Join(numbers, " "));



        }
    }
}
