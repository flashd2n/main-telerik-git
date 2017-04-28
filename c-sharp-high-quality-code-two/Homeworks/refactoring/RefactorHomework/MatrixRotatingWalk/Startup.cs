namespace MatrixRotatingWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        private const int MIN_DIMENSION_SIZE = 1;
        private const int MAX_DIMENSION_SIZE = 100;

        private static void Main(string[] args)
        {
            Console.Write("Enter matrix dimension (must be positive numeber!): ");
            int dimension = int.Parse(Console.ReadLine());

            while (dimension < MIN_DIMENSION_SIZE || dimension > MAX_DIMENSION_SIZE)
            {
                Console.Write("You haven't entered a correct matrix dimension. Try again... : ");
                dimension = int.Parse(Console.ReadLine());
            }

            FillMatrix matrix = new FillMatrix(dimension);
            matrix.FillMatrixWithNumbers();
            Console.WriteLine(matrix);
        }
    }
}