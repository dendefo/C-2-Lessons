using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    internal class Deck<T> where T : struct, IComparable<T>
    {
        private List<T> _deck;
        private List<T> _discard;
        public Deck(int size)
        {
            _deck = new List<T>(size);
            _discard = new List<T>(size);
        }
        public void AddCard(T card)
        {
            _deck.Add(card);
        }
        public void AddCard(params T[] cards)
        {
            _deck.AddRange(cards);
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < _deck.Count; i++)
            {
                int j = rand.Next(i, _deck.Count);
                T temp = _deck[i];
                _deck[i] = _deck[j];
                _deck[j] = temp;
            }
        }
        public void Reshuffle()
        {
            _deck.AddRange(_discard);
            _discard.Clear();
            Shuffle();
        }
        public bool TryDraw(out T card)
        {
            if (_deck.Count > 0)
            {
                card = _deck[0];
                _deck.RemoveAt(0);
                return true;
            }
            else
            {
                card = default(T);
                return false;
            }
        }
        public T Peek()
        {
            if (_deck.Count > 0)
            {
                return _deck[0];
            }
            else
            {
                return default(T);
            }
        }
        public int Size => _deck.Capacity;
        public int Remaining => _deck.Count;
    }
}
