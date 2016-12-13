using System;

namespace taskFour
{
    class taskFour
    {
        static void Main()
        {

            string input = Console.ReadLine();

            var splitMe = input.Split('\\');

            Console.WriteLine(string.Join(" ", splitMe));
        }
    }
}
