using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    internal class FlushDetector : IDetect
    {
        public HandRanking? Detect(IEnumerable<Card> availableCards)
        {
            HandRanking? handRank = null;

            var rankableCards = new List<Card>(availableCards);

            var mostOccurringSuit = rankableCards.GroupBy(i => i.Suit).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            rankableCards.RemoveAll(x => x.Suit != mostOccurringSuit);
            if (rankableCards.Count >= 5)
            {
                handRank = HandRanking.Flush;
            }
            return handRank;
        }
    }
}