using System;
using System.Collections.Generic;
using System.Linq;

namespace snakeMorning
{
    class snakeMorning
    {
        static void Main()
        {
            List<int> dimentions = Console.ReadLine().Split('x').Select(int.Parse).ToList();
            var den = new char[dimentions[0], dimentions[1]];
            den = SetDen(den);
            //den is set properly
            var directionsInput = Console.ReadLine().Split(',');
            string temp = string.Join("", directionsInput);

            char[] directions = temp.ToCharArray();

            int row = GetStartRow(den);
            int col = GetStartCol(den);
            int length = 3;

            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case 'd':
                        ++row;
                        break;
                    case 'u':
                        --row;
                        break;
                    case 'l':
                        --col;
                        if (col == -1)
                        {
                            col = den.GetLength(1) - 1;
                        }
                        break;
                    case 'r':
                        ++col;
                        if (col == den.GetLength(1))
                        {
                            col = 0;
                        }
                        break;
                    default:
                        Console.WriteLine("directions switch error");
                        break;
                }

                if (((i + 1) % 5 == 0) && (i != 0))
                {
                    --length;
                }

                if (length == 0)
                {
                    Console.WriteLine("{0}[{1},{2}]", "Snacky will starve at ", row, col);
                    break;
                }

                if (row == den.GetLength(0))
                {
                    Console.WriteLine("{0}{1}", "Snacky will be lost into the depths with length ", length);
                    break;
                }

                if (den[row, col] == 's')
                {
                    Console.WriteLine("{0}{1}", "Snacky will get out with length ", length);
                    break;
                }
                else if (den[row, col] == '.')
                {

                }
                else if (den[row, col] == '#')
                {
                    Console.WriteLine("{0}[{1},{2}]", "Snacky will hit a rock at ", row, col);
                    break;
                }
                else if (den[row, col] == '*')
                {
                    ++length;
                    den[row, col] = '.';
                }



                if (i == directions.Length - 1)
                {
                    Console.WriteLine("{0}[{1},{2}]", "Snacky will be stuck in the den at ", row, col);
                    break;
                }
            }
        }

        static int GetStartCol(char[,] den)
        {
            int temp = 0;

            for (int i = 0; i < den.GetLength(0); i++)
            {
                for (int j = 0; j < den.GetLength(1); j++)
                {
                    if (den[i, j] == 's')
                    {
                        temp = j;
                        return temp;
                    }
                }
            }

            return temp;

        }

        static int GetStartRow(char[,] den)
        {

            int temp = 0;

            for (int i = 0; i < den.GetLength(0); i++)
            {
                for (int j = 0; j < den.GetLength(1); j++)
                {
                    if (den[i, j] == 's')
                    {
                        temp = i;
                        return temp;
                    }
                }
            }

            return temp;

        }

        static char[,] SetDen(char[,] den)
        {
            for (int i = 0; i < den.GetLength(0); i++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int j = 0; j < den.GetLength(1); j++)
                {
                    den[i, j] = symbols[j];
                }
            }
            return den;
        }
    }
}