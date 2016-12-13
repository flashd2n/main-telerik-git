using System;

namespace fillTheMatrix
{
    class fillMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            string pattern = Console.ReadLine();
            int counter = 1;
            int revCounter = n * n;
            int rotationType = 0;
            int left = 0;
            int bottom = 0;
            int right = 0;
            int top = 0;

            switch ((int)pattern[0])
            {
                case 97:

                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            matrix[j, i] = counter;
                            counter++;
                        }
                    }
                    break;
                case 98:
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        if (i == 0 || i % 2 == 0)
                        {
                            for (int j = 0; j < matrix.GetLength(0); j++)
                            {
                                matrix[j, i] = counter;
                                counter++;
                            }
                        }
                        else
                        {
                            for (int j = (matrix.GetLength(0) - 1); j >= 0; j--)
                            {
                                matrix[j, i] = counter;
                                counter++;
                            }
                        }                        
                    }
                    break;
                case 99:

                    for (int i = n - 1; i >= 0; i--)
                    {
                        int tracker = i;

                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {

                            if (tracker == matrix.GetLength(0))
                            {
                                break;
                            }
                            matrix[tracker, j] = counter++;
                            ++tracker;
                        }
                    }

                    for (int i = 0; i < n - 1; i++)
                    {
                        int tracker = i;

                        for (int j = n - 1; j >= 0; j--)
                        {
                            if (tracker == -1)
                            {
                                break;
                            }
                            matrix[tracker, j] = revCounter--;
                            --tracker;
                        }
                    }
                    break;
                case 100:
                    do
                    {
                        if (rotationType == 0)
                        {
                            for (int i = 0 + top; i <= n - 1 - bottom; i++)
                            {
                                matrix[i, left] = counter++;
                            }
                            ++left;
                            ++rotationType;
                        }
                        else if (rotationType == 1)
                        {
                            for (int i = 0 + left; i <= n - 1 - right; i++)
                            {
                                matrix[n - 1 - bottom, i] = counter++;
                            }
                            ++bottom;
                            ++rotationType;
                        }
                        else if (rotationType == 2)
                        {
                            for (int i = n - 1 - bottom; i >= 0 + top; i--)
                            {
                                matrix[i, n - 1 - right] = counter++;
                            }
                            ++right;
                            ++rotationType;
                        }
                        else if (rotationType == 3)
                        {
                            for (int i = n - 1 - right; i >= 0 + left; i--)
                            {
                                matrix[0 + top, i] = counter++;
                            }
                            ++top;
                            rotationType = 0;
                        }
                    } while (counter <= n * n);
                    break;
                default:
                    Console.WriteLine("Swtich Error");
                    break;
            }

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
