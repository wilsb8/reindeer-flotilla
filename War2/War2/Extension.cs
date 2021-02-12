using System.Collections.Generic;
using System.Linq;

// Extension.cs
// written by William A. Ferguson 021121

namespace War2
{
    public static class Extension
    {
        public static Card Take(this List<Card> cards) // removes the first card from the list
        {
            var card = cards.First();
            cards.RemoveAt(0);
            return card;
        }

        public static void Give(this List<Card> cards, Card card) // inserts the first card from the list
        {
            cards.Insert(0, card);
        }

        public static void GiveTo(this List<Card> cards, List<Card> newCards) // inserts Nth card at the bottom of the deck
        {
            foreach (var card in newCards)
            {
                cards.Insert(cards.Count, card);
            }
        }
    }
}
