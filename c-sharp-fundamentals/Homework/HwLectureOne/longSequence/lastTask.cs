using System;

namespace longSequence
{
    class lastTask
    {
        static void Main()
        {
            for (int i = 2; i < 1002; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(-i);
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
