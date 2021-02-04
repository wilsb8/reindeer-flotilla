using System;
using System.Collections.Generic;
using System.Linq;

// WAF: Hi there.
// I decided that the best way to approach this problem was not by List<> and Dictionary<> but by Queue<>.
// Not that what you did was in any way wrong, just that I wanted a simpler method by which to create and shuffle
// a *collection* of cards.

namespace War
{
    public class DeckUtility
    {

        public static Queue<Card> CreateCards() 
        {
            
            Queue<Card> cards = new Queue<Card>();
            for (int i = 2; i <= 14; i++) // make 13 cards per suit, each card will have a value from 2 to 14.
            {
                foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit))) // get our enumerated Suit types
                {
                    // by the way, a deck of cards (especially in War) runs from the lowest (2) to the highest (A) which is given
                    // a value of 14. this actually makes perfect sense and directly reflects a real world deck of cards.
                    //
                    // here we stuff our sequenced suited cards into the Queue from 2 to Ace.
                    cards.Enqueue(new Card() { ShowSuit = suit, ShowValue = i, ShowCard = ShortName(i, suit) } );
                    
                }
            }
            // now our card deck is created in a sequence from 2 to 14 of each suit, it is now time to shuffle the
            // deck

            return ShuffleCards(cards); // shuffle the deck
        }


        // WAF: This is a Fisher-Yates shuffling algorithm as it's the most efficient sorting algorithm out there.
        // Reference:
        // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

        private static Queue<Card> ShuffleCards(Queue<Card> cards)
        {
            List<Card> notShuffled = cards.ToList(); 
            Random r = new Random(DateTime.Now.Millisecond); // random seed generator based on ms time.
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

        // WAF: Rather than give long names to our cards suits and values I have opted to go with a ShortName
        // convention.

        private static string ShortName(int value, Card.Suit suit)
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

            return valueDisplay + Enum.GetName(typeof(Card.Suit), suit)[0]; // Show us the card value and suit of card.
        }


    }
}
