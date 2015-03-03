using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    internal class RoyalFlushDetector : IDetect
    {
        public HandRanking? Detect(IEnumerable<Card> availableCards)
        {
            HandRanking? handRank = null;

            var rankableCards = new List<Card>(availableCards);

            //if same suit count is less than five
            var mostOccurringSuit = rankableCards.GroupBy(i => i.Suit).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            rankableCards.RemoveAll(x=> x.Suit != mostOccurringSuit);
            if (rankableCards.Count < 5)
            {
                return null;
            }

            //remove any integers between 2 and 9
            rankableCards.RemoveAll(x => (x.NumericalValue < 10 && x.NumericalValue > 1));
            if (rankableCards.Count == 5)
            {
                handRank = HandRanking.RoyalFlush;
            }

            return handRank;
        }

    }
}