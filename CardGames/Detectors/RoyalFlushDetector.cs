using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class RoyalFlushDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var rankableCards = new List<Card>(availableCards);
            var finalHand = new FinalHand();

            var mostOccurringSuit = rankableCards.GroupBy(i => i.Suit)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).First();

            rankableCards.RemoveAll(x => x.Suit != mostOccurringSuit);

            if (rankableCards.Count >= 5)
            {
                if (rankableCards.Any(val => val.NumericalValue == 14))
                {
                    var straightChecker = new StraightDetector();
                    var result = straightChecker.Detect(rankableCards);

                    if (result.rank == HandRanking.Straight)
                    {
                        finalHand = result;
                        finalHand.rank = HandRanking.RoyalFlush;
                    }
                }
            }
            return finalHand;
        }
    }
}