using System;
using System.Collections.Generic;

using CardGame.Model.Interfaces;

namespace CardGame.Model.RegularDealer
{
    /// <summary>
    /// Regular dealer method: Returns the first
    /// <see cref="ICard"/> found
    /// </summary>
    public class RegularDealer : IDealer
    {
        #region " Interface implemented methods "

        /// <summary>
        /// Method that returns the index of the 
        /// <see cref="ICard"/> that it is going to be
        /// dealed
        /// </summary>
        /// <returns>Index of the <see cref="ICard"/> selected 
        /// by the method implemented</returns>
        public int GetIndexCardDealed(IList<ICard> deck)
        {
            if (deck.Count > 0)
            {
                return 0;
            }
            else
            {
                throw new Exception("No cards found");
            }
        }

        #endregion

    }
}
