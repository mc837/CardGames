﻿using System;
using System.Collections.Generic;
using CardGames.Enums;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var scorer = new Scorer();
            var mongo = new Mongo();

            while (true)
            {
                Console.Clear();
                play(deck, scorer);
            }

        }

        public static void play(Deck deck, Scorer scorer)
        {
            deck.Shuffle();
            List<Card> hand = new List<Card>
            {
               deck.Deal(0),
               deck.Deal(1)
            };
            var playersCard1Display = string.Format(hand[0].Value() + " " + hand[0].Suit);
            var playersCard2Display = string.Format(hand[1].Value() + " " + hand[1].Suit);

            Console.WriteLine("Hand:");
            Console.WriteLine("{0}      {1}", playersCard1Display, playersCard2Display);
            //Console.ReadKey();

            Console.WriteLine("");

            Console.WriteLine("Community Cards: ");
            List<Card> communityCards = new List<Card>
            {
                deck.Deal(2),
                deck.Deal(3),
                deck.Deal(4),
                deck.Deal(5),
                deck.Deal(6)
            };

            Console.WriteLine("{0} {1}   {2} {3}   {4} {5}   {6} {7}   {8} {9}",
                communityCards[0].Value(), communityCards[0].Suit,
                communityCards[1].Value(), communityCards[1].Suit,
                communityCards[2].Value(), communityCards[2].Suit,
                communityCards[3].Value(), communityCards[3].Suit,
                communityCards[4].Value(), communityCards[4].Suit
                );
            //Console.ReadKey();

            Console.WriteLine("");

            var score = scorer.Evaluate(hand, communityCards);
            Console.WriteLine(score.rank);
            Console.WriteLine("");
            Console.WriteLine("{0} {1}   {2} {3}   {4} {5}   {6} {7}   {8} {9}",
                score.card1.Value(), score.card1.Suit,
                score.card2.Value(), score.card2.Suit,
                score.card3.Value(), score.card3.Suit,
                score.card4.Value(), score.card4.Suit,
                score.card5.Value(), score.card5.Suit
                );

            Console.ReadKey();
        }
    }
}
