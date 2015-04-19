using System.Collections.Generic;
using System.Linq;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class StraightDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var finalHand = new FinalHand();
            var rankableCards = new List<Card>(availableCards);
            //remove duplicate card values
            var singlesValueList = StripDuplicates(rankableCards);
            //if count >= 5
            if (singlesValueList.Count() >= 5)
            {
                var straightCardsList = new List<Card>();
                //loop while i < list.count and i+ 1 is not > list.count
                for (var i = 0; i <= singlesValueList.Count() && i + 1 < singlesValueList.Count(); i++)
                {
                    // if i +1 == cardval +1 add both cards to straight list
                    if ((singlesValueList[i].NumericalValue + 1) == singlesValueList[i + 1].NumericalValue)
                    {
                        straightCardsList.Add(singlesValueList[i]);
                        straightCardsList.Add(singlesValueList[i + 1]);
                    }
                    else if (StripDuplicates(straightCardsList).Count < 5)
                    {
                        //if cards not concurrent clear list but only if straight (5cards) have not already been detected
                        straightCardsList.Clear();
                    }

                }
                //strip duplicates
                straightCardsList = StripDuplicates(straightCardsList);
                //if list >= 5
                if (straightCardsList.Count >= 5)
                {
                    //order
                    straightCardsList.Reverse();
                    //map
                    finalHand.card1 = straightCardsList[0];
                    finalHand.card2 = straightCardsList[1];
                    finalHand.card3 = straightCardsList[2];
                    finalHand.card4 = straightCardsList[3];
                    finalHand.card5 = straightCardsList[4];
                    finalHand.rank = HandRanking.Straight;
                }
            }

            return finalHand;
        }

        private static List<Card> StripDuplicates(IEnumerable<Card> rankableCards)
        {
            return rankableCards.GroupBy(x => x.NumericalValue).Select(y => y.First()).ToList();
        }
    }
}