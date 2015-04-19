using System.Collections.Generic;
using System.Data.Common;
using CardGames;
using CardGames.Detectors;
using CardGames.Enums;
using NUnit.Framework;

namespace TexasHoldemTests
{
    internal class CheckerTests
    {
        private List<Card> _availableCards;

        private void OrderCards()
        {
            _availableCards.Sort((x, y) => x.NumericalValue.CompareTo(y.NumericalValue));

        }

        private FinalHand check(List<IDetect> handDetector, List<Card> availableCards)
        {
            var checker = new Checker(handDetector, availableCards);
            return checker.Check();
        }

        private readonly List<IDetect> _handDetector = new List<IDetect>
        {
//            new RoyalFlushDetector(),
//            new StraightFlushDetector(),
            new FourOfAKindDetector(),
            new FullhouseDetector(),
            new FlushDetector(),
//            new StraightDetector(),
            new ThreeOfAKindDectector(),
            new TwoPairDetector(),
            new PairDectector()
        };

        [Test]
        public void Should_ReturnAPair_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(14, Suit.Hearts),
                new Card(3, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(7, Suit.Clubs),
                new Card(14, Suit.Clubs),
                new Card(13, Suit.Hearts),
                new Card(4, Suit.Hearts)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(14, Suit.Hearts),
                card2 = new Card(14, Suit.Clubs),
                card3 = new Card(13, Suit.Hearts),
                card4 = new Card(7, Suit.Clubs),
                card5 = new Card(4, Suit.Hearts),
                rank = HandRanking.Pair
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnTwoPair_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(14, Suit.Hearts),
                new Card(3, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(13, Suit.Clubs),
                new Card(14, Suit.Clubs),
                new Card(13, Suit.Hearts),
                new Card(4, Suit.Hearts)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(14, Suit.Clubs),
                card2 = new Card(14, Suit.Hearts),
                card3 = new Card(13, Suit.Hearts),
                card4 = new Card(13, Suit.Clubs),
                card5 = new Card(4, Suit.Hearts),
                rank = HandRanking.TwoPair
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnhighestTwoPair_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(14, Suit.Hearts),
                new Card(2, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(13, Suit.Clubs),
                new Card(14, Suit.Clubs),
                new Card(13, Suit.Hearts),
                new Card(4, Suit.Hearts)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(14, Suit.Clubs),
                card2 = new Card(14, Suit.Hearts),
                card3 = new Card(13, Suit.Hearts),
                card4 = new Card(13, Suit.Clubs),
                card5 = new Card(4, Suit.Hearts),
                rank = HandRanking.TwoPair
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnThreeOfAKind_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(2, Suit.Hearts),
                new Card(3, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(13, Suit.Clubs),
                new Card(14, Suit.Hearts),
                new Card(2, Suit.Diamonds),
                new Card(4, Suit.Hearts)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(2, Suit.Hearts),
                card2 = new Card(2, Suit.Clubs),
                card3 = new Card(2, Suit.Diamonds),
                card4 = new Card(14, Suit.Hearts),
                card5 = new Card(13, Suit.Clubs),
                rank = HandRanking.ThreeOfAKind
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnFlush_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(14, Suit.Diamonds),
                new Card(7, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(7, Suit.Clubs),
                new Card(13, Suit.Diamonds),
                new Card(6, Suit.Diamonds),
                new Card(4, Suit.Diamonds)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(14, Suit.Diamonds),
                card2 = new Card(13, Suit.Diamonds),
                card3 = new Card(7, Suit.Diamonds),
                card4 = new Card(6, Suit.Diamonds),
                card5 = new Card(4, Suit.Diamonds),
                rank = HandRanking.Flush
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnFourOfAKind_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(7, Suit.Hearts),
                new Card(7, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(7, Suit.Clubs),
                new Card(14, Suit.Hearts),
                new Card(7, Suit.Spades),
                new Card(4, Suit.Hearts)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(7, Suit.Hearts),
                card2 = new Card(7, Suit.Diamonds),
                card3 = new Card(7, Suit.Clubs),
                card4 = new Card(7, Suit.Spades),
                card5 = new Card(14, Suit.Hearts),
                rank = HandRanking.FourOfAKind
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnFullhouse_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(7, Suit.Hearts),
                new Card(7, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(7, Suit.Clubs),
                new Card(2, Suit.Hearts),
                new Card(10, Suit.Spades),
                new Card(4, Suit.Hearts)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(7, Suit.Hearts),
                card2 = new Card(7, Suit.Diamonds),
                card3 = new Card(7, Suit.Clubs),
                card4 = new Card(2, Suit.Clubs),
                card5 = new Card(2, Suit.Hearts),
                rank = HandRanking.FullHouse
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnHighestThreeOfAKindPartOfFullhouse_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(7, Suit.Hearts),
                new Card(7, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(7, Suit.Clubs),
                new Card(10, Suit.Hearts),
                new Card(10, Suit.Spades),
                new Card(10, Suit.Diamonds)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(10, Suit.Hearts),
                card2 = new Card(10, Suit.Spades),
                card3 = new Card(10, Suit.Diamonds),
                card4 = new Card(7, Suit.Hearts),
                card5 = new Card(7, Suit.Diamonds),
                rank = HandRanking.FullHouse
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

            Assert.That(score, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_ReturnHighestPairPartOfFullhouse_When_EvaluatorIsInvoked()
        {
            _availableCards = new List<Card>
            {
                new Card(7, Suit.Hearts),
                new Card(7, Suit.Diamonds),
                new Card(2, Suit.Clubs),
                new Card(7, Suit.Clubs),
                new Card(2, Suit.Hearts),
                new Card(10, Suit.Spades),
                new Card(10, Suit.Diamonds)
            };
            var expectedResult = new FinalHand
            {
                card1 = new Card(7, Suit.Hearts),
                card2 = new Card(7, Suit.Diamonds),
                card3 = new Card(7, Suit.Clubs),
                card4 = new Card(10, Suit.Spades),
                card5 = new Card(10, Suit.Diamonds),
                rank = HandRanking.FullHouse
            };

            OrderCards();
            var score = check(_handDetector, _availableCards);

             Assert.That(score, Is.EqualTo(expectedResult));
        }
    }
}
