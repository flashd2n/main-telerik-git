using System;

namespace Matrix
{
    class Startup
    {
        static void Main()
        {
            var myMatrix = new Matrix<int>(3, 3);

            myMatrix[0, 0] = 1;
            myMatrix[0, 1] = 2;
            myMatrix[0, 2] = 3;

            myMatrix[1, 0] = 4;
            myMatrix[1, 1] = 5;
            myMatrix[1, 2] = 6;

            myMatrix[2, 0] = 7;
            myMatrix[2, 1] = 8;
            myMatrix[2, 2] = 9;

            Console.WriteLine(myMatrix[2,2]);

            Console.WriteLine("=====");

            myMatrix.Print();

            var myMatrixTwo = new Matrix<int>(3, 3);

            myMatrixTwo[0, 0] = 1;
            myMatrixTwo[0, 1] = 2;
            myMatrixTwo[0, 2] = 3;

            myMatrixTwo[1, 0] = 4;
            myMatrixTwo[1, 1] = 5;
            myMatrixTwo[1, 2] = 6;

            myMatrixTwo[2, 0] = 7;
            myMatrixTwo[2, 1] = 8;
            myMatrixTwo[2, 2] = 9;

            var additionMatrix = myMatrix + myMatrixTwo;

            Console.WriteLine("=====");

            additionMatrix.Print();

            Console.WriteLine("======");

            var subtractionMatrix = myMatrix - myMatrixTwo;

            subtractionMatrix.Print();

            Console.WriteLine("=======");

            var productMatrix = myMatrix * myMatrixTwo;

            productMatrix.Print();

            if (myMatrix)
            {
                Console.WriteLine("There is a zero cell");
            }
            else
            {
                Console.WriteLine("There is NO zero cell");
            }

            var myMatrixThree = new Matrix<int>(3, 3);

            myMatrixThree[0, 0] = 1;
            myMatrixThree[0, 1] = 2;
            myMatrixThree[0, 2] = 3;

            myMatrixThree[1, 0] = 4;
            myMatrixThree[1, 1] = 0;
            myMatrixThree[1, 2] = 6;

            myMatrixThree[2, 0] = 7;
            myMatrixThree[2, 1] = 8;
            myMatrixThree[2, 2] = 9;

            Console.WriteLine("========");

            if (myMatrixThree)
            {
                Console.WriteLine("There is a zero cell");
            }
            else
            {
                Console.WriteLine("There is NO zero cell");
            }
        }
    }
}
