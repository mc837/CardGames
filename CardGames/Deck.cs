using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CardGames
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }


    public class Deck
    {
        private List<Card> _deck = new List<Card>();

        public Deck()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int cardValue = 1; cardValue < 14; cardValue++)
                {
                    _deck.Add(new Card(cardValue, (Suit)suit));
                }
            }
        }

//        public Deck()
//        {
//            var position = 0;
//            
//            for (var s = 0; s < 4; s++)
//            {
//                var suit = SuitValue(s);
//                for (var i = 1; i <= 13; i++)
//                {
//                    string cardValue;
//                    if (i == 1 || i > 10)
//                    {
//                        cardValue = PictureValue(i);
//                    }
//                    else
//                    {
//                        cardValue = i.ToString(CultureInfo.InvariantCulture);
//                    }
//                    _deck[position] = new Card {Value = cardValue, NumericalValue = i, Suit = suit};
//                    position++;
//                }
//            }
//        }

        public Card Deal(int position)
        {
            var card = _deck[position];
            return card;
        }

        public void Shuffle()
        {
            var rnd = new Random();
            var shuffledDeck = _deck.OrderBy(x=>x.NumericalValue).ToList();
            _deck = shuffledDeck;
        }
    }
}