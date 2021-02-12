using System.Collections.Generic;

namespace War2
{
    public class Player
    {
        public string Name { get; set; } // name
        public static int Score { get; set; } // score
        public List<Card> Pile { get; set; } // player's pile 26 each
        // constructor - gets the player's name
        public Player(string name)
        {
            Name = name;
        }

        // overload constructor - takes a seperate argument to give our players their own pile of cards
        // WAF: this is about the only way I could see doing this. if anyone has a better idea...

        public Player(List<Card> pile) 
        {
            Pile = pile;
        }


    }

}
