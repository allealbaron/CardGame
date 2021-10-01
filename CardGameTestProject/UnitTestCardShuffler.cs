using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using CardGame.Model.FrenchCards;
using CardGame.Model.Interfaces;
using CardGame.Model.RegularDealer;
using CardGame.Model.RegularShuffler;

namespace CardGameTestProject
{
    [TestClass]
    public class UnitTestCardShuffler
    {
        /// <summary>
        /// Checks <see cref="RegularShuffler"/>, when having two 
        /// <see cref="IDeck"/>, their order shall be different after
        /// one of the decks is shuffled
        /// </summary>
        [TestMethod]
        public void T01_Test_Shuffler()
        {

            RegularDealer dealer = new();
            RegularShuffler shuffler = new();

            FrenchDeck deck = new(shuffler, dealer);

            IList<ICard> cards = deck.GenerateCardDeck();

            IList<ICard> cards2 = shuffler.Shuffle(new List<ICard>(cards));

            bool equalDects = true;

            int i = 0;

            while (i < cards.Count && equalDects)
            {
                equalDects = cards[i].Equals(cards2[i]);
                i++;
            }

            Assert.AreEqual(equalDects, false);

        }

        /// <summary>
        /// Checks <see cref="RegularShuffler"/>, when having two 
        /// <see cref="List{ICard}"/> containing only a <see cref="ICard"/>, the card
        /// shall be in the same position after the deck is shuffled
        /// </summary>
        [TestMethod]
        public void T02_Test_Shuffler_OneCard()
        {

            RegularShuffler shuffler = new();

            IList<ICard> cards = new List<ICard>() { new FrenchCard(FrenchCard.FrenchFaceValue.Ace, FrenchCard.FrenchSuit.Hearts)};

            IList<ICard> cards2 = shuffler.Shuffle(new List<ICard>(cards));

            Assert.AreEqual(cards[0].ToString(), cards2[0].ToString());

        }

    }
}
