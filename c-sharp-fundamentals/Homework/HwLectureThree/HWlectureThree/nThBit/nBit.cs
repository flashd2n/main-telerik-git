using System;

namespace nThBit
{
    class nBit
    {
        static void Main(string[] args)
        {
            long p = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int mask = 1 << n;
            long nBit = (p & mask) >> n;

            Console.WriteLine(nBit);

        }
    }
}
