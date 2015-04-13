using System.Collections.Generic;

namespace CardGames.Detectors
{
    public interface IDetect
    {
        FinalHand Detect(IEnumerable<Card> availableCards);
    }
}