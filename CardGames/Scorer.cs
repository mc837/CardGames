using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames
{
    public class Scorer
    {
        public FinalHand Evaluate(Hand playersHand, CommunityCards communityCards)
        {
            //change to switch statement;
            //FinalHandObject (5 cards and state -- if state same as another player the cards can be compared) 
            var availableCards = Combine(playersHand, communityCards);
            FinalHand finalHand = null;

            finalHand = CheckForSinglePair(availableCards);
            if (finalHand != null)
            {
                return finalHand;
            };
            return null;
        }

        private bool HighCard(List<Card> availableCards)
        {
            return true;
        }

        private static FinalHand CheckForSinglePair(List<Card> availableCards)
        {
            var count = 0;
            Card pairCard1 = null;
            Card pairCard2 = null;
            FinalHand finalHand = null;

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
                availableCards.RemoveAll(x => x.NumericalValue == pairCard1.NumericalValue);
                availableCards.Sort((x, y) => x.NumericalValue.CompareTo(y.NumericalValue));
                availableCards.RemoveRange(0, 2);
                finalHand = new FinalHand
                {
                    card1 = pairCard1,
                    card2 = pairCard2,
                    card3 = availableCards[0],
                    card4 = availableCards[1],
                    card5 = availableCards[2],
                    rank = HandRanking.Pair
                };
            };
            return finalHand;
        }

        private static bool CheckForThreeOfAKind(List<Card> availableCards)
        {
            var count = 0;
            var cardNumericalValue = 0;
            var occuranceCount = 0;
            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
                {
                    count++;
                    cardNumericalValue = availableCards[i].NumericalValue;
                }
            }
            for (var i = 0; i < 7; i++)
            {
                if (cardNumericalValue == availableCards[i].NumericalValue)
                {
                    occuranceCount++;
                }
            }
            return (count == 2 && occuranceCount == 3);
        }

        private static bool CheckForFourOfAKind(List<Card> availableCards)
        {
            var count = 0;
            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
                {
                    count++;
                }
            }
            return count == 3;
        }

        private static bool CheckForTwoPair(List<Card> availableCards)
        {
            var count = 0;
            for (var i = 0; i < 7; i++)
            {
                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
                {
                    count++;
                }
            }
            return count == 2;
        }

        private List<Card> Combine(Hand playersHand, CommunityCards communityCards)
        {
            // better as a model?
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
    }
}