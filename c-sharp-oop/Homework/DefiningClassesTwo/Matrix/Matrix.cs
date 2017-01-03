using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix<T>
    {
        private int row;
        private int col;
        private T[,] matrix;

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }



    }
}
