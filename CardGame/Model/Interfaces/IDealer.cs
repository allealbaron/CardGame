using System.Collections.Generic;

namespace CardGame.Model.Interfaces
{
    /// <summary>
    /// Interface for dealer methods
    /// </summary>
    public interface IDealer
    {

        #region " Public methods "

        /// <summary>
        /// Method that returns the index of the 
        /// <see cref="ICard"/> that it is going to be
        /// dealed
        /// </summary>
        /// <returns>Index of the <see cref="ICard"/> selected 
        /// by the method implemented</returns>
        public int GetIndexCardDealed(IList<ICard> deck);

        #endregion

    }
}