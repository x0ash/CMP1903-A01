using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        static List<Card> pack;

        public Pack()
        {
            //Initialise the card pack here
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    pack.Append(new Card(value, suit));
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
            //Shuffles the pack based on the type of shuffle
            if (typeOfShuffle == 1)
            {
                // Fisher-Yates Shuffle
                // This algorithm is derived from Durstenfeld's [1964]

                for (int i = 51; i >= 1; i--)
                {
                    int j = (int)Math.Round(new Random().NextDouble() * i);
                    swap_cards(i, j);
                }

                return true;
            }

            else if (typeOfShuffle == 2)
            {
                // Riffle Shuffle
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
            //Deals one card

        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
        }
    }
}
