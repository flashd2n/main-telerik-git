using System;
using System.Linq;

namespace snake
{
    class Program
    {
        static void Main()
        {
            string inputDims = Console.ReadLine();
            var dimentions = inputDims.Split('x').Select(int.Parse).ToArray();
            var den = new char[dimentions[0], dimentions[1]];
            den = FillDen(den, dimentions);
            string inputInstructions = Console.ReadLine();
            var separator = new char[] { ',' };
            var temp = inputInstructions.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            inputInstructions = string.Join("", temp);
            var directions = inputInstructions.ToCharArray();
            // den is set and directions are in the char[]

            int row = 0;
            int col = 0;

            row = GetStartRow(den);
            col = GetStartCol(den);
            int length = 3;
            bool isExit = false;

            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case 's': //down
                        ++row;
                        break;
                    case 'w': //up
                        --row;
                        break;
                    case 'a': //left
                        --col;
                        if (col == -1)
                        {
                            col = den.GetLength(1) - 1;
                        }
                        break;
                    case 'd': //right
                        ++col;
                        if (col == den.GetLength(1))
                        {
                            col = 0;
                        }
                        break;
                    default:
                        break;
                }

                if (((i + 1) % 5 == 0) & (i != 0))
                {
                    --length;
                }

                if (length == 0)
                {
                    Console.WriteLine("{0}[{1},{2}]", "Sneaky is going to starve at ", row, col);
                    break;
                }

                if (row == den.GetLength(0))
                {
                    Console.WriteLine("{0}{1}", "Sneaky is going to be lost into the depths with length ", length);
                    break;
                }

                switch (den[row, col])
                {
                    case '%': //rock
                        Console.WriteLine("{0}[{1},{2}]", "Sneaky is going to hit a rock at ", row, col);
                        isExit = true;
                        break;
                    case '@': //food
                        ++length;
                        den[row, col] = '-';
                        break;
                    case 'e':
                        Console.WriteLine("{0}{1}", "Sneaky is going to get out with length ", length);
                        isExit = true;
                        break;
                    case '-':
                        break;
                    default:
                        break;
                }

                if (isExit)
                {
                    break;
                }
                else if (isExit == false && i == directions.Length - 1)
                {
                    Console.WriteLine("{0}[{1},{2}]", "Sneaky is going to be stuck in the den at ", row, col);
                    break;
                }
            }
        }

        static int GetStartCol(char[,] den)
        {
            int col = 0;

            for (int i = 0; i < den.GetLength(0); i++)
            {
                for (int j = 0; j < den.GetLength(1); j++)
                {

                    if (den[i, j] == 'e')
                    {
                        col = j;
                        return col;
                    }
                }
            }
            return col;
        }

        static int GetStartRow(char[,] den)
        {
            int row = 0;

            for (int i = 0; i < den.GetLength(0); i++)
            {
                for (int j = 0; j < den.GetLength(1); j++)
                {

                    if (den[i,j] == 'e')
                    {
                        row = i;
                        return row;
                    }
                }
            }
            return row;
        }

        static char[,] FillDen(char[,] den, int[] dimentions)
        {
            for (int i = 0; i < dimentions[0]; i++)
            {
                var fill = Console.ReadLine().ToCharArray();

                for (int j = 0; j < dimentions[1]; j++)
                {
                    den[i, j] = fill[j];
                }
            }
            return den;
        }
    }
}
