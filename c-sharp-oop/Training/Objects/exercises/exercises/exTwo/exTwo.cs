using System;

namespace exTwo
{
    class exTwo
    {
        private static Random rnd = new Random();

        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(100, 201));
            }
        }
    }
}
