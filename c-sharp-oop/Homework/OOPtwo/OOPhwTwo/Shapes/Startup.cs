using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Startup
    {
        static void Main()
        {
            var allShapes = new Shape[]
            {
                new Rectangle(4.3, 6.2),
                new Square(9.9),
                new Triangle(9.2, 10.3)
            };
            foreach (var shape in allShapes)
            {
                Console.WriteLine($"The surface area of {shape.GetType().Name} is {shape.CalculateSurface()}");
            }
        }
    }
}
