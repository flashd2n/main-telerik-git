using System;
using System.Collections.Generic;

namespace cardsMorning
{
    class cardsMorning
    {
        static void Main()
        {
            var cards = new string[] { "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac", "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad", "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah", "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As" };
            var allEvenCards = new List<string>();
            int n = int.Parse(Console.ReadLine());
            var hands = new long[n];
            hands = SetHands(hands);
            CheckDeck(hands);
            long evenCards = GetEvenCards(hands);
            long position = 0;
            long mask = 1L;

            while (evenCards != 0)
            {

                while ((evenCards & 1) == 1)
                {
                    evenCards = evenCards >> 1;
                    ++position;
                }

                if (position >= 52)
                {
                    break;
                }

                allEvenCards.Add(cards[position]);
                evenCards = evenCards | mask;

            }

            string result = string.Join(" ", allEvenCards);
            Console.WriteLine(result);
        }

        static long GetEvenCards(long[] hands)
        {
            long temp = 0;

            for (int i = 0; i < hands.Length - 1; i++)
            {
                if (i == 0)
                {
                    temp = hands[i] ^ hands[i + 1];
                    continue;
                }

                temp = temp ^ hands[i + 1];
            }
            return temp;
        }

        static void CheckDeck(long[] hands)
        {
            long temp = 0;
            for (int i = 0; i < hands.Length - 1; i++)
            {
                temp = (hands[i] | hands[i + 1]) | temp;
            }

            if (temp == 4503599627370495)
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }
        }

        static long[] SetHands(long[] hands)
        {
            for (int i = 0; i < hands.Length; i++)
            {
                hands[i] = long.Parse(Console.ReadLine());
            }

            return hands;
        }
    }
}
