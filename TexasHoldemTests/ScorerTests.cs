using System.Runtime.InteropServices;
using CardGames;
using NUnit.Framework;

namespace TexasHoldemTests
{
    class ScorerTests
    {
        //Best 5 out of 7

        //each winnning type (straight / two pair

        [Test]
        public void Should_ReturnAPair_When_EvaluatorIsInvoked()
        {
            var playersHand = new Hand
            {
                Card1 = new Card { Value = "Ace", Suit = "Clubs" },
                Card2 = new Card { Value = "Three", Suit = "Diamonds" }
            };
            var communityCards = new CommunityCards
            {
                FlopCard1 = new Card { Value = "Ace", Suit = "Hearts" },
                FlopCard2 = new Card { Value = "Ten", Suit = "Clubs" },
                FlopCard3 = new Card { Value = "Seven", Suit = "Spades" },
                River = new Card { Value = "King", Suit ="Spades"},
                Turn = new Card { Value = "Two", Suit = "Diamonds"}
            };

            var scorer = new Scorer();
            var score = scorer.Evaluate(playersHand, communityCards);
            Assert.That(score, Is.EqualTo("pair"));
        }
    }

    internal class Scorer
    {
        public string Evaluate(Hand playersHand, CommunityCards communityCards)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class Hand
    {
        public Card Card1 { get; set; }
        public Card Card2 { get; set; }
    }

    internal class CommunityCards
    {
        public Card FlopCard1 { get; set; }
        public Card FlopCard2 { get; set; }
        public Card FlopCard3 { get; set; }
        public Card River { get; set; }
        public Card Turn { get; set; }
    }
}
