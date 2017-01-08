using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class Point2DClass
    {
        private double x;
        private double y;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                this.y = value;
            }
        }

        public Point2DClass(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
