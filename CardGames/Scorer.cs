using System.Collections.Generic;
using CardGames.Detectors;
using CardGames.Enums;

namespace CardGames
{
    public class Scorer
    {
        private readonly List<IDetect> _handDetector = new List<IDetect>
        {
//            new RoyalFlushDetector(),
//            new StraightFlushDetector(),
//            new FourOfAKindDetector(),
//            new FullhouseDetector(),
//            new FlushDetector(),
//            new StraightDetector(),
//            new ThreeOfAKindDectector(),
//            new TwoPairDectector(),
            new PairDectector()
        };

        public FinalHand Evaluate(List<Card> playersHand, List<Card> communityCards)
        {
            var availableCards = Combine(playersHand, communityCards);
            var check = new Checker(_handDetector, availableCards);
            return check.Check();
        }

        private static List<Card> Combine(List<Card> playersHand, List<Card> communityCards)
        {
            var combinedCards = new List<Card>
            {
                playersHand[0],
                playersHand[1],
                communityCards[0],
                communityCards[1],
                communityCards[2],
                communityCards[3],
                communityCards[4]
            };
            //sort low to high
            combinedCards.Sort((x, y) => x.NumericalValue.CompareTo(y.NumericalValue));

            return combinedCards;
        }
    }
}