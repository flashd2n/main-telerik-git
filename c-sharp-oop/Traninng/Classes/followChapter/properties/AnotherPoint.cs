using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace properties
{
    class AnotherPoint
    {

        private double[] coordinates;

        public AnotherPoint(double x, double y)
        {
            this.coordinates = new double[2];

            this.coordinates[0] = x;
            this.coordinates[1] = y;
        }

        public double X
        {
            get { return coordinates[0]; }
            set { coordinates[0] = value; }
        }

        public double Y
        {
            get { return coordinates[1]; }
            set { coordinates[1] = value; }
        }

        
    }
}
