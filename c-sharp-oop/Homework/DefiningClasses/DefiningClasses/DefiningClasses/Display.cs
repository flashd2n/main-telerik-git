using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    class Display
    {
        private double size;
        private int colorsCount;

        public double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        public int ColorsCount
        {
            get
            {
                return this.colorsCount;
            }

            set
            {
                this.colorsCount = value;
            }
        }

        public Display(double size, int colorsCount)
        {
            this.Size = size;
            this.ColorsCount = colorsCount;
        }
    }
}
