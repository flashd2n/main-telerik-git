using System;

namespace taskEight
{
    class taskEight
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var unicode = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                unicode[i] = string.Format("\\u{0:X4}", (int)input[i]);
            }

            Console.WriteLine(string.Join("", unicode));
        }
    }
}
