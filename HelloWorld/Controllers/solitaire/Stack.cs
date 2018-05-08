using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Controllers.solitaire
{
    public class Stack
    {
        private List<Card> stack;

        public Stack()
        {
            stack = new List<Card>();
        }

        public bool MoveTo(List<Card> c)
        {
            if ((stack[stack.Count - 1].getValue() == c[0].getValue() - 1) && (stack[stack.Count - 1].getSuit() == c[0].getSuit()))
            {
                foreach (Card card in c)
                {
                    stack.Add(card);
                }
                return true;
            }
            return false;
        }

        private bool canMoveFrom(int index)
        {
            if (index == stack.Count - 1)
            {
                return true;
            }
            else
            {
                if (stack[index].getValue() == stack[index + 1].getValue() && (int)stack[index].getSuit() % 2 != (int)stack[index + 1].getSuit() % 2)
                {
                    return canMoveFrom(index + 1);
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Card> getCards(int index)
        {
            List<Card> newList = new List<Card>();
            if (canMoveFrom(index))
            {
                while (index < stack.Count)
                {
                    newList.Add(stack[index]);
                    stack.Remove(stack[index]);
                }
            }
            return newList;
        }

        public void Add(Card c)
        {
            stack.Add(c);
        }
    }
}