using System;

namespace exFour
{
    class exerFour
    {
        static void Main()
        {
            string input = Console.ReadLine();

            char inputCode = input[0];

            if (inputCode >= 97 )
            {
                inputCode = (char)(inputCode - 32);

            }

            int cardNumber = 0;
            switch ((int)inputCode)
            {
                case 49:
                    cardNumber = 10;
                    break;
                case 50:
                    cardNumber = 2;
                    break;
                case 51:
                    cardNumber = 3;
                    break;
                case 52:
                    cardNumber = 4;
                    break;
                case 53:
                    cardNumber = 5;
                    break;
                case 54:
                    cardNumber = 6;
                    break;
                case 55:
                    cardNumber = 7;
                    break;
                case 56:
                    cardNumber = 8;
                    break;
                case 57:
                    cardNumber = 9;
                    break;
                case 65:
                    cardNumber = 14; // A 
                    break;
                case 75:
                    cardNumber = 13; // K
                    break;
                case 74:
                    cardNumber = 11; // J
                    break;
                case 81:
                    cardNumber = 12; // Q
                    break;
                default:
                    Console.WriteLine("switch error");
                    break;
            }


            string[] cardTypes = { "spades", "clubs", "hearts", "diamonds" };
            string[] possibleCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            for (int i = 0; i <= cardNumber - 2; i++)
            {
                for (int j = 0; j <= 3; j++)
                {

                    if (j == 0)
                    {
                        Console.Write("{0} of {1}", possibleCards[i], cardTypes[j]);
                    }
                    else
                    {
                        Console.Write(", {0} of {1}", possibleCards[i], cardTypes[j]);
                    }
                }
                Console.WriteLine("");

            }
        }
    }
}
