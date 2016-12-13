using System;

namespace sequenceInMatrix
{
    class sequenceMatrix
    {
        static void Main()
        {
            // take matrix sizes from string (2 numbers) and put them in array

            string initialInput = Console.ReadLine();
            int[] dimSizes = new int[2];
            string tempValues = null;
            int tempNumber = 0;
            int arrayCounter = 0;

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
                        matrix[i, arrayCounter] = tempNumber;

                        tempValues = null;
                        ++arrayCounter;
                        continue;
                    }

                    tempValues += input[j];

                    if (j == (input.Length - 1))
                    {
                        tempNumber = Convert.ToInt32(tempValues, 10);
                        matrix[i, arrayCounter] = tempNumber;

                        tempValues = null;
                        arrayCounter = 0;
                        tempNumber = 0;
                    }
                }
            }
            //matrix is filled with values

            
            int bestSequenceLength = int.MinValue;            



            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == 0) // when we are at the first row
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        if (j == (matrix.GetLength(1) - 1)) //when we are at the last element of the row
                        {
                            if (matrix[i,j] == matrix[i + 1,j]) //check downward sequence
                            {
                                int sequenceLength = 1;
                                for (int z = i + 1; z < matrix.GetLength(0); z++)
                                {
                                    if (matrix[i,j] == matrix[z,j])
                                    {
                                        ++sequenceLength;
                                    }
                                }
                                if (sequenceLength > bestSequenceLength)
                                {
                                    bestSequenceLength = sequenceLength;
                                }
                            }
                            break;
                        }

                        //when we are at any other element

                        if (matrix[i,j] == matrix[i, j + 1]) //check right side sequence
                        {
                            int sequenceLength = 1;
                            for (int z = j + 1; z < matrix.GetLength(1); z++)
                            {
                                if (matrix[i,j] == matrix[i,z])
                                {
                                    ++sequenceLength;
                                }
                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }
                        }

                        if (matrix[i,j] == matrix[i + 1,j]) // check downward sequence
                        {
                            int sequenceLength = 1;
                            for (int z = i + 1; z < matrix.GetLength(0); z++)
                            {
                                if (matrix[i,j] == matrix[z,j])
                                {
                                    ++sequenceLength;
                                }
                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }
                        }

                        if (matrix[i,j] == matrix[i + 1, j + 1]) // check downward diagonal
                        {
                            int sequenceLength = 1;
                            for (int z = 0; (i + 1 + z) < matrix.GetLength(0) && (j + 1 + z) < matrix.GetLength(1) ; z++)
                            {
                                if (matrix[i,j] == matrix[i + 1 + z, j + 1 + z])
                                {
                                    ++sequenceLength;
                                }

                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }

                        }

                    }
                }
                else if (i == (matrix.GetLength(0) - 1)) // when we are at the last row
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j == (matrix.GetLength(1) - 1)) //when we are at the last element of the row
                        {
                            break;
                        }
                        //when we are at any other element

                        if (matrix[i, j] == matrix[i, j + 1]) //check right side sequence
                        {
                            int sequenceLength = 1;
                            for (int z = j + 1; z < matrix.GetLength(1); z++)
                            {
                                if (matrix[i, j] == matrix[i, z])
                                {
                                    ++sequenceLength;
                                }
                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }
                        }

                        if (matrix[i, j] == matrix[i - 1, j + 1]) // check upward diagonal
                        {
                            int sequenceLength = 1;
                            for (int z = 0; (i - 1 - z) >= 0 && (j + 1 + z) < matrix.GetLength(1); z++)
                            {
                                if (matrix[i, j] == matrix[i - 1 - z, j + 1 + z])
                                {
                                    ++sequenceLength;
                                }

                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }

                        }

                    }
                    break;
                }
                else // when we are between the first and the last row
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j == (matrix.GetLength(1) - 1)) //when we are at the last element of the row
                        {
                            if (matrix[i, j] == matrix[i + 1, j])
                            {
                                int sequenceLength = 1;
                                for (int z = i + 1; z < matrix.GetLength(0); z++)
                                {
                                    if (matrix[i, j] == matrix[z, j])
                                    {
                                        ++sequenceLength;
                                    }
                                }
                                if (sequenceLength > bestSequenceLength)
                                {
                                    bestSequenceLength = sequenceLength;
                                }
                            }
                            break;
                        }
                        //when we are at any other element

                        if (matrix[i, j] == matrix[i, j + 1]) //check right side sequence
                        {
                            int sequenceLength = 1;
                            for (int z = j + 1; z < matrix.GetLength(1); z++)
                            {
                                if (matrix[i, j] == matrix[i, z])
                                {
                                    ++sequenceLength;
                                }
                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }
                        }

                        if (matrix[i, j] == matrix[i + 1, j]) // check downward sequence
                        {
                            int sequenceLength = 1;
                            for (int z = i + 1; z < matrix.GetLength(0); z++)
                            {
                                if (matrix[i, j] == matrix[z, j])
                                {
                                    ++sequenceLength;
                                }
                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }
                        }

                        if (matrix[i, j] == matrix[i - 1, j + 1]) // check upward diagonal
                        {
                            int sequenceLength = 1;
                            for (int z = 0; (i - 1 - z) >= 0 && (j + 1 + z) < matrix.GetLength(1); z++)
                            {
                                if (matrix[i, j] == matrix[i - 1 - z, j + 1 + z])
                                {
                                    ++sequenceLength;
                                }

                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }

                        }

                        if (matrix[i, j] == matrix[i + 1, j + 1]) // check downward diagonal
                        {
                            int sequenceLength = 1;
                            for (int z = 0; (i + 1 + z) < matrix.GetLength(0) && (j + 1 + z) < matrix.GetLength(1); z++)
                            {
                                if (matrix[i, j] == matrix[i + 1 + z, j + 1 + z])
                                {
                                    ++sequenceLength;
                                }

                            }
                            if (sequenceLength > bestSequenceLength)
                            {
                                bestSequenceLength = sequenceLength;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(bestSequenceLength);            
        }
    }
}
