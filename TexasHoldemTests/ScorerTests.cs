//using System;
//using System.Linq;
//using System.Runtime.InteropServices;
//using CardGames;
//using NUnit.Framework;
//
//namespace TexasHoldemTests
//{
//    [TestFixture]
//    class ScorerTests
//    {
//        //Best 5 out of 7
//
//        //each winnning type (straight / two pair
//
//        private Hand _playersHand;
//        private CommunityCards _communityCards;
//
//        [SetUp]
//        public void Setup()
//        {
//            _playersHand = new Hand
//            {
//                Card1 = new Card { Value = "Ace", NumericalValue = 1, Suit = "Clubs" },
//                Card2 = new Card { Value = "Three", NumericalValue = 3, Suit = "Diamonds" }
//            };
//            _communityCards = new CommunityCards
//            {
//                FlopCard1 = new Card { Value = "Eight", NumericalValue = 8, Suit = "Hearts" },
//                FlopCard2 = new Card { Value = "Ten", NumericalValue = 10, Suit = "Clubs" },
//                FlopCard3 = new Card { Value = "Seven", NumericalValue = 7, Suit = "Spades" },
//                River = new Card { Value = "King", NumericalValue = 13, Suit = "Spades" },
//                Turn = new Card { Value = "Two", NumericalValue = 2, Suit = "Diamonds" }
//            };
//        }
////        [Test]
////        public void Should_ReturnOrderedCards_When_CombineIsInvoked()
////        {
////            var expectedCards = new Card[7];
////            expectedCards[0] = new Card { Value = "Ace", NumericalValue = 1, Suit = "Clubs" };
////            expectedCards[1] = new Card { Value = "Ace", NumericalValue = 1, Suit = "Hearts" };
////            expectedCards[2] = new Card {Value = "Two", NumericalValue = 2, Suit = "Diamonds"};
////            expectedCards[3] = new Card { Value = "Three", NumericalValue = 3, Suit = "Diamonds" };
////            expectedCards[4] = new Card { Value = "Seven", NumericalValue = 7, Suit = "Spades" };
////            expectedCards[5] = new Card { Value = "Ten", NumericalValue = 10, Suit = "Clubs" };
////            expectedCards[6] = new Card { Value = "King", NumericalValue = 13, Suit = "Spades" };
////
////            var scorer = new Scorer();
////            var score = scorer.Combine(_playersHand, _communityCards);
////            Assert.That(score, Is.EqualTo(expectedCards));
////        }
//
//        [Test]
//        public void Should_ReturnHighCard_When_EvaluatorIsInvoked()
//        {
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo("High Card"));
//        }
//
//        [Test]
//        public void Should_ReturnAPair_When_EvaluatorIsInvoked()
//        {
//            _communityCards.FlopCard1 = new Card {Value = "Ace", NumericalValue = 1, Suit = "Hearts"};
//      
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo("Pair"));
//        }
//
//        [Test]
//        public void Should_ReturnThreeOfAKind_When_EvaluatorIsInvoked()
//        {
//            _playersHand.Card2 = new Card {Value = "Ace", NumericalValue = 1, Suit = "Diamonds"};
//            _communityCards.FlopCard1 = new Card { Value = "Ace", NumericalValue = 1, Suit = "Hearts" };
//       
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo("Three Of A Kind"));
//        }
//
//        [Test]
//        public void Should_ReturnFourOfAKind_When_EvaluatorIsInvoked()
//        {
//            _playersHand.Card2 = new Card { Value = "Ace", NumericalValue = 1, Suit = "Diamonds" };
//            _communityCards.FlopCard1 = new Card { Value = "Ace", NumericalValue = 1, Suit = "Hearts" };
//            _communityCards.FlopCard3 = new Card { Value = "Ace", NumericalValue = 1, Suit = "Spades" };
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
//
//            _communityCards.FlopCard1 = new Card { Value = "Ace", NumericalValue = 1, Suit = "Hearts" };
//            _communityCards.FlopCard3 = new Card { Value = "Three", NumericalValue = 3, Suit = "Hearts" };
//
//            var scorer = new Scorer();
//            var score = scorer.Evaluate(_playersHand, _communityCards);
//            Assert.That(score, Is.EqualTo("Two Pair"));
//        }
//    }
//
//    internal class Scorer
//    {
//        public string Evaluate(Hand playersHand, CommunityCards communityCards)
//        {
//            //change to switch statement;
//            //FinalHandObject (5 cards and state -- if state same as another player the cards can be compared) 
//            var availableCards = Combine(playersHand, communityCards);
//
//            if (CheckForSinglePair(availableCards))
//            {
//                return "Pair";
//            };
//            if (CheckForThreeOfAKind(availableCards))
//            {
//                return "Three Of A Kind";
//            }
//            if (CheckForFourOfAKind(availableCards))
//            {
//                return "Four Of A Kind";
//            }
//            if (CheckForTwoPair(availableCards))
//            {
//                return "Two Pair";
//            }
//            if (HighCard(availableCards))
//            {
//                return "High Card";
//            }
//            
//            return null;
//        }
//
//        private bool HighCard(Card[] availableCards)
//        {
//            return true;
//        }
//
//        private static bool CheckForSinglePair(Card[] availableCards)
//        {
//            var count = 0;
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                }
//            }
//            return count == 1;
//        }
//        
//        private static bool CheckForThreeOfAKind(Card[] availableCards)
//        {
//            var count = 0;
//            var cardNumericalValue = 0;
//            var occuranceCount = 0;
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                    cardNumericalValue = availableCards[i].NumericalValue;
//                }
//            }
//            for (var i = 0; i < 7; i++)
//            {
//                if (cardNumericalValue == availableCards[i].NumericalValue)
//                {
//                    occuranceCount++;
//                }
//            }
//            return (count == 2 && occuranceCount ==3);
//        }
//
//        private static bool CheckForFourOfAKind(Card[] availableCards)
//        {
//            var count = 0;
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                }
//            }
//            return count == 3;
//        }
//
//        private static bool CheckForTwoPair(Card[] availableCards)
//        {
//            var count = 0;
//            for (var i = 0; i < 7; i++)
//            {
//                if (i + 1 != 7 && availableCards[i].NumericalValue == availableCards[i + 1].NumericalValue)
//                {
//                    count++;
//                }
//            }
//            return count == 2;
//        }
//
//        private Card[] Combine(Hand playersHand, CommunityCards communityCards)
//        {
//            // better as a model?
//            var combinedCards = new Card[7];
//            combinedCards[0] = playersHand.Card1;
//            combinedCards[1] = playersHand.Card2;
//            combinedCards[2] = communityCards.FlopCard1;
//            combinedCards[3] = communityCards.FlopCard2;
//            combinedCards[4] = communityCards.FlopCard3;
//            combinedCards[5] = communityCards.River;
//            combinedCards[6] = communityCards.Turn;
//            
//            Array.Sort(combinedCards,
//                (x, y) => x.NumericalValue.CompareTo(y.NumericalValue));
//
//            return combinedCards;
//        }
//    }
//
//    internal class Hand
//    {
//        public Card Card1 { get; set; }
//        public Card Card2 { get; set; }
//    }
//
//    internal class CommunityCards
//    {
//        public Card FlopCard1 { get; set; }
//        public Card FlopCard2 { get; set; }
//        public Card FlopCard3 { get; set; }
//        public Card River { get; set; }
//        public Card Turn { get; set; }
//    }
//}
