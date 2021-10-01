using System;
using System.Collections.Generic;

using CardGame.Model.Interfaces;

namespace CardGame.Model.RegularShuffler
{
    /// <summary>
    /// Regular Shuffler: Rearrange the list of
    /// <see cref="ICard"/> in a totally randomized way
    /// </summary>
    public class RegularShuffler : IShuffler
    {
        #region " Interface implemented methods "

        /// <summary>
        /// Method that shuffles a deck of cards
        /// </summary>
        /// <param name="deck">Deck of <see cref="ICard"/> </param>
        /// <returns>Deck shuffled</returns>
        public IList<ICard> Shuffle(IList<ICard> deck)
        {
            Random random = new();

            for (int i = deck.Count - 1; i > 0; i--)
            {
                int position = random.Next(i);

                ICard tempCard = deck[position];

                deck[position] = deck[i];
                deck[i] = tempCard;

            }

            return deck;

        }

        #endregion

    }
}
