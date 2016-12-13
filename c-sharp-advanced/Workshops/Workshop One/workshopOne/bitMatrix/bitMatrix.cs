using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace bitMatrix
{
    class bitMatrix
    {
        static void Main()
        {
            int dimOne = int.Parse(Console.ReadLine());
            int dimTwo = int.Parse(Console.ReadLine());
            int numberOfMoves = int.Parse(Console.ReadLine());
            List<int> codes = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var matrix = new BigInteger[dimOne, dimTwo];
            var checkCell = new bool[dimOne, dimTwo]; // all set to false by default
            BigInteger counter = 1;
            int rotationCount = 0;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter;
                    counter = counter << 1;
                }
                ++rotationCount;
                counter = 1;
                for (int j = 0; j < rotationCount; j++)
                {
                    counter = counter << 1;
                }
            }

            int coef = Math.Max(dimOne, dimTwo);

            // let the party start
            rotationCount = 0;
            BigInteger sum = 0;
            int rowStart = 0;
            int colStart = 0;
            int rowEnd = 0;
            int colEnd = 0;

            while (rotationCount < numberOfMoves)
            {
                if (rotationCount == 0)
                {
                    rowStart = (matrix.GetLength(0) - 1);
                    colStart = 0;
                }

                rowEnd = codes[rotationCount] / coef;
                colEnd = codes[rotationCount] % coef;

                if (colStart < colEnd)
                {
                    for (int j = colStart; j <= colEnd; j++)
                    {
                        if (checkCell[rowStart, j] == false)
                        {
                            checkCell[rowStart, j] = true;
                            sum += (BigInteger)matrix[rowStart, j];
                        }

                        if (j == colEnd)
                        {
                            colStart = j;
                        }
                    }
                }
                else if (colStart > colEnd)
                {
                    for (int j = colStart; j >= colEnd; j--)
                    {
                        if (checkCell[rowStart, j] == false)
                        {
                            checkCell[rowStart, j] = true;
                            sum += (BigInteger)matrix[rowStart, j];
                        }
                        if (j == colEnd)
                        {
                            colStart = j;
                        }
                    }
                }

                if (rowStart < rowEnd)
                {
                    for (int i = rowStart; i <= rowEnd; i++)
                    {
                        if (checkCell[i, colStart] == false)
                        {
                            checkCell[i, colStart] = true;
                            sum += (BigInteger)matrix[i, colStart];
                        }
                        if (i == rowEnd)
                        {
                            rowStart = i;
                        }
                    }
                }
                else if (rowStart > rowEnd)
                {
                    for (int i = rowStart; i >= rowEnd; i--)
                    {
                        if (checkCell[i, colStart] == false)
                        {
                            checkCell[i, colStart] = true;
                            sum += (BigInteger)matrix[i, colStart];
                        }
                        if (i == rowEnd)
                        {
                            rowStart = i;
                        }
                    }
                }

                rowStart = rowEnd;
                colStart = colEnd;
                ++rotationCount;
            }


            Console.WriteLine(sum);

        }
    }
}
