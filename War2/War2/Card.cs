
// Card.cs
// Written by William A. Ferguson 021121

namespace War2
{
    public class Card
    {

        public enum Suit // enumerated names of suits to represent our integer values
        {
            Clubs, // zero
            Diamonds, // one
            Spades, // two
            Hearts // three
        }

        // pretty much no explanation as to what these are for
        public string ShowCard { get; set; }
        public Suit ShowSuit { get; set; }
        public int ShowValue { get; set; }
    }

}

