using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public class TwoPairDetector : IDetect
    {
        public FinalHand Detect(IEnumerable<Card> availableCards)
        {
            var rankableCards = new List<Card>(availableCards);
            var count = 0;
            var finalHand = new FinalHand();
            var pairedCards = new List<Card>();

            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && rankableCards[i].NumericalValue == rankableCards[i + 1].NumericalValue)
                {
                    count++;
                    pairedCards.Add(rankableCards[i]);
                    pairedCards.Add(rankableCards[i + 1]);
                }
            }
            if (count >= 2)
            {
                pairedCards.Reverse();
                // add paired cards to finalhand
                finalHand.card1 = pairedCards[0];
                finalHand.card2 = pairedCards[1];
                finalHand.card3 = pairedCards[2];
                finalHand.card4 = pairedCards[3];

                rankableCards.RemoveAll(c => c.NumericalValue == finalHand.card1.NumericalValue && 
                    c.NumericalValue == finalHand.card3.NumericalValue);

                finalHand.card5 = rankableCards[2];
                finalHand.rank = HandRanking.TwoPair;
            }

            //if not a pair card1 and rest will be null but handranking defaults to first enum.
            return finalHand;
        }
    }
}
