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
                for (int value = 1; value <= 13; value++)
                {
                    pack.Add(new Card(value, suit));
                }
            }
        }

        static void swapCards(int i, int j)
        {
            Card swapBak = pack[i];
            pack[i] = pack[j];
            pack[j] = swapBak;
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
            int deckSize = pack.Count;

            if (typeOfShuffle == 1)
            {
                // Fisher-Yates Shuffle
                // This algorithm is derived from Durstenfeld's [1964]
                // Ref: https://dl.acm.org/doi/pdf/10.1145/364520.364540#.pdf via Wikipedia

                for (int i = deckSize - 1; i >= 1; i--)                         // This specific implementation works backwards through the deck
                {
                    int j = (int)Math.Round(new Random().NextDouble() * i);     // Random.NextDouble() creates a 0.0-1.0 float value, so multiplying by i gives a random value of an unshuffled card (integer [0-i])
                    swapCards(i, j);                                            // Finally, swap the cards at the random position and the current value of i.
                }

                return true;
            }

            else if (typeOfShuffle == 2)
            {
                // Riffle Shuffle

                int halfCount = deckSize / 2;

                // First the deck must be split into two
                Card[] halfA = pack.GetRange(0, halfCount).ToArray();                       // Obtains the lower half of the deck
                Card[] halfB = pack.GetRange(halfCount, deckSize - halfCount).ToArray();    // Obtains the higher half of the deck
                List<Card> shuffledDeck = new List<Card>();

                // Simulate the 'riffle'

                for (int i = 0; i < halfCount; i++)                // As both sides will have 26 cards each, a half-deck for loop can be used.
                {
                    shuffledDeck.Add(halfA[i]);             // This loop simulates the A-B-A-B stacking nature of a riffle shuffle.
                    shuffledDeck.Add(halfB[i]);
                }

                // If the halfs aren't even then there will always be one extra card in halfB that still needs to be added.
                if (halfB.Count() > halfCount)
                {
                    shuffledDeck.Add(halfB[halfB.Count() - 1]);         // If the deck had an odd number of cards in it when shuffled (for example if one was already dealt) then this accounts for the one left over card.
                }

                pack = shuffledDeck;                   // Set the deck to be the new shuffled pack.

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
            Card dealtCard = pack[0];
            pack.RemoveAt(0);
            return dealtCard;
            //Deals one card

        }
        public static List<Card> dealCard(int amount)
        {
            List<Card> cardRange = pack.GetRange(0, amount);
            pack.RemoveRange(0, amount);
            return cardRange;
            //Deals the number of cards specified by 'amount'
        }

        public static string ToString()                     // This returns the values of the deck array rather than the overarching deck object
        {
            string[] cardStrs = new string[pack.Count];

            for (int i = 0; i < pack.Count; i++)
            {
                cardStrs[i] = pack[i].ToString();
            }

            return string.Join(",", cardStrs);
        }
    }
}
