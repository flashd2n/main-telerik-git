using System;

namespace exTwelve
{
    class exerTwelve
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int faction = n;
            int[] binary = new int[32];
            int counter = 0;

            for (int whole = n; whole >= 1; whole /= 2)
            {

                faction = whole;
                faction %= 2;

                binary[counter] = faction;

                //Console.Write(binary[counter]);
                counter++;
            }

            //Console.WriteLine("NOW REVERSE IT");

            for (int i = 1; i <= counter; i++)
            {
                Console.Write(binary[counter - i]);
            }
        }
    }
}
