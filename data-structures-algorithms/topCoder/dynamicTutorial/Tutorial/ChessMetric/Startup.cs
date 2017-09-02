using System;
using System.Collections.Generic;

namespace ChessMetric
{
    class Startup
    {
        public static int[,] moves = new int[,] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 }, { -1, -1 }, { 1, 1 }, { 1, -1 }, { -1, 1 }, { 1, 2 }, { 2, 1 }, { -1, 2 }, { 1, -2 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { -1, -2 } };

        static void Main()
        {
            var size = 100;
            var start = new int[] { 0, 0 };
            var end = new int[] { 0, 99 };
            var num = 50;

            long result = howManyTwo(size, start, end, num);
            Console.WriteLine(result);
        }

        public static long howManyTwo(int size, int[] start, int[] end, int numMoves)
        {
            var startRow = start[0];
            var startCol = start[1];
            var endRow = end[0];
            var endCol = end[1];

            var dp = new long[size, size, numMoves + 1];
            dp[startRow, startCol, 0] = 1;

            for (int m = 0; m < numMoves; m++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (dp[i, j, m] != 0)
                        {
                            // I can reach cell[i, j] from start in m moves
                            UpdateNeighbors(i, j, m, dp);
                        }
                    }
                }
            }

            //long result = CalculateResult(dp, endRow, endCol, numMoves);

            return dp[endRow, endCol, numMoves];
        }

        private static long CalculateResult(long[,,] dp, int endRow, int endCol, int numMoves)
        {
            long result = 0;
            for (int k = 0; k < moves.GetLength(0); k++)
            {
                var newRow = endRow - moves[k, 0];
                var newCol = endCol - moves[k, 1];
                if (newRow >= 0 && newRow < dp.GetLength(0) && newCol >= 0 && newCol < dp.GetLength(1))
                {
                    result += dp[newRow, newCol, numMoves - 1];
                }
            }

            return result;
        }

        private static void UpdateNeighbors(int i, int j, int m, long[,,] dp)
        {
            for (int k = 0; k < moves.GetLength(0); k++)
            {
                var newRow = i + moves[k, 0];
                var newCol = j + moves[k, 1];
                if (newRow >= 0 && newRow < dp.GetLength(0) && newCol >= 0 && newCol < dp.GetLength(1))
                {
                    dp[newRow, newCol, m + 1] += dp[i, j, m];
                }
            }
        }

        private static long KingMoves(int[,] matrix, int row, int col, int endRow, int endCol, int numMoves, int currentMoves, long[,] dp)
        {
            ++currentMoves;
            if (currentMoves > numMoves)
            {
                return 0;
            }

            if (row == endRow && col == endCol && currentMoves == numMoves)
            {
                return 1;
            }

            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return 0;
            }

            //if (dp[row, col] == -1)
            //{
            //    dp[row, col] = KingMoves(matrix, row - 1, col, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row - 1, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row + 1, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row + 1, col, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row + 1, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row - 1, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row - 2, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row - 1, col + 2, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row + 1, col + 2, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row + 2, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row + 2, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row + 1, col - 2, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row - 1, col - 2, endRow, endCol, numMoves, currentMoves, dp) +
            //    KingMoves(matrix, row - 2, col - 1, endRow, endCol, numMoves, currentMoves, dp);
            //}

            //return dp[row, col];

            return KingMoves(matrix, row - 1, col, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row - 1, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row + 1, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row + 1, col, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row + 1, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row - 1, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row - 2, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row - 1, col + 2, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row + 1, col + 2, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row + 2, col + 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row + 2, col - 1, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row + 1, col - 2, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row - 1, col - 2, endRow, endCol, numMoves, currentMoves, dp) +
                KingMoves(matrix, row - 2, col - 1, endRow, endCol, numMoves, currentMoves, dp);
        }
    }
}
