using System;

namespace printASCII
{
    class prASCII
    {
        static void Main(string[] args)
        {
            for (int i = 33; i < 127; i++)
            {
                char currentChar = (char)i;
                Console.Write(currentChar);
            }
        }
    }
}
