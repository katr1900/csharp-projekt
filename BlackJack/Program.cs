using System;
using BlackJack.Models;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Start a new game? (y/n): ");
                var input = Console.ReadLine();
                if (input == "y")
                {
                    var game = new Game();
                    game.NewGame();
                }
                else
                {
                    break;
                }
            }
           

            
        }
    }
}
