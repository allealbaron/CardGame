using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using CardGame.Model.FrenchCards;
using CardGame.Model.Interfaces;
using CardGame.Model.RegularDealer;
using CardGame.Model.RegularShuffler;
using static CardGame.Model.FrenchCards.FrenchCard;

namespace CardGameTestProject
{
    [TestClass]
    public class UnitTestFrenchCard
    {
        /// <summary>
        /// Checks <see cref="FrenchDeck"/>, when creating
        /// a new deck that deck should contain all the cards
        /// (<see cref="IDeck.NumberOfCardsEntireDeck"/>)
        /// </summary>
        [TestMethod]
        public void T01_Create_New_Deck()
        {
            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            FrenchDeck deck = new(shuffler, dealer);

            Assert.AreEqual(deck.Cards.Count, deck.NumberOfCardsEntireDeck());

        }

        /// <summary>
        /// Checks <see cref="FrenchDeck"/>, after creating
        /// a new deck and shuffling it, elements shall be in a
        /// different order
        /// </summary>
        [TestMethod]
        public void T02_ShuffleDeck()
        {

            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            FrenchDeck deck = new(shuffler, dealer);
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
        /// Checks <see cref="FrenchDeck"/>, after creating a deck,
        /// deals all the cards and try to deal a new card when the deck
        /// is empty. It shall throw an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "No cards found")]
        public void T03_EmptyDeck()
        {

            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            FrenchDeck deck = new(shuffler, dealer);

            deck.Shuffle();

            for (int i = 0; i < deck.NumberOfCardsEntireDeck(); i++)
            {
                _ = deck.DealOneCard();
            }

            Assert.AreEqual(deck.IsEmptyDeck(), true);

            _ = deck.DealOneCard(); // It should crash

        }

        /// <summary>
        /// Checks <see cref="FrenchDeck"/>, after creating a deck,
        /// without shuffling it, the first card is dealed and it shall be
        /// the first card in the deck (<see cref="FrenchFaceValue.Ace"/>, 
        /// <see cref="FrenchSuit.Hearts"/>).
        /// </summary>
        [TestMethod]
        public void T04_GetFirstCardCard()
        {

            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            FrenchDeck deck = new(shuffler, dealer);

            FrenchCard card = (FrenchCard)deck.DealOneCard();

            FrenchCard aceOfHearts = new(FrenchFaceValue.Ace, FrenchSuit.Hearts);

            Assert.IsNotNull(card);
            Assert.AreEqual(card.Suit, aceOfHearts.Suit);
            Assert.AreEqual(card.FaceValue, aceOfHearts.FaceValue);
            Assert.AreEqual(card.Equals(aceOfHearts), true);
            Assert.AreEqual(deck.Cards.Count, deck.NumberOfCardsEntireDeck() - 1);

        }

        /// <summary>
        /// Checks <see cref="FrenchCard"/>, compares two consecutive
        /// <see cref="ICard"/> and their order
        /// </summary>
        [TestMethod]
        public void T05_CompareCards()
        {

            FrenchCard aceOfHearts = new(FrenchFaceValue.Ace, FrenchSuit.Hearts);
            FrenchCard twoOfHearts = new(FrenchFaceValue.Two, FrenchSuit.Hearts);

            Assert.AreEqual(aceOfHearts.CompareTo(twoOfHearts), -1);
            Assert.AreEqual(aceOfHearts.CompareTo(aceOfHearts), 0);
            Assert.AreEqual(twoOfHearts.CompareTo(aceOfHearts), 1);
            Assert.AreEqual(aceOfHearts.Equals(twoOfHearts), false);

        }

        /// <summary>
        /// Checks <see cref="FrenchCard"/>, print its value
        /// </summary>
        [TestMethod]
        public void T06_PrintCard()
        {

            FrenchCard aceOfHearts = new(FrenchFaceValue.Ace, FrenchSuit.Hearts);

            string text = String.Format("{0} of {1}", FrenchFaceValue.Ace.ToString(),
                                                      FrenchSuit.Hearts.ToString());

            Assert.AreEqual(aceOfHearts.ToString(), text);

        }

        /// <summary>
        /// Checks a new <see cref="FrenchDeck"/> before and after shuffling it
        /// </summary>
        [TestMethod]
        public void T07_CheckEntireDeck()
        {
            RegularShuffler shuffler = new();
            RegularDealer dealer = new();

            FrenchDeck deck = new(shuffler, dealer);

            int numberOfCards = (from c in deck.Cards
                                   select c).Distinct().ToList().Count;

            Assert.AreEqual(numberOfCards, deck.NumberOfCardsEntireDeck());

            deck.Shuffle();

            numberOfCards = (from c in deck.Cards
                             select c).Distinct().ToList().Count;

            Assert.AreEqual(numberOfCards, deck.NumberOfCardsEntireDeck());

        }

        /// <summary>
        /// Checks two identical <see cref="ICard"/> It shall return true.
        /// </summary>
        [TestMethod]
        public void T08_CheckTwoIdenticalCards()
        {

            FrenchCard c1 = new(FrenchFaceValue.Ace, FrenchSuit.Clubs);
            FrenchCard c2 = new(FrenchFaceValue.Ace, FrenchSuit.Clubs);

            Assert.AreEqual(c1.Equals(c2), true);

        }

        /// <summary>
        /// Checks two different cards. It shall return false.
        /// </summary>
        [TestMethod]
        public void T08_CheckTwoDifferentCards()
        {

            FrenchCard c1 = new(FrenchFaceValue.Ace, FrenchSuit.Clubs);
            FrenchCard c2 = new(FrenchFaceValue.King, FrenchSuit.Clubs);

            Assert.AreEqual(c1.Equals(c2), false);

        }

    }
}
