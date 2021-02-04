using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

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
            for (int i = 0; i < 1000; i++)
            {
                //Create game
                while (!EndGame())
                {
                    Round();
                }

                if (Turns < 1000)
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

            Console.WriteLine(player_one.Name + " plays " + player1card.ShowCard + ", " + player_two.Name + " plays " + player2card.ShowCard);

            while (player1card.ShowValue == player2card.ShowValue) // We have WAR!
            {
                Console.WriteLine("\nWAR! Both players lay three cards face down. The fourth card reveals...\n");
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

                // Add three face down cards to a holding pile for each player
                holdings.Enqueue(player_one.Deck.Dequeue());
                holdings.Enqueue(player_one.Deck.Dequeue());
                holdings.Enqueue(player_one.Deck.Dequeue());
                holdings.Enqueue(player_two.Deck.Dequeue());
                holdings.Enqueue(player_two.Deck.Dequeue());
                holdings.Enqueue(player_two.Deck.Dequeue());

                // player 1 plays the fourth card
                player1card = player_one.Deck.Dequeue();

                // player 2 plays the fourth card
                player2card = player_two.Deck.Dequeue();

                // pull the fourth card from each player's hand
                holdings.Enqueue(player1card);
                holdings.Enqueue(player2card);

                Console.WriteLine(player_one.Name + " plays " + player1card.ShowCard + ", " + player_two.Name + " plays " + player2card.ShowCard);
            }

            // Add the "won" cards to the winning player's deck, and display which player won that hand.
            // WAF: Here's that extension I needed to perform a specific task.

            if (player1card.ShowValue < player2card.ShowValue)
            {
                player_two.Deck.Enqueue(holdings);
                Console.WriteLine(player_two.Name + " takes the cards.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            else
            {
                player_one.Deck.Enqueue(holdings);
                Console.WriteLine(player_one.Name + " takes the cards.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            Turns++;
        }


    

        public bool EndGame()
        {
            if (!player_one.Deck.Any()) // Player 1 is out of cards.
            {
                Console.WriteLine(player_one.Name + " has run out of cards.  " + player_two.Name + " WINS!");
                Console.WriteLine("TURNS: " + Turns.ToString());
                System.Environment.Exit(0);


            }
            else if (!player_two.Deck.Any())
            {
                Console.WriteLine(player_two.Name + " has run out of cards.  " + player_one.Name + " WINS!");
                Console.WriteLine("TURNS: " + Turns.ToString());
                System.Environment.Exit(0);


            }
            // Pro tip: if you do not set a TurnCount a game of War can theoretically go on FOREVER.
           

            // Say that there exists 10 Billion people on every planet, 1 Billion planets in every solar system, 200 Billion solar
            // systems in every galaxy, and 500 Billion galaxies in the universe. If every single person on every planet has been
            // shuffling decks of cards completely at random at 1 Million shuffles per second since the BEGINNING OF TIME,
            // every possible deck combination would still yet to have been "shuffled".
            //
            // To be exact, 52! = 8 * 10^69.


            else if (Turns > 1000)
            {
                // If we can't resolve a winner by the 1000th turn, we declare an infinite game and end.
                Console.WriteLine("Game has exceeded 999 turns - stalemate.");
                System.Environment.Exit(0);
            }
            return false;
        }
    }
}