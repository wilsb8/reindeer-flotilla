using System;

// Card.cs
// Written by William A. Ferguson 020421


// WAF:
// I decided to sacrifice a private integer for a public enum when it came time to put suits
// to the cards in the deck as this is easier to read and manage.
// Reference: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
//

namespace War
{
    public class Card
    { 

        public enum Suit // Much easier to work with than ubiquitous integers
        {
            Clubs, // zero
            Diamonds, // one
            Spades, // two
            Hearts // three
        }

        public string ShowCard { get; set; }
        public Suit ShowSuit { get; set; }
        public int ShowValue { get; set; }
    }
}