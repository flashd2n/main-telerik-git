using System;

namespace Matrix
{
    class Matrix<T>
    {
        private T[,] matrix;
        private int row;
        private int col;

        public Matrix(int row, int col)
        {
            this.matrix = new T[row, col];
            this.Row = row;
            this.Col = col;
        }

        public T this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value; }
        }

        private int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        private int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

        public static Matrix<T> operator +(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            var result = new Matrix<T>(matrixOne.Row, matrixTwo.Col);

            if (matrixOne.Row != matrixTwo.Row || matrixOne.Col != matrixTwo.Col)
            {
                throw new Exception("The matrices are not the same size!");
            }
            else
            {
                for (int i = 0; i < matrixOne.Row; i++)
                {
                    for (int j = 0; j < matrixOne.Col; j++)
                    {
                        result[i, j] = (dynamic)matrixOne[i, j] + matrixTwo[i, j];
                    }
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            var result = new Matrix<T>(matrixOne.Row, matrixTwo.Col);

            if (matrixOne.Row != matrixTwo.Row || matrixOne.Col != matrixTwo.Col)
            {
                throw new Exception("The matrices are not the same size!");
            }
            else
            {
                for (int i = 0; i < matrixOne.Row; i++)
                {
                    for (int j = 0; j < matrixOne.Col; j++)
                    {
                        result[i, j] = (dynamic)matrixOne[i, j] - matrixTwo[i, j];
                    }
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            var result = new Matrix<T>(matrixOne.Row, matrixTwo.Col);

            if (matrixOne.Row != matrixTwo.Row || matrixOne.Col != matrixTwo.Col)
            {
                throw new Exception("The matrices are not the same size!");
            }
            else
            {
                for (int i = 0; i < matrixOne.Row; i++)
                {
                    for (int j = 0; j < matrixOne.Col; j++)
                    {
                        result[i, j] = (dynamic)matrixOne[i, j] * matrixTwo[i, j];
                    }
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrixToCheck)
        {
            bool result = false;

            for (int i = 0; i < matrixToCheck.Row; i++)
            {
                for (int j = 0; j < matrixToCheck.Col; j++)
                {
                    if ((dynamic)matrixToCheck[i,j] == 0)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public static bool operator false(Matrix<T> matrixToCheck)
        {
            bool result = false;

            for (int i = 0; i < matrixToCheck.Row; i++)
            {
                for (int j = 0; j < matrixToCheck.Col; j++)
                {
                    if ((dynamic)matrixToCheck[i, j] == 0)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public void Print()
        {
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    Console.Write("{0}{1}", matrix[i, j], j == (matrix.GetLength(1) - 1) ? "\n" : " ");
                }
            }
        }
    }
}
