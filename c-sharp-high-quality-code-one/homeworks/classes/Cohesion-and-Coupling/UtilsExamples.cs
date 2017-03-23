using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileOperations.GetFileExtension("example"));
            Console.WriteLine(FileOperations.GetFileExtension("example.pdf"));
            Console.WriteLine(FileOperations.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileOperations.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileOperations.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileOperations.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                PointsCalculations.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                PointsCalculations.CalcDistance3D(5, 2, -1, 3, -6, 4));
            
            Console.WriteLine("Volume = {0:f2}", TriDimentionalOperations.CalcVolume(3, 4, 5));
            Console.WriteLine("Diagonal XYZ = {0:f2}", TriDimentionalOperations.CalcDiagonalXYZ(3, 4, 5));
            Console.WriteLine("Diagonal XY = {0:f2}", TriDimentionalOperations.CalcDiagonalXY(3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", TriDimentionalOperations.CalcDiagonalXZ(3, 5));
            Console.WriteLine("Diagonal YZ = {0:f2}", TriDimentionalOperations.CalcDiagonalYZ(4, 5));
        }
    }
}
