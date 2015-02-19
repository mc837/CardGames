using CardGames.Enums;

namespace CardGames
{
    public class FinalHand
    {
        public Card card1;
        public Card card2;
        public Card card3;
        public Card card4;
        public Card card5;
        public HandRanking rank;

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(FinalHand)) return false;
            var finalHand = obj as FinalHand;
            return finalHand != null && (card1.Equals(finalHand.card1))
                   && (card2.Equals(finalHand.card2))
                   && (card3.Equals(finalHand.card3))
                   && (card4.Equals(finalHand.card4))
                   && (card5.Equals(finalHand.card5))
                   && (rank.Equals(finalHand.rank));
        }
    }
}