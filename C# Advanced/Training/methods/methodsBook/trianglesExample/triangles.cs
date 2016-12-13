using System;

namespace trianglesExample
{
    class triangles
    {

        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            PrintTriangle(input);
        }


        static void PrintTriangle(int input)
        {
            for (int i = 0; i < input; i++)
            {
                for (int j = 1; j <= i + 1; j++)
                {
                    Console.Write("{0}{1}", j, j == i + 1 ? "\n" : " ");
                }
            }

            for (int i = 0; i < input - 1; i++)
            {
                for (int j = 1; j <= input - 1 - i; j++)
                {
                    Console.Write("{0}{1}", j, j == input - 1 - i ? "\n" : " ");
                }
            }
        }
    }
}
