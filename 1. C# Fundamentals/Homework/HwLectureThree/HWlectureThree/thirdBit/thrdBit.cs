using System;

namespace thirdBit
{
    class thrdBit
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int mask = 1 << 3;
            int thirdBit = (number & mask) >> 3;

            Console.WriteLine(thirdBit);
        }
    }
}
