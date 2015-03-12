using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class FullhouseDetector : IDetect
    {
        public HandRanking? Detect(IEnumerable<Card> availableCards)
        {
            ////new up 3 of kind and pair detectors.
            var count = 0;
            HandRanking? handRank = null;
            var rankableCards = new List<Card>(availableCards);
            var cardNumericalValue = 0;
            var occuranceCount = 0;

            //check for 3 of a kind 
            for (var i = 0; i < 7 && count <2; i++)
            {
                if (i + 1 != 7 && rankableCards[i].NumericalValue == rankableCards[i + 1].NumericalValue)
                {
                    count++;
                    cardNumericalValue = rankableCards[i].NumericalValue;
                }
            }
            for (var i = 0; i < 7; i++)
            {
                if (cardNumericalValue == rankableCards[i].NumericalValue)
                {
                    occuranceCount++;
                }
            }
            if (count < 2 || occuranceCount != 3) return null;
            //remove from list
            count = 0;
            rankableCards.RemoveAll(c => c.NumericalValue == cardNumericalValue);
            //check for a pair from remaining cards
            for (var i = 0; i < 7; i++)
            {
                if (!(i + 1 >= rankableCards.Count) && rankableCards[i].NumericalValue == rankableCards[i + 1].NumericalValue)
                {
                    count++;
                    if (count >= 1)
                    {
                        handRank = HandRanking.FullHouse;
                        break;
                    }
                }
            }

            return handRank;
        }
    }
}