using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            Reset();
        }

        public void Print()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(card);
            }
        }

        public Card Deal()
        {
            if (Cards.Count == 0)
            {
                return null;
            }

            Card cardToDeal = Cards[Cards.Count - 1];
            Cards.RemoveAt(Cards.Count - 1);
            return cardToDeal;
        }

        public void Reset()
        {
            Cards = new List<Card>();

            string[] suits = new string[]
            {
                "Clubs", "Spades", "Hearts", "Diamonds"
            };

            Dictionary<int, string> faceCardNames = new Dictionary<int, string>()
            {
                {1, "Ace"},
                {11, "Jack"},
                {12, "Queen"},
                {13, "King"}
            };

            foreach (string suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    string name = i.ToString();

                    if (faceCardNames.ContainsKey(i))
                    {
                        name = faceCardNames[i];
                    }

                    Card card = new Card(name, suit, i);
                    Cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();

            for (int i = 0; i < Cards.Count; i++)
            {
                int rand = rng.Next(Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[rand];
                Cards[rand] = temp;
            }
        }
    }
}