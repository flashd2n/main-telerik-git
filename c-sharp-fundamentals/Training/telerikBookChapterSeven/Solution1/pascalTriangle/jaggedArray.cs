using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pascalTriangle
{
    class jaggedArray
    {
        static void Main(string[] args)
        {

            // Declare local jagged array with 3 rows.
            int[][] jagged = new int[3][];

            // Create a new array in the jagged array, and assign it.
            jagged[0] = new int[2];
            jagged[0][0] = 1;
            jagged[0][1] = 2;

            // Set second row, initialized to zero.
            jagged[1] = new int[1];

            // Set third row, using array initializer.
            jagged[2] = new int[3] { 3, 4, 5 };

            // Print out all elements in the jagged array.
            for (int i = 0; i < jagged.Length; i++)
            {
                int[] innerArray = jagged[i];
                for (int a = 0; a < innerArray.Length; a++)
                {
                    Console.Write(innerArray[a] + " ");
                }
                Console.WriteLine();

            }

            Console.WriteLine("Second Method");

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Using FOREACH CAN ACCESS ONLY THE ARRAY LEVEL - DIMENSION 0");

            foreach (int[] item in jagged)
            {
                Console.WriteLine(item.Length);
            }


        }
    }
}
