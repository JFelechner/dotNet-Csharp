
using System;
namespace deck_of_cards
{

    // Create a class called "Card"
    public class Card
    {
        // Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a string.
        public string StringVal;

        // Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds).
        public string Suit;

        // Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers.
        public int Val;


        public Card(string cName, string cSuit, int cVal)
        {
            StringVal = cName;
            Suit = cSuit;
            Val = cVal;
        }

    }

}
