using System;

namespace playCard
{
    class playCards
    {
        static void Main()
        {
            string myCards = Console.ReadLine();

            if (myCards == "J" || myCards == "Q" || myCards == "K" || myCards == "A")
            {
                Console.WriteLine("yes {0}", myCards);
            }
            else if (myCards == "2" || myCards == "3" || myCards == "4" || myCards == "5" || myCards == "6" || myCards == "7" || myCards == "8" || myCards == "9" || myCards == "10")
            {
                Console.WriteLine("yes {0}", myCards);
            }
            else
            {
                Console.WriteLine("no {0}", myCards);
            }
        }
    }
}
