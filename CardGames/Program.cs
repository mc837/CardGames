using System;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var scorer = new Scorer();

            while (true)
            {
                Console.Clear();
                play(deck, scorer);
            }
            
        }

        public static void play (Deck deck, Scorer scorer)
        {
            deck.Shuffle();
            Hand hand = new Hand
            {
                Card1 = deck.Deal(0),
                Card2 = deck.Deal(1)
            };
            var playersCard1Display = string.Format(hand.Card1.Value() + " " + hand.Card1.Suit);
            var playersCard2Display = string.Format(hand.Card2.Value() + " " + hand.Card2.Suit);

            Console.WriteLine("Hand:");
            Console.WriteLine("{0}      {1}", playersCard1Display, playersCard2Display);
            //Console.ReadKey();

            Console.WriteLine("");

            Console.WriteLine("Community Cards: ");
            CommunityCards communityCards = new CommunityCards
            {
                FlopCard1 = deck.Deal(2),
                FlopCard2 = deck.Deal(3),
                FlopCard3 = deck.Deal(4),
                River = deck.Deal(5),
                Turn = deck.Deal(6)
            };

            Console.WriteLine("{0} {1}   {2} {3}   {4} {5}   {6} {7}   {8} {9}",
                communityCards.FlopCard1.Value(), communityCards.FlopCard1.Suit,
                communityCards.FlopCard2.Value(), communityCards.FlopCard2.Suit,
                communityCards.FlopCard3.Value(), communityCards.FlopCard3.Suit,
                communityCards.River.Value(), communityCards.River.Suit,
                communityCards.Turn.Value(), communityCards.Turn.Suit
                );
            //Console.ReadKey();

            Console.WriteLine("");

            var score = scorer.Evaluate(hand, communityCards);
            Console.WriteLine(score);
            Console.ReadKey();
        }
    }
}
