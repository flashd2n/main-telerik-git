using System;

namespace bitSwap
{
    class bSwap
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            for (int i = p; i < p + k; i++)
            {
                uint maskP = 1U << i;
                uint bitPosP = (n & maskP) >> i;

                uint maskQ = 1U << q;
                uint bitPosQ = (n & maskQ) >> q;

                switch (bitPosP)
                {
                    case 1:
                        n = (n | maskQ);
                        break;
                    default:
                        n = (n & (~maskQ));
                        break;
                }

                switch (bitPosQ)
                {
                    case 1:
                        n = (n | maskP);
                        break;
                    default:
                        n = (n & (~maskP));
                        break;
                }
                ++q;
            }
            Console.WriteLine(n);
        }
    }
}
