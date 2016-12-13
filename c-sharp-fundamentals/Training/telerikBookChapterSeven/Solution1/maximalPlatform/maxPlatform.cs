using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maximalPlatform
{
    class maxPlatform
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                { 0, 2, 4, 0, 9, 5 },
                { 7, 1, 3, 3, 2, 1 },
                { 1, 3, 9, 8, 5, 6 },
                { 4, 6, 7, 9, 1, 0 }
            };


            int bestSum = 0;
            int bestI = 0;
            int bestJ = 0;

            for (int i = 0; i < (matrix.GetLength(0) - 1); i++)
            {
                for (int j = 0; j < (matrix.GetLength(1) - 1); j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestI = i;
                        bestJ = j;
                    }                    
                }
            }

            Console.WriteLine(bestSum);


            Console.Write("{0}{1}{2}{3}", matrix[bestI,bestJ], " ", matrix[bestI, (bestJ + 1)], "\n");
            Console.Write("{0}{1}{2}{3}", matrix[(bestI + 1), bestJ], " ", matrix[(bestI + 1), (bestJ + 1)], "\n");

        }
    }
}
