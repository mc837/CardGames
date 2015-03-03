using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    internal class StraightDetector : IDetect
    {
        public HandRanking? Detect(IEnumerable<Card> availableCards)
        {
            HandRanking? handRank;

            var rankableCards = new List<Card>(availableCards);

            //count times where next number is not concurrent if more than 0 for 5cards, 1 for 6cards and 2 for seven cards
            var nonConcurrentCount = rankableCards.Where((t, i) => i + 1 != rankableCards.Count && rankableCards[i + 1].NumericalValue != (t.NumericalValue + 1)).Count();

            if (rankableCards.Count == 5 && nonConcurrentCount > 0 || rankableCards.Count == 6 && nonConcurrentCount > 1 ||
                rankableCards.Count == 7 && nonConcurrentCount > 2)
            {
                return null;
            }
            handRank = HandRanking.Straight;


            return handRank;
        }
    }
}