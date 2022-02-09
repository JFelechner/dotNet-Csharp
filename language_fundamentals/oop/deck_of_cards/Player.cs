
using System.Collections.Generic;

namespace deck_of_cards
{

    // 1.) Give the Player class a name property.
    public class Player
    {
        //name property
        public string Name;
        // 2.) Give the Player a hand property that is a List of type Card.
        public List<Card> Hand;

        public Player(string playerName)
        {
            Name = playerName;
            Hand = new List<Card>();
        }


        // 3.) Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card.
        public Card draw(Deck delt)
        {
            Card drawnCard = delt.dealCards();
            Hand.Add(drawnCard);
            return drawnCard;
        }


        // 4.) Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.
        public Card discard(int i)
        {
            if (i < 0 || i > Hand.Count)
            {
                System.Console.WriteLine("null, does not exist");
                return null;
            }
            else
            {
                Card pulledCard = Hand[i];
                Hand.RemoveAt(i);
                return pulledCard;
            }
        }

    }

}