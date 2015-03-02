using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public interface IDetect
    {
        HandRanking? Detect(List<Card> availableCards);
    }
}