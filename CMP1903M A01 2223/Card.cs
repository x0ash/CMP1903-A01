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
            if (value <= 0 || value > 13)
            {
                throw new ArgumentOutOfRangeException("Integer 'value' must only be between 1 and 13 (inclusive)");
            }

            else if (suit <= 0 || suit > 4)
            {
                throw new ArgumentOutOfRangeException("Integer 'suit' must only be between 1 and 4 (inclusive)");
            }

            else
            {
                Value = value;
                Suit = suit;
            }
        }
    }
}
