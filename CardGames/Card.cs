namespace CardGames
{
    public class Card
    {
        public string Suit { private get; set; }
        public string Value { private get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Card)) return false;
            var card = obj as Card;
            return card != null && (Suit.Equals(card.Suit) && Value.Equals(card.Value));
        }
    }
}