using System;

namespace exEighteen
{
    class exerEigtheen
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());
            int[,] k = new int[N, N];
            int flag = 0;
            int br = 1;
            int tempRight = N - 1;
            int tempLeft = 0;
            int tempTop = 0;
            int tempbot = N - 1;

            for (int i = 0; i < N * 2 - 1; i++)
            {
                if (flag == 0)
                {
                    for (int j = tempLeft; j <= tempRight; j++)
                    {
                        k[tempTop, j] = br;
                        br++;
                    }
                    flag++;
                    tempTop++;
                    continue;
                }
                if (flag == 1)
                {
                    for (int j = tempTop; j <= tempbot; j++)
                    {
                        k[j, tempRight] = br;
                        br++;
                    }
                    flag++;
                    tempRight--;
                    continue;
                }
                if (flag == 2)
                {
                    for (int j = tempRight; j >= tempLeft; j--)
                    {
                        k[tempbot, j] = br;
                        br++;
                    }
                    flag++;
                    tempbot--;
                    continue;
                }
                if (flag == 3)
                {
                    for (int j = tempbot; j >= tempTop; j--)
                    {
                        k[j, tempLeft] = br;
                        br++;
                    }
                    flag = 0;
                    tempLeft++;
                    continue;
                }
            }

            for (int i = 0; i < N; i++)
            {

                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0} ", k[i, j]);
                }
                Console.Write("\n");

            }

        }
    }
}
