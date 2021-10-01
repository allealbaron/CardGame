using System;

namespace CardGame.Model.Interfaces
{
    /// <summary>
    /// Interface describing cards in decks
    /// </summary>
    public interface ICard : IComparable, IEquatable<ICard>
    {

        #region " Public methods "

        /// <summary>
        /// Returns this object's properties as a string
        /// </summary>
        /// <returns>Object as a string</returns>
        public string ToString();

        /// <summary>
        /// Compare method (Implementing <see cref="IComparable"/>)
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>-1 if current object precedes <paramref name="obj"/>, 
        /// 0 if they are equal and 1 if <paramref name="obj"/> precedes 
        /// current object </returns>
        public new int CompareTo(object obj);

        /// <summary>
        /// Returns if current object is equal to the object
        /// passed as parameter
        /// </summary>
        /// <param name="other">Item to compare</param>
        /// <returns>True if they are equal, false otherwise</returns>
        public new bool Equals(ICard other);

        /// <summary>
        /// Returns this object's hashcode
        /// </summary>
        /// <returns>Object's hashcode</returns>
        public int GetHashCode();

        #endregion

    }
}
