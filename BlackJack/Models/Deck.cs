using System;
using System.Collections.Generic;

namespace BlackJack.Models
{
    public class Deck
    {
        public Deck()
        {
            CreateDeck();
        }

        public List<Card> Cards { get; set; }

        public void CreateDeck()
        {
            Cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 11; j++)
                {
                    var card = new Card
                    {
                        Value = j,
                        Color = i%2,
                        Number = j.ToString(),
                        Suit = i
                    };
                    Cards.Add(card);
                }

                var knight = new Card
                {
                    Value = 10,
                    Color = i % 2,
                    Number = "J",
                    Suit = i

                };
                Cards.Add(knight);

                var queen = new Card
                {
                    Value = 10,
                    Color = i % 2,
                    Number = "Q",
                    Suit = i

                };
                Cards.Add(queen);

                var king = new Card
                {
                    Value = 10,
                    Color = i % 2,
                    Number = "K",
                    Suit = i

                };
                Cards.Add(king);

                var ace = new Card
                {
                    Value = 11,
                    Color = i % 2,
                    Number = "A",
                    Suit = i

                };
                Cards.Add(ace);
            }
        }
    }
}

