using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    internal class ThreeOfAKindDectector : IDetect
    {
        public HandRanking? Detect(IEnumerable<Card> availableCards)
        {
            HandRanking? handRank = null;
            var rankableCards = new List<Card>(availableCards);

            var mostOccurringValue = rankableCards.GroupBy(i => i.NumericalValue).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            rankableCards.RemoveAll(x => x.NumericalValue != mostOccurringValue);
            if (rankableCards.Count == 3)
            {
                handRank = HandRanking.ThreeOfAKind;
            }

            return handRank;

//            //do like for of a kind
//           var count = 0;
//           HandRanking? handRanking = null;
//           var rankableCards = new List<Card>(availableCards);
//            var cardNumericalValue = 0;
//            var occuranceCount = 0;
//
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && rankableCards[i].NumericalValue == rankableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                    cardNumericalValue = rankableCards[i].NumericalValue;
//                }
//            }
//            for (var i = 0; i < 7; i++)
//            {
//                if (cardNumericalValue == rankableCards[i].NumericalValue)
//                {
//                    occuranceCount++;
//                }
//            }
//            if (count == 2 && occuranceCount == 3)
//            {
//                handRanking = HandRanking.ThreeOfAKind;
//            }
//
//            return handRanking;
        }
    }
}