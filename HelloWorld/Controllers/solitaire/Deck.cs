using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Controllers.solitaire
{
    public class Deck
    {
        private List<Card> deck;

        private static Random rng = new Random();

        public Deck()
        {
            deck = new List<Card>();
            for (int i=1; i < 14; i++)
            {
                deck.Add(new Card(i, Suit.Club));
                deck.Add(new Card(i, Suit.Spade));
                deck.Add(new Card(i, Suit.Heart));
                deck.Add(new Card(i, Suit.Diamond));
            }
        }

        public void shuffle()
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card c = deck[k];
                deck[k] = deck[n];
                deck[n] = c;
            }
        }

        public Card getCard()
        {
            Card c = deck[0];
            deck.Remove(c);
            return c;
        }
    }
}