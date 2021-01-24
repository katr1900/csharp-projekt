using System;
using BlackJack.Enums;
namespace BlackJack.Models
{
    public class Game
    {
        private Hand dealer;
        private Hand player;
        private Random random;
        private Deck deck;
        private bool gameover;
        public void NewGame()
        {
            gameover = false;
            deck = new Deck();
            random = new Random();
            dealer = new Hand();
            player = new Hand();

            FirstDeal();
            Choice();
        }

        private void FirstDeal()
        {
            player.Cards.Add(deck.Cards[random.Next(51)]);
            player.Cards.Add(deck.Cards[random.Next(51)]);
            dealer.Cards.Add(deck.Cards[random.Next(51)]);
            dealer.Cards.Add(deck.Cards[random.Next(51)]);

            if (player.HasBlackJack())
            {
                PlayerWinsBlackJack();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Your cards: {Enum.GetName(typeof(Suits), player.Cards[0].Suit)} {player.Cards[0].Number}");
                Console.WriteLine($"Your cards: {Enum.GetName(typeof(Suits), player.Cards[1].Suit)} {player.Cards[1].Number}");
                Console.WriteLine($"Your points: {player.GetPoints()}");

                Console.WriteLine();
                Console.WriteLine($"Dealers cards: {Enum.GetName(typeof(Suits), dealer.Cards[0].Suit)} {dealer.Cards[0].Number}");
                Console.WriteLine($"Dealers cards: X");
                Console.WriteLine($"Dealers points: {dealer.Cards[0].Value}");
            }
        }

        private void Choice()
        {
            var playersTurn = true;
            while (playersTurn && !gameover)
            {
                Console.WriteLine("1. New Card");
                Console.WriteLine("2. Stay");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        NewCard();
                        break;
                    case "2":
                        playersTurn = false;
                        break;
                }

            }
            if (!gameover)
            {
                Dealer();

            }
        }

        private void NewCard()
        {
            player.Cards.Add(deck.Cards[random.Next(51)]);
            Console.WriteLine($"Your points: {player.GetPoints()}");

            if (player.GetPoints() > 21)
            {
                PlayerBust();
            }
        }
        private void DealerNewCard()
        {
            dealer.Cards.Add(deck.Cards[random.Next(51)]);
            Console.WriteLine($"Dealers points: {dealer.GetPoints()}");
        }

        private void PlayerBust()
        {
            Console.WriteLine("You are bust!");
            DealerWins();
        }
        private void Dealer()
        {
            if (dealer.HasBlackJack())
            {
                DealerWinsBlackJack();
            }
            else if (dealer.GetPoints() >= 17 && dealer.GetPoints() < 21)
            {
                var winner = ComparePoints();
                switch (winner)
                {
                    case Score.Draw:
                        Draw();
                         break;
                    case Score.Player:
                        PlayerWins();
                        break;
                    case Score.Dealer:
                        DealerWins();
                        break;
                }


            }
            else if (dealer.GetPoints() > 21)
            {
                PlayerWins();
            }
            else if (dealer.GetPoints() < 17)
            {
                DealerNewCard();
                Dealer();
            }
        }
        private void PlayerWins()
        {
            Console.WriteLine("Player wins");
            Console.WriteLine($"Your points: {player.GetPoints()}");
            Console.WriteLine($"Dealers points: {dealer.GetPoints()}");
            gameover = true;
        }

        private void PlayerWinsBlackJack()
        {
            Console.WriteLine("Player wins Black Jack");
            gameover = true;
        }
        private void Draw()
        {
            Console.WriteLine("Draw");
            Console.WriteLine($"Your points: {player.GetPoints()}");
            Console.WriteLine($"Dealers points: {dealer.GetPoints()}");
            gameover = true;

        }
        private void DealerWinsBlackJack()
        {
            Console.WriteLine("Dealer wins Black Jack");
            Console.WriteLine($"Your points: {player.GetPoints()}");
            gameover = true;

        }
        private void DealerWins()
        {
            Console.WriteLine("Dealer wins");
            Console.WriteLine($"Your points: {player.GetPoints()}");
            Console.WriteLine($"Dealers points: {dealer.GetPoints()}");
            gameover = true;

        }

        private Enums.Score ComparePoints()
        {
            if (player.GetPoints() == dealer.GetPoints())
            {
                return Enums.Score.Draw;
            }
            else if (player.GetPoints() > dealer.GetPoints())
            {
                return Enums.Score.Player;
            }
            else if (dealer.GetPoints() > player.GetPoints())
            {
                return Enums.Score.Dealer;
            }
            return Enums.Score.Draw;
        }


    }
}

