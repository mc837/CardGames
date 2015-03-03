using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class TwoPairDectector : IDetect
    {
        public HandRanking? Detect(IEnumerable<Card> availableCards)
        {
            var count = 0;
            HandRanking? handRanking = null;
            var rankableCards = new List<Card>(availableCards);

            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && rankableCards[i].NumericalValue == rankableCards[i + 1].NumericalValue)
                {
                    count++;
                }
                if (count == 2)
                {
                    handRanking = HandRanking.TwoPair;
                }
            }
            return handRanking;
        }
        
    }
}