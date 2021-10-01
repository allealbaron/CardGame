using System.Collections.Generic;

namespace CardGame.Model.Interfaces
{
    #region " Public methods "

    /// <summary>
    /// Interface for shuffle methods
    /// </summary>
    public interface IShuffler
    {

        /// <summary>
        /// Method that shuffles a deck of cards
        /// </summary>
        /// <param name="deck">Deck of <see cref="ICard"/> </param>
        /// <returns>Deck shuffled</returns>
        public IList<ICard> Shuffle(IList<ICard> deck);

    }

    #endregion

}
