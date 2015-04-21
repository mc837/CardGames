using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;
using MongoDB.Driver;

namespace CardGames.Detectors
{
    public class FlushTypeDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var rankableCards = new List<Card>(availableCards);
            var finalHand = new FinalHand();

            // find most common suit
            var mostOccurringSuit = rankableCards.GroupBy(i => i.Suit)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).First();

            //remove from rankable cards
            rankableCards.RemoveAll(x => x.Suit != mostOccurringSuit);

            // if count is >= 5
            if (rankableCards.Count >= 5)
            {
                // run straight checker
                var straightChecker = new StraightDetector();
                var result = straightChecker.Detect(rankableCards);

                // if returned hand ranking is straight 
                if (result.rank == HandRanking.Straight)
                {
                    finalHand = result;
                    finalHand.rank = finalHand.card5.NumericalValue == 10 ? HandRanking.RoyalFlush : HandRanking.StraightFlush;
                }
            }
            return finalHand;
        }
    }
}
