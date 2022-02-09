using System;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck Game1 = new Deck();
            Player John = new Player("John");
            Console.WriteLine("Player name: " + John.Name);
            Console.WriteLine("Deck count: " + Game1.Cards.Count);
            John.draw(Game1);
            John.draw(Game1);
            John.draw(Game1);
            John.draw(Game1);
            John.draw(Game1);
            Console.WriteLine("Johns hand: " + John.Hand.Count);

        }
    }
}
