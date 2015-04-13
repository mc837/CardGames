using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class PairDectector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var rankableCards = new List<Card>(availableCards);
            var count = 0;
            var finalHand = new FinalHand();

            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && rankableCards[i].NumericalValue == rankableCards[i + 1].NumericalValue)
                {
                    count++;
                    finalHand.card1 = rankableCards[i];
                    finalHand.card2 = rankableCards[i+1];
                    finalHand.rank = HandRanking.Pair;
                }
            }
            if (count == 1)
            {
                //remove pair from list
                rankableCards.RemoveAll(c => c.NumericalValue == finalHand.card1.NumericalValue);

                finalHand.card3 = rankableCards[4];
                finalHand.card4 = rankableCards[3];
                finalHand.card5 = rankableCards[2];
            };
            
            //if not a pair card1 and rest will be null but handranking defaults to first enum.
            return finalHand;
        }
    }
}