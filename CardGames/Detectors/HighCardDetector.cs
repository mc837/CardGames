using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class HighCardDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var finalHand = new FinalHand();
            var rankableCards = new List<Card>(availableCards);

            rankableCards.Reverse();

            finalHand.card1 = rankableCards[0];
            finalHand.card2 = rankableCards[1];
            finalHand.card3 = rankableCards[2];
            finalHand.card4 = rankableCards[3];
            finalHand.card5 = rankableCards[4];
            finalHand.rank = HandRanking.HighCard;

            return finalHand;
        }
    }
}