using System;
using System.Collections.Generic;

// Extension.cs
// Written by William A. Ferguson 020421


// WAF:
// This extension of Enqueue (Queue<T>) takes all the cards and places them in the Queue<> at once
// instead of one at a time for simplicity. The regular Enqueue method of Queue<T> would have worked just fine but I needed
// it to do something specific.
//
// Reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

namespace War
{
    public static class Extension
    {
        public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach (var card in newCards)
            {
                cards.Enqueue(card);
            }
        }
    }
}
