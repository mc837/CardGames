using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class PairDectector : IDetect
    {
        public HandRanking? Detect(List<Card> availableCards)
        {
            var rankableCards = new List<Card>(availableCards);
            var count = 0;
            HandRanking? handRank = null;

            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && rankableCards[i].NumericalValue == rankableCards[i + 1].NumericalValue)
                {
                    count++;
                }
            }
            if (count == 1)
            {
                handRank = HandRanking.Pair;

            }
            return handRank;
        }
    }
}