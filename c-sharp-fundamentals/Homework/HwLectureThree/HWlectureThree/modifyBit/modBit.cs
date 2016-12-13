using System;

namespace modifyBit
{
    class modBit
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            byte p = byte.Parse(Console.ReadLine());
            byte v = byte.Parse(Console.ReadLine());
            


            if (v == 1)
            {
                ulong mask = 1UL << p;
                ulong newN = n | mask;
                Console.WriteLine(newN);
            }
            else
            {
                ulong mask = ~(1UL << p);
                ulong newN = n & mask;
                Console.WriteLine(newN);
            }
        }
    }
}
