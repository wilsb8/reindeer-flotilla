using System;
using System.Collections.Generic;
using System.Linq;

namespace War
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Deck { get; set; } 

        public Player(string name)
        {
            Name = name;
        }

        public Queue<Card> Deal(Queue<Card> cards)
        {
            Queue<Card> p1 = new Queue<Card>();
            Queue<Card> p2 = new Queue<Card>();

            int counter = 2;
            while (cards.Any())
            { // distribute our cards evenly
                if (counter % 2 == 0) 
                {
                    p2.Enqueue(cards.Dequeue());
                }
                else
                {
                    p1.Enqueue(cards.Dequeue());
                }
                counter++;
            }

            Deck = p1; // Player 1 keeps their cards
            return p2; // Give player 2 their cards.
        }
    }




}
