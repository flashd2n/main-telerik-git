using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class PlayWithPoints
    {
        static void Main()
        {

            var point = new Point2DStruct(3, -2);
            PrintPoint(point);
            TryToChangePoint(point);
            PrintPoint(point);
            Console.WriteLine("Using Class");
            var pointTwo = new Point2DClass(3, -2);
            PrintPoint(pointTwo);
            TryToChangePoint(pointTwo);
            PrintPoint(pointTwo);
            Console.WriteLine("Changing struc data inside main");
            point.X++;
            point.Y++;
            Console.WriteLine($"({point.X},{point.Y})");

        }

        static void PrintPoint(Point2DStruct p)
        {
            Console.WriteLine($"({p.X},{p.Y})");
        }

        static void TryToChangePoint(Point2DStruct p)
        {
            p.X++;
            p.Y++;
            Console.WriteLine("Printing inside TryTochange method");
            Console.WriteLine($"({p.X},{p.Y})");
        }

        static void PrintPoint(Point2DClass p)
        {
            Console.WriteLine($"({p.X},{p.Y})");
        }

        static void TryToChangePoint(Point2DClass p)
        {
            p.X++;
            p.Y++;
        }
    }
}
