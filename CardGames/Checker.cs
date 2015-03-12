using System.Collections.Generic;
using System.Data.Common;
using CardGames.Detectors;
using CardGames.Enums;

namespace CardGames
{
    public class Checker
    {
        public Checker()
//        public Checker(List<IDetect> cardsDetector)
        {
         //from source new up   
        }
        private readonly List<IDetect> _handDetector = new List<IDetect>
        {
            new RoyalFlushDetector(),
            new StraightFlushDetector(),
            new FourOfAKindDetector(),
            new FullhouseDetector(),
            new FlushDetector(),
            new StraightDetector(),
            new ThreeOfAKindDectector(),
            new TwoPairDectector(),
            new PairDectector()
        };

        public HandRanking? Check(List<Card> availableCards)
        {
            HandRanking? hand = null;
            foreach (var handResult in _handDetector)
            {
                hand = handResult.Detect(availableCards);
                if (hand != null)
                {
                    break;
                }
                hand = HandRanking.HighCard;
            }
            return hand;
        }
    }
}

