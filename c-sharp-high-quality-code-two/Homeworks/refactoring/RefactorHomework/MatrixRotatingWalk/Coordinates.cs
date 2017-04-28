namespace MatrixRotatingWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Coordinates
    {
        private const int MIN_COORDINATE_VALUE = -1;
        private const int MAX_COORDINATE_VALUE = 1;
        private int x;
        private int y;

        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < MIN_COORDINATE_VALUE || value > MAX_COORDINATE_VALUE)
                {
                    throw new ArgumentOutOfRangeException("X coordianate value cannot be different from the range {{" + MIN_COORDINATE_VALUE + " ... " + MAX_COORDINATE_VALUE + "}}");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < MIN_COORDINATE_VALUE || value > MAX_COORDINATE_VALUE)
                {
                    throw new ArgumentOutOfRangeException("Y coordianate value cannot be different from the range {{" + MIN_COORDINATE_VALUE + " ... " + MAX_COORDINATE_VALUE + "}}");
                }

                this.y = value;
            }
        }
    }
}