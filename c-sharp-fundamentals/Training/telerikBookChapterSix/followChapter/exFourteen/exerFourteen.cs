using System;

namespace exFourteen
{
    class exerFourteen
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long faction = n;
            string[] hexadecimal = new string[16];


            for (int i = 0; i < hexadecimal.Length - 1; i++)
            {
                hexadecimal[i] = "0";
            }

            int counter = 0;

            for (long wholeNum = n; wholeNum > 0; wholeNum /= 16)
            {

                faction = wholeNum;
                faction %= 16;

                if (faction <= 9)
                {
                    hexadecimal[counter] = Convert.ToString(faction);
                }
                else
                {
                    switch (faction)
                    {
                        case 10:
                            hexadecimal[counter] = "A";
                            break;
                        case 11:
                            hexadecimal[counter] = "B";
                            break;
                        case 12:
                            hexadecimal[counter] = "C";
                            break;
                        case 13:
                            hexadecimal[counter] = "D";
                            break;
                        case 14:
                            hexadecimal[counter] = "E";
                            break;
                        default:
                            hexadecimal[counter] = "F";
                            break;
                    }

                }
                counter++;
            }


            for (int i = 1; i <= counter; i++)
            {
                Console.Write(hexadecimal[counter - i]);
            }


        }
    }
}
