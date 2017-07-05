using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    class Startup
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            int[] tubes = new int[N];

            for (int i = 0; i < N; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(FindMaximalLength(tubes, M));
        }

        static int FindMaximalLength(int[] tubes, int neededCount)
        {
            int min = 1;
            int max = tubes.Max();
            int middle = 1;
            int count = 1;
            int answer = -1;

            while (min <= max)
            {
                middle = (min + max) / 2;
                count = 0;

                for (int i = 0; i < tubes.Length; i++)
                {
                    count += tubes[i] / middle;
                }

                if (count < neededCount)
                {
                    max = middle - 1;
                }
                else if (count >= neededCount)
                {
                    min = middle + 1;
                    answer = middle;
                }
            }

            return answer;
        }
    }


}
