using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysEnv
{
    class sysEnv
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int startTime = Environment.TickCount;

            for (int i = 0; i < 100000000; i++)
            {
                sum++;
            }

            int endTime = Environment.TickCount;
            int elapsedTimeInMiliseconds = endTime - startTime;
            double elapsedTimeInSeconds = (endTime - startTime) / 1000D;
            Console.WriteLine($"The time elapsed is {elapsedTimeInMiliseconds} miliseconds");
            

        }
    }
}
