using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class CardModel
    {
        public int ID { get; set; }
        public int value { get; set; }
        public Suit suit { get; set; }

        public CardModel(int v, Suit s)
        {
            value = v;
            suit = s;
        }
    }

    public enum Suit
    {
        Club = 0,
        Heart = 1,
        Spade = 2,
        Diamond = 3
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
                deck.Add(new CardModel(i, Suit.Club));
                deck.Add(new CardModel(i, Suit.Spade));
                deck.Add(new CardModel(i, Suit.Heart));
                deck.Add(new CardModel(i, Suit.Diamond));
            }
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