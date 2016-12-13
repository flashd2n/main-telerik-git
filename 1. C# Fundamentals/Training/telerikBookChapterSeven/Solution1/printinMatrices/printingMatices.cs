using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printinMatrices
{
    class printingMatices
    {
        static void Main(string[] args)
        {

            int[,] matrix =
            {
                { 1, 2, 3, 4},
                { 5, 6, 7, 8}
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}{1}", matrix[i,j], j == (matrix.GetLength(1) - 1) ? "\n" : " ");
                }
            }


        }
    }
}
