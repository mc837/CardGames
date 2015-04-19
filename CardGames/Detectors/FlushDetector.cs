using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class FlushDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var finalHand = new FinalHand();

            var rankableCards = new List<Card>(availableCards);

            var mostOccurringSuit = rankableCards.GroupBy(i => i.Suit)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).First();

            rankableCards.RemoveAll(x => x.Suit != mostOccurringSuit);
            
            if (rankableCards.Count >= 5)
            {
                rankableCards.Reverse();
                finalHand.card1 = rankableCards[0];
                finalHand.card2 = rankableCards[1];
                finalHand.card3 = rankableCards[2];
                finalHand.card4 = rankableCards[3];
                finalHand.card5 = rankableCards[4];
                finalHand.rank = HandRanking.Flush;

            }
            return finalHand;
        }
    }
}