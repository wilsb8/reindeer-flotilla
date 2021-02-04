using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

// WarApp.cs
// Written by William A. Ferguson 020421

namespace War
{
    public class WarApp
    {
        private Player player_one;
        private Player player_two;
        public int Turns;


        public WarApp(string p1, string p2)
        {
            player_one = new Player(p1);
            player_two = new Player(p2);

            var cards = DeckUtility.CreateCards(); 

            var deck = player_one.Deal(cards); 
            player_two.Deck = deck;
            Play();
        }

        public void Play()
        {
            int total = 0;
            int count = 0;
            for (int i = 0; i <= 500; i++)
            {
                //Create game
                while (EndGame() == true)
                {
                    Round();
                }

                if (Turns <= 500)
                {
                    total += Turns;
                    count++;
                }
            }
        }
        public void Round()
        {
            Queue<Card> holdings = new Queue<Card>();

            // Each player flips a card
            var player1card = player_one.Deck.Dequeue();
            var player2card = player_two.Deck.Dequeue();

            holdings.Enqueue(player1card);
            holdings.Enqueue(player2card);

            
            Console.WriteLine("Round " + (Turns + 1) + ": " + player_one.Name + " plays " + player1card.ShowCard + ", " + player_two.Name + " plays " + player2card.ShowCard);
            Console.WriteLine(player_one.Name + " cards remaining: " + player_one.Deck.Count());
            Console.WriteLine(player_two.Name + " cards remaining: " + player_two.Deck.Count());
            while (player1card.ShowValue == player2card.ShowValue) // War is declared!
            {
                Console.WriteLine("\nIt's War! Both players lay three cards face down. The fourth card reveals...\n");
                Thread.Sleep(2000);
                if (player_one.Deck.Count < 4)
                {
                    player_one.Deck.Clear();
                    return;
                }
                if (player_two.Deck.Count < 4)
                {
                    player_two.Deck.Clear();
                    return;
                }

                // Three face down cards to a holding pile for each player
                holdings.Enqueue(player_one.Deck.Dequeue());
                holdings.Enqueue(player_one.Deck.Dequeue());
                holdings.Enqueue(player_one.Deck.Dequeue());
                holdings.Enqueue(player_two.Deck.Dequeue());
                holdings.Enqueue(player_two.Deck.Dequeue());
                holdings.Enqueue(player_two.Deck.Dequeue());

                // player 1 plays card #4
                player1card = player_one.Deck.Dequeue();

                // player 2 plays card #4
                player2card = player_two.Deck.Dequeue();

                // pull card #4 from each player's hand
                holdings.Enqueue(player1card);
                holdings.Enqueue(player2card);

                Console.WriteLine(player_one.Name + " plays " + player1card.ShowCard + ", " + player_two.Name + " plays " + player2card.ShowCard);
            }

            // Add the cards from the holdings pot to the winning player's deck, and display which player won that hand.
            // WAF: Here's that extension I needed to perform a specific task.

            if (player1card.ShowValue < player2card.ShowValue)
            {
                player_two.Deck.Enqueue(holdings);
                Console.WriteLine(player_two.Name + " wins this round.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            else
            {
                player_one.Deck.Enqueue(holdings);
                Console.WriteLine(player_one.Name + " wins this round.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            Turns++;
        }


    

        public bool EndGame()
        {
            if (player_one.Deck.Count() <= 3) // Player is out of cards.
            {
                Console.WriteLine(player_one.Name + " has run out of cards.  " + player_two.Name + " WINS!");
                Console.WriteLine("Number of rounds: " + Turns.ToString());
                DisplayScore(player_two.Name, player_two.Deck.Count());


            }
            else if (player_two.Deck.Count() <= 3)
            {
                Console.WriteLine(player_two.Name + " has run out of cards.  " + player_one.Name + " WINS!");
                Console.WriteLine("Number of rounds: " + Turns.ToString());
                DisplayScore(player_one.Name, player_one.Deck.Count());

            }
            // Pro tip: if you do not set a TurnCount a game of War can theoretically go on FOREVER.

            else if (Turns == 500)
            {
                // If we can't resolve a winner by the 500th round, we declare an infinite game and end.
                Console.WriteLine("Game has exceeded 500 rounds - stalemate.");
                Environment.Exit(0);
            }
            return true;
        }
        
        public void DisplayScore(string winner, int cards)
        {
            Console.WriteLine(winner + " wins the match with " + cards + " cards for a total of " + (cards * 2) + " points.");
            Environment.Exit(0);

        }
    }
}