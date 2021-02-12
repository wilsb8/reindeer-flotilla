using System;
using System.Collections.Generic;
using System.Threading;

// DeckUtility.cs
// Modified from Queue<T> to List<T>
// written by William A. Ferguson 021121

namespace War2
{
    public class DeckUtility
    {

        public static List<Card> CreateDeck()
        {
            Console.WriteLine("Creating cards...");
            Thread.Sleep(1500);
            List<Card> cards = new List<Card>();
            for (int i = 2; i <= 14; i++) // create 13 cards of each suit
            {
                foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
                {
                    cards.Add(new Card() { ShowSuit = suit, ShowValue = i, ShowCard = CardName(i, suit) }); // give our cards suit and value
                }
            }   

            return ShuffleDeck(cards); // shuffle the deck

        }

        public static List<Card> ShuffleDeck(List<Card> old_deck)
        {
            List<Card> new_deck = new List<Card>();
            Random rand = new Random();
            int r;
            Console.WriteLine("Shuffling the deck...");
            Thread.Sleep(1500);
            while (old_deck.Count > 0)
            {
                r = rand.Next(0, old_deck.Count - 1);
                new_deck.Add(old_deck[r]);
                old_deck.RemoveAt(r);
            }
            return new_deck;
        }

        
        public static Dictionary<string, List<Card>> DivideDeck(List<Card> deck)
        {
            // this method goes through a single list of 52 cards, splits it in
            // two halves and returns a Dictionary with the two bits
            List<Card> first = new List<Card>();
            List<Card> second = new List<Card>();
            Dictionary<string, List<Card>> pair = new Dictionary<string, List<Card>>();

            for (int i = 0; i < 52; i++)
            {
                if (i > 25)
                {
                    first.Add(deck[i]);
                }
                else
                {
                    second.Add(deck[i]);
                }
            }
            pair.Add("first_half", first);
            pair.Add("second_half", second);
            return pair;
        }
        


        private static string CardName(int value, Card.Suit suit) // show the values and suits of our deck
        {
            string valueDisplay = "";
            if (value >= 2 && value <= 10)
            {
                valueDisplay = value.ToString(); // Anything not a face card
            }
            else if (value == 11) // The rest of this is self explanitory.
            {
                valueDisplay = "J";
            }
            else if (value == 12)
            {
                valueDisplay = "Q";
            }
            else if (value == 13)
            {
                valueDisplay = "K";
            }
            else if (value == 14)
            {
                valueDisplay = "A";
            }

            return valueDisplay + Enum.GetName(typeof(Card.Suit), suit)[0]; // Show us the card value and suit of card and first letter of the suit name.

        }
    }
}
