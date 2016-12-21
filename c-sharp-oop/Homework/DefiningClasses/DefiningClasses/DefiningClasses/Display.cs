using System;

namespace DefiningClasses
{
    class Display
    {
        // Fields

        private double size;
        private int colorsCount;

        // Properties

        public double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Argument: Size cannot be a negative number");
                }

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
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Argument: ColorsCount cannot be a negative number");
                }

                this.colorsCount = value;
            }
        }

        // Constructor

        public Display(double size, int colorsCount)
        {
            this.Size = size;
            this.ColorsCount = colorsCount;
        }
    }
}
