using System;

namespace matrices
{
    class matrices
    {

        static void PrintMatrix(int[,] matrix)
        {
            for (int dOne = 0; dOne < matrix.GetLength(0); dOne++)
            {
                for (int dTwo = 0; dTwo < matrix.GetLength(1); dTwo++)
                {
                    Console.Write("{0, 4}{1}", matrix[dOne, dTwo], dTwo == (matrix.GetLength(1) - 1) ? "\n" : " ");
                }
            }
        }

        static int[,] ReadMatrix(int sizeOne, int sizeTwo)
        {
            int[,] result = new int[sizeOne, sizeTwo];

            for (int dOne = 0; dOne < result.GetLength(0); dOne++)
            {
                for (int dTwo = 0; dTwo < result.GetLength(1); dTwo++)
                {
                    result[dOne, dTwo] = int.Parse(Console.ReadLine());
                }
            }

            return result;
        }



        static void Main()
        {

            //int[,] matrix =
            //{
            //    { 1, 2, 3, 4, 5},
            //    { 6, 7, 8, 9, 10},
            //    { 11, 12, 13, 14, 15},
            //    { 16, 17, 18, 19, 20}
            //};


            //int[,] table =
            //{
            //    { 21, 23, 44 },
            //    { 62, 73, 80 },
            //    { 121, 132, 143}
            //};

            //PrintMatrix(matrix);
            //Console.WriteLine("Other Matrix");
            //PrintMatrix(table);

            int[,] matrixFromConsole = ReadMatrix(3, 4);
            PrintMatrix(matrixFromConsole);

        }
    }
}
