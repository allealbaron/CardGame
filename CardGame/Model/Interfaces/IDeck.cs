using System.Collections.Generic;

namespace CardGame.Model.Interfaces
{
    /// <summary>
    /// Class for decks of Cards
    /// </summary>
    public interface IDeck
    {

        #region " Properties "

        /// <summary>
        /// Property with the list of <see cref="ICard"/>
        /// </summary>
        public IList<ICard> Cards { get; }

        #endregion

        #region " Public Methods "

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void Shuffle();

        /// <summary>
        /// Returns a card
        /// </summary>
        /// <returns>First card in the deck</returns>
        public ICard DealOneCard();

        /// <summary>
        /// Generates a brand new sorted deck of cards
        /// </summary>
        /// <returns><see cref="List{ICard}"/> containing a complete deck</returns>
        public IList<ICard> GenerateCardDeck();

        /// <summary>
        /// Gets the number of cards of a brand new deck
        /// </summary>
        /// <returns>Number of cards</returns>
        public int NumberOfCardsEntireDeck();

        /// <summary>
        /// Returns if the deck is empty
        /// </summary>
        /// <returns>Returns if the deck is empty</returns>
        public bool IsEmptyDeck();

        #endregion

    }
}