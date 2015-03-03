using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames.Detectors
{
    public interface IDetect
    {
        HandRanking? Detect(IEnumerable<Card> availableCards);
    }
}