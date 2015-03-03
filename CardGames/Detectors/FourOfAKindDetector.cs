using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class FourOfAKindDetector : IDetect
    {
        public HandRanking? Detect(IEnumerable<Card> availableCards)
        {
            HandRanking? handRank = null;
            var rankableCards = new List<Card>(availableCards);

            var mostOccurringValue = rankableCards.GroupBy(i => i.NumericalValue).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            rankableCards.RemoveAll(x => x.NumericalValue != mostOccurringValue);
            if (rankableCards.Count == 4)
            {
                handRank = HandRanking.FourOfAKind;
            }

            return handRank;
        }
    }
}