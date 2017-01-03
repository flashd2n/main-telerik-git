using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidian3DSpace
{
    public static class Utility
    {
        public static double CalculateDistance(Point3D pointOne, Point3D pointTwo)
        {
            double result = Math.Sqrt(Math.Pow(pointTwo.X - pointOne.X, 2) + Math.Pow(pointTwo.Y - pointOne.Y, 2) + Math.Pow(pointTwo.Z - pointOne.Z, 2));
            return result;
        }
    }
}
