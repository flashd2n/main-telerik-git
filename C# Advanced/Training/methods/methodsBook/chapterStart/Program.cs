using System;

namespace chapterStart
{
    class Program
    {

        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            string result = CheckNum(input);


            Console.WriteLine(result);
        }


        static string CheckNum(int input)
        {
            string result = null;

            if (input > 0)
            {
                result = "Positive";
            }
            else if (input < 0)
            {
                result = "Negative";
            }
            else
            {
                result = "Zero";
            }
            return result;
        }
    }
}
