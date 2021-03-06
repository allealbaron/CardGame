using System;
using System.Collections.Generic;

using CardGame.Model.Interfaces;
using static CardGame.Model.SpanishCards.SpanishCard;

namespace CardGame.Model.SpanishCards
{
    /// <summary>
    /// Represents a deck of Spanish <see cref="ICard"/>, as the
    /// used in mus or tute
    /// </summary>
    public class SpanishDeck : IDeck
    {
        #region " Class members "
        
        /// <summary>
        /// Shuffler
        /// </summary>
        private readonly IShuffler _shuffler;

        /// <summary>
        /// Dealer
        /// </summary>
        private readonly IDealer _dealer;

        /// <summary>
        /// Deck of cards as a <see cref="List{ICard}"/>
        /// </summary>
        private IList<ICard> _deck;

        #endregion

        #region " Properties "

        /// <summary>
        /// Property with the deck of <see cref="ICard"/> as a <see cref="IList{ICard}"/>
        /// </summary>
        public IList<ICard> Cards
        {
            get
            {
                return _deck;
            }
        }

        #endregion

        #region " Class Builder "

        /// <summary>
        /// Creates a new Spanish Deck
        /// </summary>
        /// <param name="shuffler"><see cref="IShuffler"/> used to shuffle cards</param>
        /// <param name="dealer"><see cref="IDealer"/> used to deal a card</param>

        public SpanishDeck(IShuffler shuffler, IDealer dealer)
        {
            _shuffler = shuffler;
            _dealer = dealer;

            _deck = GenerateCardDeck();

        }

        #endregion

        #region " Interface implemented methods "

        /// <summary>
        /// Shuffles the deck of cards
        /// </summary>
        public void Shuffle()
        {
            _deck = _shuffler.Shuffle(_deck);
        }

        /// <summary>
        /// Returns a card
        /// </summary>
        /// <returns>First card in the deck</returns>
        public ICard DealOneCard()
        {
            try
            {
                int index = _dealer.GetIndexCardDealed(_deck);

                ICard result = _deck[index];

                _deck.RemoveAt(index);

                return result;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Generates a brand new sorted deck of cards
        /// </summary>
        /// <returns><see cref="List{ICard}"/> containing a complete deck</returns>
        public IList<ICard> GenerateCardDeck()
        {
            List<ICard> result = new();

            foreach (SpanishSuit ss in Enum.GetValues(typeof(SpanishSuit)))
            {
                foreach (SpanishFaceValue sfv in Enum.GetValues(typeof(SpanishFaceValue)))
                {
                    result.Add(new SpanishCard(sfv, ss));
                }
            }

            return result;

        }

        /// <summary>
        /// Gets the number of cards of a brand new deck
        /// </summary>
        /// <returns>Number of cards</returns>
        public int NumberOfCardsEntireDeck()
        {
            return Enum.GetNames(typeof(SpanishCard.SpanishFaceValue)).Length *
                   Enum.GetNames(typeof(SpanishCard.SpanishSuit)).Length;

        }

        /// <summary>
        /// Returns if the deck is empty
        /// </summary>
        /// <returns>Returns if the deck is empty</returns>
        public bool IsEmptyDeck()
        {
            return (_deck.Count == 0); 
        }

        #endregion

    }
}
