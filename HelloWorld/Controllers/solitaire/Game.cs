using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Controllers.solitaire
{
    public class Game
    {
        private Deck deck;
        private List<Stack> stack;
        private List<Pile> pile;

        public void newGame()
        {
            deck = new Deck();
            deck.shuffle();
            
            for(int i = 0; i < 7; i++)
            {
                stack.Add(new Stack());
            }

            pile.Add(new Pile(Suit.Club));
            pile.Add(new Pile(Suit.Diamond));
            pile.Add(new Pile(Suit.Heart));
            pile.Add(new Pile(Suit.Spade));

            for(int i = 0; i < 7; i++)
            {
                for(int j=0; j < 7 - i; j++)
                {
                    stack[j].Add(deck.getCard());
                }
            }
        }
    }
}