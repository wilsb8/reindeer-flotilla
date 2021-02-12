using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// WarApp.cs
// Written by William A. Ferguson 021121

namespace War2
{
    public class WarApp
    {
        private static Player p1;
        private static Player p2;
        public static int Rounds;
        public WarApp(string x, string y)
        {
            p1 = new Player(x); //init player 1
            p2 = new Player(y); // init player 2
            // create the deck
            var gameDeck = DeckUtility.CreateDeck(); // create our deck of cards
            // give each of our players half a deck
            p1.Pile = DeckUtility.DivideDeck(gameDeck)["first_half"]; // player one gets the first half of the pile
            p2.Pile = DeckUtility.DivideDeck(gameDeck)["second_half"]; // player two gets the second half of the pile

            Play();

        }

        public void Play()
        {
            int total = 0;
            int count = 0;
            for (int i = 0; i <= 500; i++) // before we hit 500th round
            {
                // play the game until EndGame is true
                while (EndGame() == false)
                {
                    Round();
                }

                if (Rounds <= 500)
                {
                    total += Rounds;
                    count++;
                }
            }
        }

        public void Round()
        {
            List<Card> pool = new List<Card>(); // create a pool of cards

            // Each player flips a card
            var player1card = p1.Pile.Take();
            var player2card = p2.Pile.Take();
            // each player shows their card
            pool.Give(player1card);
            pool.Give(player2card);
            // show round and cards played
            Console.WriteLine("Round " + (Rounds + 1) + ": " + p1.Name + " plays " + player1card.ShowCard + ", " + p2.Name + " plays " + player2card.ShowCard);
            Console.WriteLine(p1.Name + " cards remaining: " + p1.Pile.Count());
            Console.WriteLine(p2.Name + " cards remaining: " + p2.Pile.Count());

            while (player1card.ShowValue == player2card.ShowValue) // War is declared!
            {
                Console.WriteLine("\nIt's War! Both players lay three cards face down. The fourth card reveals...\n");
                Thread.Sleep(2000);
                if (p1.Pile.Count < 4)
                {
                    p1.Pile.Clear();
                    return;
                }
                if (p2.Pile.Count < 4)
                {
                    p2.Pile.Clear();
                    return;
                }

                // player 1 puts 3 cards face down
                pool.Give(p1.Pile.Take());
                pool.Give(p1.Pile.Take());
                pool.Give(p1.Pile.Take());

                // player 2 puts 3 cards face down
                pool.Give(p2.Pile.Take());
                pool.Give(p2.Pile.Take());
                pool.Give(p2.Pile.Take());

                // player 1 puts card 4 face up
                player1card = p1.Pile.Take();
                // player 2 puts card 4 face up
                player2card = p2.Pile.Take();
                // one card from each player will be revealed and compared
                pool.Give(player1card);
                pool.Give(player2card);
                Console.WriteLine(p1.Name + " plays " + player1card.ShowCard + ", " + p2.Name + " plays " + player2card.ShowCard);

            }
            // player 2 wins this round
            if (player1card.ShowValue < player2card.ShowValue)
            {
                p1.Pile.GiveTo(pool);
                Console.WriteLine(p2.Name + " wins this round.");
                Console.WriteLine();
                Thread.Sleep(2500);
            }
            else
            {
                // player 1 wins this round
                p2.Pile.GiveTo(pool);
                Console.WriteLine(p1.Name + " wins this round.");
                Console.WriteLine();
                Thread.Sleep(2500);
            }
            // keep a running tabulation of how many rounds played
            Rounds++;
        }

        public bool EndGame()
        {
            if (p1.Pile.Count() <= 3) // Player is out of cards/doesn't have enough cards to make War
            {
                Console.WriteLine(p1.Name + " has run out of cards.  " + p2.Name + " WINS!");
                Console.WriteLine("Number of rounds: " + Rounds.ToString());
                // give player score and how many cards they hold
                DisplayScore(p2.Name, p1.Pile.Count());


            }
            else if (p2.Pile.Count() <= 3) // Player is out of cards/doesn't have enough cards to make War
            {
                Console.WriteLine(p2.Name + " has run out of cards.  " + p1.Name + " WINS!");
                Console.WriteLine("Number of rounds: " + Rounds.ToString());
                // give player score and how many cards they hold
                DisplayScore(p2.Name, p1.Pile.Count());

            }


            else if (Rounds == 500) // we have hit 500 rounds
            {
                // If we can't resolve a winner by the 500th round, we declare an infinite game and end.
                Console.WriteLine("Game has exceeded 500 rounds - stalemate.");
                Environment.Exit(0);
            }

            return false; // keep telling our loop we don't want to end the game
        }

        public void DisplayScore(string winner, int cards)
        {
            // score is tabulated by how many cards remain in the loser's hand * 2 per card
            if (cards == 0)
            {
                Player.Score = 100; // award 100 points if the other player has no cards (perfect wipeout)
            }
            else
            {
                Player.Score = cards * 2;
                Console.WriteLine(winner + " wins the match with " + cards + " cards for a total of " + Player.Score + " points.");
            }
            Environment.Exit(0);

        }
    }
}