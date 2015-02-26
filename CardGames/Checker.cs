using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames
{
    class Checker
    {
        public FinalHand ForSinglePair(List<Card> availableCards)
        {
            var count = 0;
            Card pairCard1 = null;
            Card pairCard2 = null;
            FinalHand finalHand = null;

            //foreach
            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
                {
                    count++;
                    pairCard1 = availableCards[i];
                    pairCard2 = availableCards[i + 1];
                }
            }
            if (count == 1)
            {
                finalHand = GetFinalHand(pairCard1, pairCard2, availableCards);

            };
            return finalHand;
        }

        private static FinalHand GetFinalHand(Card pairCard1, Card pairCard2, List<Card> availableCards)
        {
            availableCards.RemoveAll(x => x.NumericalValue == pairCard1.NumericalValue);
            availableCards.Sort((x, y) => x.NumericalValue.CompareTo(y.NumericalValue));
            availableCards.RemoveRange(0, 2);
            var finalHand = new FinalHand
            {
                card1 = pairCard1,
                card2 = pairCard2,
                card3 = availableCards[0],
                card4 = availableCards[1],
                card5 = availableCards[2],
                rank = HandRanking.Pair
            };
            return finalHand;
        }
    }
}
