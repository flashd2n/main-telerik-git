using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace properties
{
    class Properties
    {
        static void Main()
        {
            var pointOne = new Point(1.2, 1.5);
            Console.WriteLine(pointOne.X);
            Console.WriteLine(pointOne.Y);
            var pointTwo = new AnotherPoint(3.4, 5.1);
            Console.WriteLine(pointTwo.X);
            Console.WriteLine(pointTwo.Y);
        }
    }

    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get
            {
                return this.x;
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
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
    }
}
