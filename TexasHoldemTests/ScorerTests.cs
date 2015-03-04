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

        [Test]
        public void Should_ReturnAStraightFlush_When_EvaluateIsInvoked()
        {
            _playersHand.Card1 = new Card(9, Suit.Hearts);
            const HandRanking expectedResult = HandRanking.StraightFlush;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnFourOfAKind_When_EvaluateIsInvoked()
        {
            _playersHand.Card1 = new Card(9, Suit.Hearts);
            _playersHand.Card2 = new Card(9, Suit.Clubs);
            _communityCards.FlopCard1 = new Card(9, Suit.Diamonds);
            _communityCards.FlopCard2 = new Card(9, Suit.Spades);
            const HandRanking expectedResult = HandRanking.FourOfAKind;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnFullhouse_When_EvaluateIsInvoked()
        {
            _playersHand.Card1 = new Card(3, Suit.Hearts);
            _playersHand.Card2 = new Card(3, Suit.Clubs);
            _communityCards.FlopCard1 = new Card(9, Suit.Diamonds);
            _communityCards.FlopCard2 = new Card(9, Suit.Spades);
            _communityCards.FlopCard3 = new Card(3, Suit.Diamonds);
            _communityCards.River = new Card(9, Suit.Clubs);
            const HandRanking expectedResult = HandRanking.FullHouse;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnAFlush_When_EvaluateIsInvoked()
        {
            _communityCards.River = new Card(6, Suit.Hearts);
            const HandRanking expectedResult = HandRanking.Flush;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnAStraight_When_EvaluateIsInvoked()
        {
            _playersHand.Card1 = new Card(9, Suit.Diamonds);
            _communityCards.Turn = new Card(4, Suit.Clubs);
            const HandRanking expectedResult = HandRanking.Straight;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnThreeOfAKind_When_EvaluateIsInvoked()
        {
            _playersHand.Card1 = new Card(9, Suit.Spades);
            _playersHand.Card2 = new Card(9, Suit.Clubs);
            _communityCards.FlopCard1 = new Card(9, Suit.Diamonds);
            const HandRanking expectedResult = HandRanking.ThreeOfAKind;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnTwoPair_When_EvaluatorIsInvoked()
        {
            _communityCards.FlopCard1 = new Card(1, Suit.Clubs);
            _communityCards.FlopCard2 = new Card(3, Suit.Clubs);
            const HandRanking expectedResult = HandRanking.TwoPair;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnAPair_When_EvaluatorIsInvoked()
        {
            _communityCards.FlopCard1 = new Card(2, Suit.Clubs);
            _communityCards.FlopCard2 = new Card(7, Suit.Clubs);
            _communityCards.FlopCard3 = new Card(1, Suit.Clubs);
            const HandRanking expectedResult = HandRanking.Pair;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnHighcard_When_EvaluatorIsInvoked()
        {
            _communityCards.FlopCard2 = new Card(5, Suit.Clubs);
            _communityCards.FlopCard3 = new Card(11, Suit.Clubs);
            const HandRanking expectedResult = HandRanking.HighCard;

            var scorer = new Scorer();
            var score = scorer.Evaluate(_playersHand, _communityCards);
            Assert.That(score, Is.EqualTo(expectedResult));
        }


    }
}
