using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class ThreeOfAKindDectector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var finalHand = new FinalHand();
            //most occuring numeric value
            var rankableCards = new List<Card>(availableCards);
            var mostOccurringValue =
                rankableCards.GroupBy(i => i.NumericalValue)
                    .OrderByDescending(grp => grp.Count())
                    .Select(grp => grp.Key)
                    .First();

            // count how many times most occuring is in list
            var numberOfOccurances = rankableCards.Count(num => num.NumericalValue == mostOccurringValue);

            //if count = 3
            if (numberOfOccurances == 3)
            {
                var threeOfAKindCards = rankableCards.Where(num => num.NumericalValue == mostOccurringValue).ToList();
                finalHand.card1 = threeOfAKindCards[0];
                finalHand.card2 = threeOfAKindCards[1];
                finalHand.card3 = threeOfAKindCards[2];

                rankableCards.RemoveAll(num => num.NumericalValue == mostOccurringValue);
                finalHand.card4 = rankableCards[3];
                finalHand.card5 = rankableCards[2];
                finalHand.rank = HandRanking.ThreeOfAKind;
            }
          
            return finalHand;
        }
    }
}