using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class FullhouseDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var finalHand = new FinalHand();
            var rankableCards = new List<Card>(availableCards);

            //check for 3
            var mostOccurringCardValue = MostOccurringValue(rankableCards);

            var numberOfOccurances = NumberOfOccurances(mostOccurringCardValue, rankableCards);

            if (numberOfOccurances == 3)
            {
                var threeOfAKindCards = rankableCards.Where(num => num.NumericalValue == mostOccurringCardValue).ToList();
                rankableCards.RemoveAll(num => num.NumericalValue == mostOccurringCardValue);

                mostOccurringCardValue = MostOccurringValue(rankableCards);
                numberOfOccurances = NumberOfOccurances(mostOccurringCardValue, rankableCards);
                if (numberOfOccurances >= 2)
                {
                    //add to list
                    var pairCards = rankableCards.Where(num => num.NumericalValue == mostOccurringCardValue).ToList();
                    // remove from rankable
                    rankableCards.RemoveAll(num => num.NumericalValue == mostOccurringCardValue);
                    //build final hand
                    finalHand.card1 = threeOfAKindCards[0];
                    finalHand.card2 = threeOfAKindCards[1];
                    finalHand.card3 = threeOfAKindCards[2];
                    finalHand.card4 = pairCards[0];
                    finalHand.card5 = pairCards[1];
                    finalHand.rank = HandRanking.FullHouse;
                }
            }
            return finalHand;
        }

        private static int MostOccurringValue(IEnumerable<Card> rankableCards)
        {
            return rankableCards.GroupBy(i => i.NumericalValue)
                 .OrderByDescending(grp => grp.Count())
                 .ThenByDescending(grp => grp.Key)
                   .Select(grp => grp.Key)
                  .First(); 
        }

        private static int NumberOfOccurances(int mostOccurringCardValue, IEnumerable<Card> rankableCards)
        {
            return rankableCards.Count(num => num.NumericalValue == mostOccurringCardValue);
        }
    }
}

