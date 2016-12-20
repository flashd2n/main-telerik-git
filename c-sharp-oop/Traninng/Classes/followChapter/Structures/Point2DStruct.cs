using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    struct Point2DStruct
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

        public Point2DStruct(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
