using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findLongestIncSubSeqMatrix
{
    class longestIncrSubSeqMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            var array = new int[n, m];



            for (int i = 0; i < array.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                List<int> dimTwo = input.Split(' ').Select(int.Parse).ToList();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = dimTwo[j];
                }
            }



        }
    }
}
