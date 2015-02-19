using CardGames;
using CardGames.Enums;
using NUnit.Framework;

namespace TexasHoldemTests
{
    [TestFixture]
    class ScorerTests
    {
        //Best 5 out of 7

        //each winnning type (straight / two pair

        private Hand _playersHand;
        private CommunityCards _communityCards;

        [SetUp]
        public void Setup()
        {
            _playersHand = new Hand
            {
                Card1 = new Card(1, Suit.Clubs),
                Card2 = new Card(3, Suit.Diamonds),
            };
            _communityCards = new CommunityCards
            {
                FlopCard1 = new Card(8, Suit.Hearts),
                FlopCard2 = new Card(10, Suit.Clubs),
                FlopCard3 = new Card(7, Suit.Spades),
                River = new Card(13, Suit.Spades),
                Turn = new Card(2, Suit.Diamonds)
            };
        }

//        [Test]
//        public void Should_ReturnHighCard_When_EvaluatorIsInvoked()
//        {
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo("High Card"));
//        }

        [Test]
        public void Should_ReturnAPair_When_EvaluatorIsInvoked()
        {
            _communityCards.FlopCard1 = new Card(1, Suit.Hearts);
            var expextedFinalHand = new FinalHand
            {
                card1 = new Card(1, Suit.Clubs),
                card2 = new Card(1, Suit.Hearts),
                card3 = new Card(7, Suit.Spades),
                card4 = new Card(10, Suit.Clubs),
                card5 = new Card(13, Suit.Spades),
                rank = HandRanking.Pair
            };

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expextedFinalHand));
        }

        [Test]
        public void Should_ReturnThreeOfAKind_When_EvaluatorIsInvoked()
        {
            _playersHand.Card2 = new Card(1, Suit.Diamonds);
            _communityCards.FlopCard1 = new Card(1, Suit.Hearts);

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo("Three Of A Kind"));
        }

//        [Test]
//        public void Should_ReturnFourOfAKind_When_EvaluatorIsInvoked()
//        {
//            _playersHand.Card2 = new Card(1, Suit.Diamonds);
//            _communityCards.FlopCard1 = new Card(1, Suit.Hearts);
//            _communityCards.FlopCard3 = new Card(1, Suit.Spades);
//
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo("Four Of A Kind"));
//        }
//
//
//        [Test]
//        public void Should_ReturnTwoPair_When_EvaluatorIsInvoked()
//        {
//            _communityCards.FlopCard1 = new Card(1, Suit.Hearts);
//            _communityCards.FlopCard3 = new Card(3, Suit.Hearts);
//
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo("Two Pair"));
//        }
    }
}
