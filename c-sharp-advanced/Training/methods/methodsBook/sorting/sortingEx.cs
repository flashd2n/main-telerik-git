using System;

namespace sorting
{
    class sortingEx
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] matrix = FillMatrix(n);
            matrix = SortMatrix(matrix);
            string finalResult = JoinMatrix(matrix);

            Console.WriteLine(finalResult);
        }

        static string JoinMatrix(int[] matrix)
        {
            string result = string.Join(" ", matrix);
            return result;
        }

        static int[] SortMatrix(int[] matrix)
        {
            int temp = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                int minValue = int.MaxValue;
                int swapIndex = 0;
                for (int j = i; j < matrix.Length; j++)
                {
                    if (matrix[j] < minValue)
                    {
                        minValue = matrix[j];
                        swapIndex = j;
                    }
                }
                temp = matrix[i];
                matrix[i] = minValue;
                matrix[swapIndex] = temp;
            }

            return matrix;
        }

        static int[] FillMatrix(int n)
        {
            int[] matrix = new int[n];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = int.Parse(Console.ReadLine());
            }

            return matrix;
        }
    }
}
