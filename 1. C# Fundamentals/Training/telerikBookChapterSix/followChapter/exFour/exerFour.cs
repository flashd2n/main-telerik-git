using System;

namespace exFour
{
    class exerFour
    {
        static void Main()
        {
            string[] cardTypes = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] possibleCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K" };

            foreach (string currentType in cardTypes)
            {
                foreach (string currentCard in possibleCards)
                {
                    Console.WriteLine("{0} of {1}", currentCard, currentType);
                }
            }
        }
    }
}
