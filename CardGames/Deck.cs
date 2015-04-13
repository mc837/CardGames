using System;
using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames
{
    public class Deck
    {
        private List<Card> _deck = new List<Card>();

        public Deck()
        {
            for (var suit = 0; suit < 4; suit++)
            {
                for (var cardValue = 2; cardValue < 15; cardValue++)
                {
                    _deck.Add(new Card(cardValue, (Suit)suit));
                }
            }
        }

        public Card Deal(int position)
        {
            var card = _deck[position];
            return card;
        }

        public void Shuffle()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var shuffledDeck = _deck.OrderBy(x => rnd.Next(0,51)).ToList();
            _deck = shuffledDeck;
        }
    }
}