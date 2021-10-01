using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using CardGame.Model.SpanishCards;
using CardGame.Model.Interfaces;
using CardGame.Model.RegularDealer;
using CardGame.Model.RegularShuffler;
using static CardGame.Model.SpanishCards.SpanishCard;

namespace CardGameTestProject
{
    [TestClass]
    public class UnitTestSpanishCard
    {
        /// <summary>
        /// Checks <see cref="SpanishDeck"/>, when creating
        /// a new deck that deck should contain all the cards
        /// (<see cref="IDeck.NumberOfCardsEntireDeck"/>)
        /// </summary>
        [TestMethod]
        public void T01_Create_New_Deck()
        {
            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            SpanishDeck deck = new(shuffler, dealer);

            Assert.AreEqual(deck.Cards.Count, deck.NumberOfCardsEntireDeck());

        }

        /// <summary>
        /// Checks <see cref="SpanishDeck"/>, after creating
        /// a new deck and shuffling it, elements shall be in a
        /// different order
        /// </summary>
        [TestMethod]
        public void T02_ShuffleDeck()
        {

            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            SpanishDeck deck = new(shuffler, dealer);
            IList<ICard> cardDeck = deck.GenerateCardDeck(); // This deck is sorted

            deck.Shuffle();

            bool equalDects = true;

            int i = 0;

            while (i < deck.Cards.Count && equalDects)
            {
                equalDects = deck.Cards[i].Equals(cardDeck[i]);
                i++;
            }

            Assert.AreEqual(equalDects, false);

        }

        /// <summary>
        /// Checks <see cref="SpanishDeck"/>, after creating a deck,
        /// deals all the cards and try to deal a new card when the deck
        /// is empty. It shall throw an exception.
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(Exception), "No cards found")]
        public void T03_EmptyDeck()
        {

            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            SpanishDeck deck = new(shuffler, dealer);

            deck.Shuffle();

            for (int i = 0; i < deck.NumberOfCardsEntireDeck(); i++)
            {
                _ = deck.DealOneCard();
            }

            Assert.AreEqual(deck.IsEmptyDeck(), true);

            _ = deck.DealOneCard(); // It should crash

        }

        /// <summary>
        /// Checks <see cref="SpanishDeck"/>, after creating a deck,
        /// without shuffling it, the first card is dealed and it shall be
        /// the first card in the deck (<see cref="SpanishFaceValue.As"/>, 
        /// <see cref="SpanishSuit.Oros"/>).
        /// </summary>
        [TestMethod]
        public void T04_GetFirstCard()
        {

            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            SpanishDeck deck = new(shuffler, dealer);

            SpanishCard card = (SpanishCard)deck.DealOneCard();

            SpanishCard asOfOros = new(SpanishFaceValue.As, SpanishSuit.Oros);

            Assert.IsNotNull(card);
            Assert.AreEqual(card.Suit, asOfOros.Suit);
            Assert.AreEqual(card.FaceValue, asOfOros.FaceValue);
            Assert.AreEqual(card.Equals(asOfOros), true);
            Assert.AreEqual(deck.Cards.Count, deck.NumberOfCardsEntireDeck() - 1);

        }

        /// <summary>
        /// Checks <see cref="SpanishCard"/>, compares two consecutive
        /// <see cref="ICard"/> and their order
        /// </summary>

        [TestMethod]
        public void T05_CompareCards()
        {

            SpanishCard asOfOros = new(SpanishFaceValue.As, SpanishSuit.Oros);
            SpanishCard twoOfOros = new(SpanishFaceValue.Two, SpanishSuit.Oros);

            Assert.AreEqual(asOfOros.CompareTo(twoOfOros), -1);
            Assert.AreEqual(asOfOros.CompareTo(asOfOros), 0);
            Assert.AreEqual(twoOfOros.CompareTo(asOfOros), 1);
            Assert.AreEqual(asOfOros.Equals(twoOfOros), false);

        }

        /// <summary>
        /// Checks <see cref="SpanishCard"/>, print its value
        /// </summary>

        [TestMethod]
        public void T06_PrintCard()
        {

            SpanishCard aceOfOros = new(SpanishFaceValue.As, SpanishSuit.Oros);

            string text = String.Format("{0} of {1}", SpanishFaceValue.As.ToString(),
                                          SpanishSuit.Oros.ToString());


            Assert.AreEqual(aceOfOros.ToString(), text);

        }

        /// <summary>
        /// Checks a new <see cref="FrenchDeck"/> before and after shuffling it
        /// </summary>
        [TestMethod]
        public void T07_CheckEntireDeck()
        {
            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            SpanishDeck deck = new(shuffler, dealer);

            int numberOfCards = (from c in deck.Cards
                                 select c).Distinct().ToList().Count;

            Assert.AreEqual(numberOfCards, deck.NumberOfCardsEntireDeck());

            deck.Shuffle();

            numberOfCards = (from c in deck.Cards
                             select c).Distinct().ToList().Count;

            Assert.AreEqual(numberOfCards, deck.NumberOfCardsEntireDeck());

        }

        /// <summary>
        /// Checks two identical <see cref="ICard"/>. It shall return true.
        /// </summary>
        [TestMethod]
        public void T08_CheckTwoIdenticalCards()
        {

            SpanishCard c1 = new(SpanishFaceValue.As, SpanishSuit.Espadas);
            SpanishCard c2 = new(SpanishFaceValue.As, SpanishSuit.Espadas);

            Assert.AreEqual(c1.Equals(c2), true);

        }

        /// <summary>
        /// Checks two different cards. It shall return false.
        /// </summary>
        [TestMethod]
        public void T08_CheckTwoDifferentCards()
        {

            SpanishCard c1 = new(SpanishFaceValue.As, SpanishSuit.Espadas);
            SpanishCard c2 = new(SpanishFaceValue.Rey, SpanishSuit.Espadas);

            Assert.AreEqual(c1.Equals(c2), false);

        }

    }
}
