using System;
using System.Collections.Generic;

namespace BlackJack.Models
{
    public class Hand
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public int GetPoints()
        {
            int score = 0;

            foreach (var card in Cards)
            {
                score += card.Value;
            }

            if (score > 21)
            {
                var nAce = NumberAce();
                if (nAce== 0)
                {
                    return score;
                }

                while(nAce > 0)
                {
                    if (score > 21)
                    {
                        score -= 10;
                        --nAce;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return score;
        }

        public int NumberAce()
        {
            var ace = 0;
            foreach (var card in Cards)
            {
                if(card.Number == "A")
                {
                    ace++;
                }
            }
            return ace;
        }

        public bool HasBlackJack()
        {
            if (Cards.Count == 2)
            {
                var ace = false;
                var ten = false;
                foreach (var card in Cards)
                {
                    if (card.Value == 10)
                        ten = true;
                    if (card.Number == "A")
                        ace = true;
                }
                if (ace && ten)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
