using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames
{
    public class Scorer
    {
        public HandRanking? Evaluate(Hand playersHand, CommunityCards communityCards)
        {
            var availableCards = Combine(playersHand, communityCards);
            var check = new Checker();
            return check.Check(availableCards);
        }

        private static List<Card> Combine(Hand playersHand, CommunityCards communityCards)
        {
            var combinedCards = new List<Card>
            {
                playersHand.Card1,
                playersHand.Card2,
                communityCards.FlopCard1,
                communityCards.FlopCard2,
                communityCards.FlopCard3,
                communityCards.River,
                communityCards.Turn
            };

            combinedCards.Sort((x, y) => x.NumericalValue.CompareTo(y.NumericalValue));

            return combinedCards;
        }

//        private bool HighCard(List<Card> availableCards)
//        {
//            return true;
//        }
//
//        
//
//        private static bool CheckForThreeOfAKind(List<Card> availableCards)
//        {
//            var count = 0;
//            var cardNumericalValue = 0;
//            var occuranceCount = 0;
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                    cardNumericalValue = availableCards[i].NumericalValue;
//                }
//            }
//            for (var i = 0; i < 7; i++)
//            {
//                if (cardNumericalValue == availableCards[i].NumericalValue)
//                {
//                    occuranceCount++;
//                }
//            }
//            return (count == 2 && occuranceCount == 3);
//        }
//
//        private static bool CheckForFourOfAKind(List<Card> availableCards)
//        {
//            var count = 0;
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                }
//            }
//            return count == 3;
//        }
//
//        private static bool CheckForTwoPair(List<Card> availableCards)
//        {
//            var count = 0;
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                }
//            }
//            return count == 2;
//        }
    }
}