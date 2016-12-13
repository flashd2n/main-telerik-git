using System;

namespace largestAreaInMatrix
{
    class largestArea
    {
        public static void Main()
        {

            string[] inputNAndM = Console.ReadLine().Split(' ');
            int n = int.Parse(inputNAndM[0]);
            int m = int.Parse(inputNAndM[1]);
            int[,] array = new int[n, m];



            for (int i = 0; i < n; i++)
            {
                string[] dimOne = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = int.Parse(dimOne[j]);
                }
            }


            bool[,] calculated = new bool[array.GetLength(0), array.GetLength(1)];
            int bestCount = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!calculated[i, j])
                    {
                        int count = DepthFirstSearch(array, i, j, calculated);
                        if (bestCount < count)
                        {
                            bestCount = count;
                        }
                    }

                }
            }
            Console.WriteLine(bestCount);
        }

        static int DepthFirstSearch(int[,] array, int i, int j, bool[,] calc)
        {
            int result = 1;
            calc[i, j] = true;
            if ((i - 1 >= 0) && (array[i - 1, j] == array[i, j]) && !calc[i - 1, j])
            {
                result += DepthFirstSearch(array, i - 1, j, calc);
            }
            if ((i + 1 < array.GetLength(0)) && (array[i + 1, j] == array[i, j]) && !calc[i + 1, j])
            {
                result += DepthFirstSearch(array, i + 1, j, calc);
            }
            if ((j - 1 >= 0) && (array[i, j - 1] == array[i, j]) && !calc[i, j - 1])
            {
                result += DepthFirstSearch(array, i, j - 1, calc);
            }
            if ((j + 1 < array.GetLength(1)) && (array[i, j + 1] == array[i, j]) && !calc[i, j + 1])
            {
                result += DepthFirstSearch(array, i, j + 1, calc);
            }
            return result;
        }
    }
}
