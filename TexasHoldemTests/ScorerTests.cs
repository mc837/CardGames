using CardGames;
using CardGames.Enums;
using NUnit.Framework;

namespace TexasHoldemTests
{
    [TestFixture]
    class ScorerTests
    {
        private Hand _playersHand;
        private CommunityCards _communityCards;

        [SetUp]
        public void Setup()
        {
            _playersHand = new Hand
            {
                Card1 = new Card(1, Suit.Hearts),
                Card2 = new Card(3, Suit.Diamonds),
            };
            _communityCards = new CommunityCards
            {
                FlopCard1 = new Card(10, Suit.Hearts),
                FlopCard2 = new Card(12, Suit.Hearts),
                FlopCard3 = new Card(11, Suit.Hearts),
                River = new Card(13, Suit.Hearts),
                Turn = new Card(4, Suit.Hearts)
            };
        }

        [Test]
        public void Should_ReturnARoyalFlush_When_EvaluateIsInvoked()
        {
            const HandRanking expectedResult = HandRanking.RoyalFlush;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        //[Test]
        //public void Should_ReturnHighCard_When_EvaluatorIsInvoked()
        //{
        //    var scorer = new Scorer();
        //    var score = scorer.Evaluate(_playersHand, _communityCards);
        //    Assert.That(score, Is.EqualTo("High Card"));
        //}

        [Test]
        public void Should_ReturnAPair_When_EvaluatorIsInvoked()
        {
            _communityCards.FlopCard3 = new Card(1, Suit.Clubs);
            const HandRanking expectedResult = HandRanking.Pair;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

//        [Test]
//        public void Should_ReturnThreeOfAKind_When_EvaluatorIsInvoked()
//        {
//            _playersHand.Card2 = new Card(1, Suit.Diamonds);
//            _communityCards.FlopCard1 = new Card(1, Suit.Hearts);
//            const HandRanking expectedResult = HandRanking.ThreeOfAKind;
//
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo(expectedResult));
//        }

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
