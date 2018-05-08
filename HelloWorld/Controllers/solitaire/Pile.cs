using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Controllers.solitaire
{
    public class Pile
    {
        private List<Card> pile;

        public Pile(Suit s)
        {
            pile = new List<Card>();
            pile.Add(new Card(0, s));
        }

        public bool MoveTo(Card c)
        {
            if ((pile[pile.Count - 1].getValue() == c.getValue() - 1) && (pile[pile.Count - 1].getSuit() == c.getSuit()))
            {
                pile.Add(c);
                return true;
            }
            return false;
        }
    }
}