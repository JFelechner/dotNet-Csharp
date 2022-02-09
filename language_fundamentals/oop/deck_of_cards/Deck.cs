
using System;
using System.Collections.Generic;

namespace deck_of_cards
{

    // Next, create a class called "Deck"
    public class Deck
    {
        // 1.) Give the Deck class a property called "cards" which is a list of Card objects.
        // 2.) When initializing the deck, make sure that it has a list of 52 unique cards as its "cards" property.
        public List<Card> Cards;


        // 3.) Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card.
        public Card dealCards()
        {
            if (Cards.Count > 0)
            {
                Card pulledCard = Cards[0];
                Cards.RemoveAt(0);
                return pulledCard;
            }
            else
            {
                reset();
                return dealCards();
            }
        }

        //Reset and Shuffle functions
        public Deck()
        {
            reset();
            shuffDeck();
        }

        // 4.) Give the Deck a reset method that resets the cards property to contain the original 52 cards.
        public Deck reset()
        {
            Cards = new List<Card>();
            string[] cardSuits = { "Hearts", "Diamonds", "Spades", "Clubs" };
            string[] stringValues = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            foreach (string Suit in cardSuits)
            {
                for (int i = 0; i < stringValues.Length; i++)
                {
                    Card drawnCard = new Card(stringValues[i], Suit, i + 1);
                    Cards.Add(drawnCard);
                }
            }
            return this;
        }


        // 5.) Give the Deck a shuffle method that randomly reorders the deck's cards.
        public Deck shuffDeck()
        {
            Random random = new Random();
            for (int deckEnd = Cards.Count - 1; deckEnd > 0; deckEnd--)
            {
                int randomIndex = random.Next(deckEnd);
                Card temp = Cards[randomIndex];
                Cards[randomIndex] = Cards[deckEnd];
                Cards[deckEnd] = temp;
            }
            return this;
        }

    }

}
