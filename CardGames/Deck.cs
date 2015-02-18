using System;
using System.Globalization;
using System.Linq;

namespace CardGames
{
    public class Deck
    {
        private Card[] _deck = new Card[52];

        public Deck()
        {
            var position = 0;
            for (var s = 0; s < 4; s++)
            {
                var suit = SuitValue(s);
                for (var i = 1; i <= 13; i++)
                {
                    string cardValue;
                    if (i == 1 || i > 10)
                    {
                        cardValue = PictureValue(i);
                    }
                    else
                    {
                        cardValue = i.ToString(CultureInfo.InvariantCulture);
                    }
                    _deck[position] = new Card {Value = cardValue, NumericalValue = i, Suit = suit};
                    position++;
                }
            }
        }

        private static string SuitValue(int i)
        {
            switch (i)
            {
                case 0:
                    return "Hearts";
                case 1:
                    return "Clubs";
                case 2:
                    return "Diamonds";
                default:
                    return "Spades";
            }
        }

        private static string PictureValue(int i)
        {
            switch (i)
            {
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return "Ace";
            }
        }

        public Card Deal(int position)
        {
            var card = _deck[position];
            return card;
        }

        public void Shuffle()
        {
            var rnd = new Random();
            var shuffledDeck = _deck.OrderBy(x => rnd.Next()).ToArray();
            _deck = shuffledDeck;
        }
    }
}