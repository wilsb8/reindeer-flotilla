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
            Queue<Card> player1 = new Queue<Card>();
            Queue<Card> player2 = new Queue<Card>();

            int counter = 2;
            while (cards.Any())
            { // distribute our cards evenly, 26 per player
                if (counter % 2 == 0) 
                {
                    player2.Enqueue(cards.Dequeue());
                }
                else
                {
                    player1.Enqueue(cards.Dequeue());
                }
                counter++;
            }

            Deck = player1;
            return player2;
        }
    }




}
