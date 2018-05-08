using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Controllers.solitaire
{
    public class Card
    {
        private int value;
        private Suit suit;

        public Card(int v, Suit s)
        {
            value = v;
            suit = s;
        }

        public int getValue()
        {
            return value;
        }

        public Suit getSuit()
        {
            return suit;
        }
    }

    public enum Suit
    {
        Club = 0,
        Heart = 1,
        Spade = 2,
        Diamond = 3
    }
}