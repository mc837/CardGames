using NUnit.Framework;
using CardGames;

namespace TexasHoldemTests
{
    // can deal 2 cards to a hand

    internal class DeckTest
    {
        [Test]
        public void Should_DealACard_When_DealIsInvoked()
        {
            var deck = new Deck();

            var card = deck.Deal(0);

            Assert.That(card, Is.Not.EqualTo(null));
        }

        [TestCase("Ace", "Hearts", 0)]
        [TestCase("King", "Hearts", 0)]
        [TestCase("Ace", "Clubs", 0)]
        public void Should_DealCard_When_DealIsInvokedWithAPosition(string value, string suit, int deckPosition)
        {
            var deck = new Deck();
            var expectedCard = new Card {Value = "Ace", Suit = "Hearts"};

            var card = deck.Deal(0);

            Assert.That(card.Equals(expectedCard));
        }


        [Test]
        public void Should_ShuffleDeck_When_ShuffleIsInvoked()
        {
            var deck = new Deck();
            var nonShuffledDeck = new Card[52];
            var shuffledDeck = new Card[52];

            for (var i = 0; i < 52; i++)
            {
                nonShuffledDeck[i] = deck.Deal(i);
            }

            deck.Shuffle();

            for (var i = 0; i < 52; i++)
            {
                shuffledDeck[i] = deck.Deal(i);
            }

            Assert.That(shuffledDeck, Is.Not.EqualTo(nonShuffledDeck));
        }

        [Test]
        public void Should_OnlyContainOneOfEachCard_When_Shuffled()
        {
            var singleOccurance = true;
            var deck = new Deck();
            var nonShuffledDeck = new Card[52];
            var shuffledDeck = new Card[52];

            for (var i = 0; i < 52; i++)
            {
                nonShuffledDeck[i] = deck.Deal(i);
            }

            deck.Shuffle();

            for (var i = 0; i < 52; i++)
            {
                shuffledDeck[i] = deck.Deal(i);
            }

            foreach (var card in nonShuffledDeck)
            {
                var count = 0;
                for (var i = 0; i < 52; i++)
                {
                    if (card == shuffledDeck[i])
                    {
                        count++;
                    }
                }
                if (count <= 1) continue;
                singleOccurance = false;
                break;
            }
            Assert.True(singleOccurance);
        }    
    }
}
