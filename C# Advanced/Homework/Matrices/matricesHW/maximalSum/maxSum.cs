using System;

namespace maximalSum
{
    class maxSum
    {
        static void Main()
        {
            // take matrix sizes from string (2 numbers) and put them in array

            string initialInput = Console.ReadLine();
            int[] dimSizes = new int[2];
            string tempValues = null;
            int tempNumber = 0;
            int arrayCounter = 0;
            int maxSum = int.MinValue;
            int tempSum = 0;

            for (int i = 0; i < initialInput.Length; i++)
            {
                if (initialInput[i] == 32)
                {
                    tempNumber = Convert.ToInt32(tempValues, 10);
                    dimSizes[arrayCounter] = tempNumber;

                    tempValues = null;
                    ++arrayCounter;
                    continue;
                }

                tempValues += initialInput[i];

                if (i == (initialInput.Length - 1))
                {
                    tempNumber = Convert.ToInt32(tempValues, 10);
                    dimSizes[arrayCounter] = tempNumber;

                    tempValues = null;
                    arrayCounter = 0;
                    tempNumber = 0;
                }
            }
            // finish
            // make a matrix of sizes at positions 0 and 1 from arrray above 
            int[,] matrix = new int[dimSizes[0], dimSizes[1]];
            //finish
            //start fill matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                int[] dimTwoValues = new int[dimSizes[1]];

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 32)
                    {
                        tempNumber = Convert.ToInt32(tempValues, 10);
                        matrix[i,arrayCounter] = tempNumber;

                        tempValues = null;
                        ++arrayCounter;
                        continue;
                    }

                    tempValues += input[j];

                    if (j == (input.Length - 1))
                    {
                        tempNumber = Convert.ToInt32(tempValues, 10);
                        matrix[i,arrayCounter] = tempNumber;

                        tempValues = null;
                        arrayCounter = 0;
                        tempNumber = 0;
                    }
                }                
            }
            //matrix is filled with values
            //calculate all 3x3 sums and put the best in maxSum
            for (int i = 0; i <= (matrix.GetLength(0) - 3); i++)
            {
                for (int j = 0; j <= (matrix.GetLength(1) - 3); j++)
                {
                    tempSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (maxSum < tempSum)
                    {
                        maxSum = tempSum;
                    }
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}
