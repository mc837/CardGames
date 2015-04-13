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

        public FinalHand Check()
        {
            FinalHand finalHand = null;
            foreach (var handResult in _handDetector)
            {
                finalHand = handResult.Detect(_availableCards);
                if (finalHand.card1 != null)
                {
                    break;
                }
                finalHand.rank = HandRanking.HighCard;
            }
            return finalHand;
        }
    }
}

