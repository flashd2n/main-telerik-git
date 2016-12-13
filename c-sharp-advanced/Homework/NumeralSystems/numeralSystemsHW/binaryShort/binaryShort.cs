using System;

namespace binaryShort
{
    class binaryShort
    {
        static void Main()
        {
            short input = short.Parse(Console.ReadLine());

            char[] binary = new char[16];

            for (int i = 0, pos = 15; i < 16; i++, pos--)
            {
                if ((input & (1 << i)) != 0)
                {
                    binary[pos] = '1';
                }
                else
                {
                    binary[pos] = '0';
                }
            }

            Console.WriteLine(new string(binary)/*.TrimStart('0')*/);
        }
    }
}
