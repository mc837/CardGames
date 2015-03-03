using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames
{
    public class Scorer
    {
        public HandRanking? Evaluate(Hand playersHand, CommunityCards communityCards)
        {
            var availableCards = Combine(playersHand, communityCards);
            var check = new Checker();
            return check.Check(availableCards);
        }

        private static List<Card> Combine(Hand playersHand, CommunityCards communityCards)
        {
            var combinedCards = new List<Card>
            {
                playersHand.Card1,
                playersHand.Card2,
                communityCards.FlopCard1,
                communityCards.FlopCard2,
                communityCards.FlopCard3,
                communityCards.River,
                communityCards.Turn
            };

            //sort low to high
            combinedCards.Sort((x, y) => x.NumericalValue.CompareTo(y.NumericalValue));

            return combinedCards;
        }
    }
}