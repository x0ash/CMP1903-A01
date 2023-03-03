﻿using System;
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
            //Initialise the card pack here
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 13; value++)
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

                // First the deck must be split into two
                Card[] halfA = pack.GetRange(0, 26).ToArray();
                Card[] halfB = pack.GetRange(26, 26).ToArray();
                List<Card> shuffled_deck = new List<Card>();

                // Simulate the 'riffle'

                for (int i = 0; i < 26; i++)                // As both sides will have 26 cards each, a half-deck for loop can be used.
                {
                    shuffled_deck.Append(halfA[i]);
                    shuffled_deck.Append(halfB[i]);
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
            return pack[0];
            //Deals one card

        }
        public static List<Card> dealCard(int amount)
        {
            return pack.GetRange(0, amount);
            //Deals the number of cards specified by 'amount'
        }

        public static string ToString()
        {
            string[] card_strs = new string[52];

            for (int i = 0; i < 52; i++)
            {
                card_strs[i] = "Card(" + pack[i].Suit.ToString() + ", " + pack[i].Value.ToString() + ")";
            }

            return string.Join(",", card_strs);
        }
    }
}
