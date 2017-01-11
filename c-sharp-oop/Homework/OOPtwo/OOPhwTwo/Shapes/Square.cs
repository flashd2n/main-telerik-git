using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : Shape
    {
        public Square(double height) : base(height, height)
        {
        }

        public override double CalculateSurface()
        {
            double surface = this.Height * this.Height;
            return surface;
        }
    }
}
