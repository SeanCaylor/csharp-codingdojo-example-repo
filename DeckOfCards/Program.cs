using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            deck.Print();

            Player player = new Player("playa");
            player.Draw(deck);
            player.Draw(deck);
            player.Draw(deck);
            player.PrintHand();
        }
    }
}
