using System;

namespace pascalTriangle
{
    class pTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] triangle = new int[n][];

            for (int i = 0; i < triangle.Length; i++)
            {
                triangle[i] = new int[i + 1];

                for (int j = 0; j < triangle[i].Length; j++)
                {
                    

                    if ((triangle[i].Length >= 3) && (j != 0) && (j != triangle[i].Length - 1))
                    {
                        triangle[i][0 + j] = triangle[i - 1][(0 + j) - 1] + triangle[i - 1][0 + j];
                    }

                    triangle[i][0] = 1;
                    triangle[i][(triangle[i].Length - 1)] = 1;


                        //Console.Write("{0}{1}", triangle[i][j], j != (triangle[i].Length - 1) ? " " : "\n");

                }


            }

            for (int row = 0; row < n; row++)
            {
                Console.Write("".PadLeft((n - row) * 2));
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0,3} ", triangle[row][col]);
                }
                Console.WriteLine();
            }


            //Console.WriteLine("pbccmyxbcwffmybvajwt1234ABCD");
            //Console.Write("".PadLeft(24));
            //Console.WriteLine("{0,3} ", 1);
            //Console.WriteLine("pbccmyxbcwffmybvajwt12");
            //Console.Write("".PadLeft(22));
            //Console.Write("{0,3} ", 1);
            //Console.Write("{0,3} ", 1);
            //Console.WriteLine("");


        }
    }
}
