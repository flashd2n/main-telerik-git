using System;

namespace taskTwentyFive
{
    class taskTwentyFive
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] separator = new string[] { ", " };
            var words = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            Console.WriteLine(string.Join(", ", words));
        }
    }
}
