using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace War
{
    public class WarApp
    {
        private Player Player1;
        private Player Player2;
        public int TurnCount;


        public WarApp(string player1name, string player2name)
        {
            Player1 = new Player(player1name);
            Player2 = new Player(player2name);

            var cards = DeckUtility.CreateCards(); 

            var deck = Player1.Deal(cards); 
            Player2.Deck = deck;
            Play();
        }

        public void Play()
        {
            int totalTurnCount = 0;
            int finiteGameCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                //Create game
                while (!EndGame())
                {
                    Round();
                }

                if (TurnCount < 1000)
                {
                    totalTurnCount += TurnCount;
                    finiteGameCount++;
                }
            }
        }
        public void Round()
        {
            Queue<Card> holdings = new Queue<Card>();

            // Each player flips a card
            var player1card = Player1.Deck.Dequeue();
            var player2card = Player2.Deck.Dequeue();

            holdings.Enqueue(player1card);
            holdings.Enqueue(player2card);

            Console.WriteLine(Player1.Name + " plays " + player1card.ShowCard + ", " + Player2.Name + " plays " + player2card.ShowCard);

            while (player1card.ShowValue == player2card.ShowValue) // We have WAR!
            {
                Console.WriteLine("\nWAR! Both players lay three cards face down. The fourth card reveals...\n");
                Thread.Sleep(2000);
                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if (Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }

                // Add three face down cards to a holding pile for each player
                holdings.Enqueue(Player1.Deck.Dequeue());
                holdings.Enqueue(Player1.Deck.Dequeue());
                holdings.Enqueue(Player1.Deck.Dequeue());
                holdings.Enqueue(Player2.Deck.Dequeue());
                holdings.Enqueue(Player2.Deck.Dequeue());
                holdings.Enqueue(Player2.Deck.Dequeue());

                // player 1 plays the fourth card
                player1card = Player1.Deck.Dequeue();

                // player 2 plays the fourth card
                player2card = Player2.Deck.Dequeue();

                // pull the fourth card from each player's hand
                holdings.Enqueue(player1card);
                holdings.Enqueue(player2card);

                Console.WriteLine(Player1.Name + " plays " + player1card.ShowCard + ", " + Player2.Name + " plays " + player2card.ShowCard);
            }

            // Add the "won" cards to the winning player's deck, and display which player won that hand.
            // WAF: Here's that extension I needed to perform a specific task.

            if (player1card.ShowValue < player2card.ShowValue)
            {
                Player2.Deck.Enqueue(holdings);
                Console.WriteLine(Player2.Name + " takes the cards.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            else
            {
                Player1.Deck.Enqueue(holdings);
                Console.WriteLine(Player1.Name + " takes the cards.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            TurnCount++;
        }


    

        public bool EndGame()
        {
            if (!Player1.Deck.Any()) // Player 1 is out of cards.
            {
                Console.WriteLine(Player1.Name + " is out of cards.  " + Player2.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                System.Environment.Exit(0);


            }
            else if (!Player2.Deck.Any())
            {
                Console.WriteLine(Player2.Name + " is out of cards.  " + Player1.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                System.Environment.Exit(0);


            }
            // Pro tip: if you do not set a TurnCount a game of War can theoretically go on FOREVER.
           

            // Say that there exists 10 Billion people on every planet, 1 Billion planets in every solar system, 200 Billion solar
            // systems in every galaxy, and 500 Billion galaxies in the universe. If every single person on every planet has been
            // shuffling decks of cards completely at random at 1 Million shuffles per second since the BEGINNING OF TIME,
            // every possible deck combination would still yet to have been "shuffled".
            //
            // To be exact, 52! = 8 * 10^23.


            else if (TurnCount > 1000)
            {
                // If we can't resolve a winner by the 1000th turn, we declare an infinite game and end.
                Console.WriteLine("Game has exceeded 999 turns - stalemate.");
                System.Environment.Exit(0);
            }
            return false;
        }
    }
}