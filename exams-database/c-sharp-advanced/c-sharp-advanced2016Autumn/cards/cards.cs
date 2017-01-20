using System;
using System.Collections.Generic;

namespace cards
{
    class cards
    {
        static void Main()
        {
            var cards = new string[] {"2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac", "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad", "2h", "3h", "4h", "5h", "6h", "7h",  "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah", "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As"};
            var hands = GetHands(int.Parse(Console.ReadLine()));
            CheckDeck(hands);
            long oddCards = GetOddCards(hands);
            var resultCards = GetResult(oddCards, cards);

            Console.WriteLine(string.Join(" ", resultCards));
        }

        static List<string> GetResult(long oddCards, string[] cards)
        {
            var resultCards = new List<string>();

            int position = 0;

            while (oddCards != 0)
            {
                while ((oddCards & 1) == 0)
                {
                    oddCards = oddCards >> 1;
                    ++position;
                }

                resultCards.Add(cards[position]);
                oddCards = oddCards & ~1;
            }
            return resultCards;
        }

        static long GetOddCards(long[] hands)
        {
            long oddCards = 0;
            for (int i = 0; i < hands.Length - 1; i++)
            {
                if (i == 0)
                {
                    oddCards = (hands[i] ^ hands[i + 1]);
                }
                else
                {
                    oddCards ^= hands[i + 1];
                }
            }
            return oddCards;
        }

        static void CheckDeck(long[] hands)
        {
            long deck = 0;
            for (int i = 0; i < hands.Length - 1; i++)
            {
                deck = (hands[i] | hands[i + 1]) | deck;
            }

            if (deck == 4503599627370495)
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }
        }

        static long[] GetHands(int n)
        {
            var hands = new long[n];

            for (int i = 0; i < n; i++)
            {
                hands[i] = long.Parse(Console.ReadLine());
            }

            return hands;
        }
    }
}
