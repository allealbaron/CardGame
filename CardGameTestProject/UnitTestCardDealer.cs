using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using CardGame.Model.FrenchCards;
using CardGame.Model.Interfaces;
using CardGame.Model.RegularDealer;
using CardGame.Model.RegularShuffler;

namespace CardGameTestProject
{
    [TestClass]
    public class UnitTestCardDealer
    {

        /// <summary>
        /// Checks <see cref="RegularDealer"/>, it shall return 0
        /// when asking for a card from a brand new <see cref="IDeck"/>
        /// </summary>
        [TestMethod]
        public void T01_Test_Dealer()
        {

            RegularDealer dealer = new();
            RegularShuffler shuffler = new();

            FrenchDeck deck = new (shuffler, dealer);

            Assert.AreEqual(dealer.GetIndexCardDealed(deck.Cards), 0);

        }

        /// <summary>
        /// Checks <see cref="RegularDealer"/>, it shall throw an exception
        /// when asking for a card from an empty <see cref="List{ICard}"/>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "No cards found")]
        public void T02_Test_Dealer_EmptyDeck()
        {

            RegularDealer dealer = new();

            List<ICard> cards = new();

            _ = dealer.GetIndexCardDealed(cards);

        }

    }
}
