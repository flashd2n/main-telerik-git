using System;

namespace busesTask
{
    class buses
    {
        static void Main()
        {
            int c = int.Parse(Console.ReadLine());
            int s = 0;
            int groupCount = 0;
            int previousBus = int.MaxValue;

            for (int i = 1; i <= c; i++)
            {
                s = int.Parse(Console.ReadLine());

                if (s <= previousBus)
                {
                    ++groupCount;
                    previousBus = s;
                }

                

            }

            //if (groupCount == 0)
            //{
            //    ++groupCount;
            //}
            Console.WriteLine(groupCount);

        }
    }
}
