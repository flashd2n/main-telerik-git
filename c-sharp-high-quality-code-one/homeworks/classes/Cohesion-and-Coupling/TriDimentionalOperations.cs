using System;

namespace CohesionAndCoupling
{
    static class TriDimentionalOperations
    {

        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(double width, double height, double depth)
        {
            double distance = Math.Sqrt(width * width + height * height + depth * depth);
            return distance;
        }

        public static double CalcDiagonalXY(double width, double height)
        {
            double distance = Math.Sqrt(width * width + height * height);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            double distance = Math.Sqrt(width * width + depth * depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            double distance = Math.Sqrt(height * height + depth * depth);
            return distance;
        }
    }
}
