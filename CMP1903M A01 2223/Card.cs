using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card(int value, int suit)
        {
            // Cards must always be between 1-13 in value and 1-4 in suit, otherwise throw range exception
            // This is so that they follow the same rules as a standard deck of cards.

            // These exceptions are mainly for the benefit of a programmer - they shouldn't ever appear during regular usage of the
            // program. As a result, I do not perform exception handling surrounding these.
            if (value <= 0 || value > 13)
            {
                // If this error was thrown, then it means that more than 13 cards (or less than 1) were created for a suit
                throw new ArgumentOutOfRangeException("Integer 'value' must only be between 1 and 13 (inclusive)");
            }

            else if (suit <= 0 || suit > 4)
            {
                // If this error was thrown, then it means that more than 4 suits (or less than 1) were created.
                throw new ArgumentOutOfRangeException("Integer 'suit' must only be between 1 and 4 (inclusive)");
            }

            else
            {
                Value = value;
                Suit = suit;
            }
        }

        public string ToString()
        {
            return ("Card(" + Suit.ToString() + "," + Value.ToString() + ")");
        }
    }
}
