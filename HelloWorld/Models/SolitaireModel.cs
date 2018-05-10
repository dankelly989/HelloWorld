using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class CardModel
    {
        public int value { get; set; }
        public String suit { get; set; }

        public CardModel(int v, string s)
        {
            value = v;
            suit = s;
        }
    }

    public class Deck
    {
        private List<CardModel> deck;
        private static Random rng = new Random();

        public Deck()
        {
            deck = new List<CardModel>();
            for (int i = 1; i < 14; i++)
            {
                deck.Add(new CardModel(i, "C"));
                deck.Add(new CardModel(i, "S"));
                deck.Add(new CardModel(i, "H"));
                deck.Add(new CardModel(i, "D"));
            }
            shuffle();
        }
        private void shuffle()
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CardModel c = deck[k];
                deck[k] = deck[n];
                deck[n] = c;
            }
        }
        public CardModel getCard()
        {
            CardModel c = deck[0];
            deck.Remove(c);
            return c;
        }
    }
}