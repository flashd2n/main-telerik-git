using System;
using System.Linq;

namespace Dancing_Moves
{
    class Startup
    {
        static void Main()
        {
            var danceFloor = Console.ReadLine().Split(' ').Select(ulong.Parse).ToArray();

            string instructions = Console.ReadLine();
            int position = 0;
            ulong totalSum = 0;
            int counter = 0;

            while (instructions != "stop")
            {
                ++counter;
                string[] temp = instructions.Split(' ');
                int times = int.Parse(temp[0]);
                string direction = temp[1];
                int step = int.Parse(temp[2]);

                for (int i = 0; i < times; i++)
                {
                    if (direction == "right")
                    {
                        position = (position + step) % danceFloor.Length;
                        totalSum += danceFloor[position];
                    }
                    else
                    {
                        position = (position - step) % danceFloor.Length;
                        if (position < 0)
                        {
                            position += danceFloor.Length;
                        }
                        totalSum += danceFloor[position];
                    
                    }
                }
                instructions = Console.ReadLine();
            }
            double result = totalSum / (double)counter;
            Console.WriteLine("{0:F1}", result);
        }
    }
}
