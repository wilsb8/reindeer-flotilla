using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace War
{
    public class DeckUtility
    {

        public static Queue<Card> CreateCards() 
        {
            Console.WriteLine("Building the deck...");
            Thread.Sleep(1500);
            Queue<Card> cards = new Queue<Card>();
            for (int i = 2; i <= 14; i++) // make 13 cards per suit, each card will have a value from 2 to 14.
            {
                foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit))) // get our enumerated Suit types
                {
                    // by the way, a deck of cards (especially in War) runs from the lowest (2) to the highest (A) which is given
                    // a value of 14. this actually makes perfect sense and directly reflects a real world deck of cards.
                    //
                    // here we stuff our sequenced suited cards into the Queue from 2 to Ace.
                    cards.Enqueue(new Card() { ShowSuit = suit, ShowValue = i, ShowCard = CardName(i, suit) } );
                    Console.WriteLine(i + " " + suit);
                }
            }
            // now our card deck is created in a sequence from 2 to 14 of each suit, it is now time to shuffle the
            // deck

            return Shuffle(cards); // shuffle the deck
        }


        // WAF: This is a Fisher-Yates shuffling algorithm as it's the most efficient sorting algorithm out there.
        // Reference:
        // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

        private static Queue<Card> Shuffle(Queue<Card> cards)
        {
            Console.WriteLine("\nShuffling the cards...\n");
            Thread.Sleep(1500);
            List<Card> notShuffled = cards.ToList();
            // For a longer game and a better shuffle, change the following from Second to Millisecond.
            Random r = new Random(DateTime.Now.Second); // random seed generator based on seconds
            for (int n = notShuffled.Count - 1; n > 0; --n) 
            {

                int k = r.Next(n + 1); // Randomly pick a card that has not been shuffled

                // Swap the card that hasn't been shuffled with the last unselected card in the collection.
                Card temp = notShuffled[n];
                notShuffled[n] = notShuffled[k];
                notShuffled[k] = temp;
            }

            Queue<Card> shuffledCards = new Queue<Card>(); 
            foreach (var card in notShuffled)
            {
                shuffledCards.Enqueue(card); // Stuff the entire collection into the "shuffled" pile.
            }

            return shuffledCards;
        }

       

        private static string CardName(int value, Card.Suit suit)
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
