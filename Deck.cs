using System;
using System.Collections.Generic;

namespace GameOfWar
{
    public class Deck
    {
        private List<Card> _cards;

        public int Count => _cards.Count;

        public Deck(List<Card>? cards = null, bool isEmptyDeck = false)
        {
            if (cards != null && cards.Count > 0)
            {
                _cards = new List<Card>(cards);
            }
            else
            {
                _cards = new List<Card>();
                if (!isEmptyDeck)
                {
                    InitializeDeck();
                }
            }
        }

        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            for (int r = 0; r < 13; r++)
            {
                foreach (string s in suits)
                {
                    _cards.Add(new Card(s, r));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ( _cards[k], _cards[n] ) = ( _cards[n], _cards[k] );
            }
        }

        public Card CardAtIndex(int index)
        {
            if (index < 0 || index >= _cards.Count)
                throw new IndexOutOfRangeException("Index out of range.");
            return _cards[index];
        }

        public Card PullCardAtIndex(int index)
        {
            Card c = CardAtIndex(index);
            _cards.RemoveAt(index);
            return c;
        }

        public List<Card> PullAllCards()
        {
            List<Card> pulled = new List<Card>(_cards);
            _cards.Clear();
            return pulled;
        }

        public void PushCard(Card card)
        {
            _cards.Add(card);
        }

        public void PushCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public List<Card> Deal(int num)
        {
            if (num > _cards.Count)
                throw new ArgumentOutOfRangeException("Not enough cards to deal.");

            List<Card> dealt = _cards.GetRange(0, num);
            _cards.RemoveRange(0, num);
            return dealt;
        }
    }
}
