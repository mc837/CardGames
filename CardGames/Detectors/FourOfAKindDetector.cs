using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class FourOfAKindDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var finalHand = new FinalHand();
            var rankableCards = new List<Card>(availableCards);

            var mostOccurringCardValue =
                rankableCards.GroupBy(i => i.NumericalValue)
                    .OrderByDescending(grp => grp.Count())
                    .Select(grp => grp.Key)
                    .First();

            var numberOfOccurances = rankableCards.Count(num => num.NumericalValue == mostOccurringCardValue);

            if (numberOfOccurances == 4)
            {
                var fourOfAKindCards = rankableCards.Where(num => num.NumericalValue == mostOccurringCardValue).ToList();
                finalHand.card1 = fourOfAKindCards[0];
                finalHand.card2 = fourOfAKindCards[1];
                finalHand.card3 = fourOfAKindCards[2];
                finalHand.card4 = fourOfAKindCards[3];

                rankableCards.RemoveAll(num => num.NumericalValue == mostOccurringCardValue);

                finalHand.card5 = rankableCards[2];
                finalHand.rank = HandRanking.FourOfAKind;
            }

            return finalHand;
        }
    }
}