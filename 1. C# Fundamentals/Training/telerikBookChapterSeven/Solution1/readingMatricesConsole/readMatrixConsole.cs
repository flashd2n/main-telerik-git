using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readingMatricesConsole
{
    class readMatrixConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of elements in first dimension:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of elements in second dimension:");
            int m = int.Parse(Console.ReadLine());

            int[,] myMatrix = new int[n, m];

            for (int dZero = 0; dZero < myMatrix.GetLength(0); dZero++)
            {
                for (int dOne = 0; dOne < myMatrix.GetLength(1); dOne++)
                {
                    Console.Write("Element with position [{0},{1}]: ", dZero, dOne);
                    myMatrix[dZero, dOne] = int.Parse(Console.ReadLine()); 
                }
            }

            for (int dZero = 0; dZero < myMatrix.GetLength(0); dZero++)
            {
                for (int dOne = 0; dOne < myMatrix.GetLength(1); dOne++)
                {
                    Console.Write("{0}{1}", myMatrix[dZero,dOne], dOne != (myMatrix.GetLength(1) - 1) ? " " : "\n");
                }
            }


        }
    }
}
