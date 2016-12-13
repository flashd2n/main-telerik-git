using System;

namespace exThirteen
{
    class exerThirteen
    {
        static void Main()
        {

            string binary = Console.ReadLine();
            long decimalBase = 1;
            long finalDecimal = 0;
            int hexIsNum = 0;

            for (int i = 0; i <= binary.Length - 1; i++)
            {
                char currentHex = binary[i];

                if (currentHex >= 97 && currentHex <= 102)
                {
                    currentHex = (char)(currentHex - 32);
                }

                switch ((int)currentHex)
                {
                    case 48:
                        hexIsNum = 0;
                        break;
                    case 49:
                        hexIsNum = 1;
                        break;
                    case 50:
                        hexIsNum = 2;
                        break;
                    case 51:
                        hexIsNum = 3;
                        break;
                    case 52:
                        hexIsNum = 4;
                        break;
                    case 53:
                        hexIsNum = 5;
                        break;
                    case 54:
                        hexIsNum = 6;
                        break;
                    case 55:
                        hexIsNum = 7;
                        break;
                    case 56:
                        hexIsNum = 8;
                        break;
                    case 57:
                        hexIsNum = 9;
                        break;
                    case 65:
                        hexIsNum = 10;
                        break;
                    case 66:
                        hexIsNum = 11;
                        break;
                    case 67:
                        hexIsNum = 12;
                        break;
                    case 68:
                        hexIsNum = 13;
                        break;
                    case 69:
                        hexIsNum = 14;
                        break;
                    case 70:
                        hexIsNum = 15;
                        break;
                    default:
                        Console.WriteLine("some error in switch");
                        break;
                }

                decimalBase = hexIsNum * ((long)Math.Pow(16, binary.Length - 1 - i));
                finalDecimal += decimalBase;
            }

            Console.WriteLine(finalDecimal);

        }
    }
}
