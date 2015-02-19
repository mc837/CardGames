using System.Globalization;
using CardGames.Enums;

namespace CardGames
{
    public class Card
    {
        public Card(int cardValue, Suit suit)
        {
            NumericalValue = cardValue;
            Suit = suit;
        }

        public Suit Suit { private get; set; }

        public string Value()
        {
            if (NumericalValue == 1 || NumericalValue > 10)
                    {
                        return PictureValue(NumericalValue);
                    }
                    else
                    {
                       return NumericalValue.ToString(CultureInfo.InvariantCulture);
                    }
        }
        public int NumericalValue {get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Card)) return false;
            var card = obj as Card;
            return card != null && (Suit.Equals(card.Suit) && NumericalValue.Equals(card.NumericalValue));
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
    }
}