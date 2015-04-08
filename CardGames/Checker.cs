using System.Collections.Generic;
using CardGames.Detectors;
using CardGames.Enums;

namespace CardGames
{
    public class Checker
    {
        private readonly List<IDetect> _handDetector;
        private readonly List<Card> _availableCards;

        public Checker(List<IDetect> handDetector, List<Card> availableCards)
        {
            _handDetector = handDetector;
            _availableCards = availableCards;
        }

        public HandRanking? Check()
        {
            HandRanking? hand = null;
            foreach (var handResult in _handDetector)
            {
                hand = handResult.Detect(_availableCards);
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

