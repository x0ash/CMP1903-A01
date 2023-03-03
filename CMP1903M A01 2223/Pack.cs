using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        static List<Card> pack = new List<Card>();

        public Pack()
        {
            //Initialise the card pack here - 52 cards
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 14; value++)
                {
                    pack.Add(new Card(value, suit));
                }
            }
        }

        static void swap_cards(int i, int j)
        {
            Card swap_bak = pack[i];
            pack[i] = pack[j];
            pack[j] = swap_bak;
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            /// <summary>
            /// Shuffles the deck in two ways.
            /// Usage: shuffleCardPack(1/2/3)
            ///
            /// 1: Fisher-Yates Shuffle
            /// 2: Riffle Shuffle
            /// 3: No Shuffle
            /// 
            /// Any parameter outside 1-3 will return false for error handling
            /// </summary>

            //Shuffles the pack based on the type of shuffle

            // Keeping track of the deck size allows the deck to be shuffled after cards have been dealt
            int deck_size = pack.Count;

            if (typeOfShuffle == 1)
            {
                // Fisher-Yates Shuffle
                // This algorithm is derived from Durstenfeld's [1964]
                // Ref: https://dl.acm.org/doi/pdf/10.1145/364520.364540#.pdf via Wikipedia

                for (int i = deck_size - 1; i >= 1; i--)
                {
                    int j = (int)Math.Round(new Random().NextDouble() * i);
                    swap_cards(i, j);
                }

                return true;
            }

            else if (typeOfShuffle == 2)
            {
                // Riffle Shuffle

                int half_count = deck_size / 2;

                // First the deck must be split into two
                Card[] halfA = pack.GetRange(0, half_count).ToArray();
                Card[] halfB = pack.GetRange(half_count, deck_size - half_count).ToArray();
                List<Card> shuffled_deck = new List<Card>();

                // Simulate the 'riffle'

                for (int i = 0; i < half_count; i++)                // As both sides will have 26 cards each, a half-deck for loop can be used.
                {
                    shuffled_deck.Add(halfA[i]);
                    shuffled_deck.Add(halfB[i]);
                }

                // If the halfs aren't even then there will always be one extra card in halfB that still needs to be added.
                if (halfB.Count() > half_count)
                {
                    shuffled_deck.Add(halfB[halfB.Count() - 1]);
                }

                pack = shuffled_deck;                   // Set the deck to be the new shuffled pack.

                return true;
            }

            else if (typeOfShuffle == 3)
            {
                // No Shuffle
                return true;
            }

            else
            {
                // Invalid Input
                return false;
            }

        }
        public static Card deal()
        {
            Card dealt_card = pack[0];
            pack.RemoveAt(0);
            return dealt_card;
            //Deals one card

        }
        public static List<Card> dealCard(int amount)
        {
            List<Card> card_range = pack.GetRange(0, amount);
            pack.RemoveRange(0, amount);
            return card_range;
            //Deals the number of cards specified by 'amount'
        }

        public static string ToString()                     // This returns the values of the deck array rather than the overarching deck object
        {
            string[] card_strs = new string[pack.Count];

            for (int i = 0; i < pack.Count; i++)
            {
                card_strs[i] = "Card(" + pack[i].Suit.ToString() + ", " + pack[i].Value.ToString() + ")";
            }

            return string.Join(",", card_strs);
        }
    }
}
