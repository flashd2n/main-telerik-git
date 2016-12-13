using System;

namespace taskNine
{
    class taskNine
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string cifer = Console.ReadLine();
            var result = new string[text.Length];

            for (int i = 0, j = 0; i < text.Length; i++, j++)
            {
                if (j == cifer.Length)
                {
                    j = 0;
                }

                int code = text[i] ^ cifer[j];
                result[i] = string.Format("\\u{0:X4}", code);
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
