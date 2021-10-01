using System;

using CardGame.Model.Interfaces;

namespace CardGame.Model.FrenchCards
{
    /// <summary>
    /// Represents a French <see cref="ICard"/>
    /// </summary>
    public class FrenchCard : ICard
    {

        #region " Public Enums "

        /// <summary>
        /// Face values used in French cards
        /// </summary>
        public enum FrenchFaceValue:int
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        /// <summary>
        /// Suits used in French cards
        /// </summary>
        public enum FrenchSuit : int
        { 
            Hearts = 1,
            Spades = 2,
            Clubs = 3,
            Diamonds = 4
        }

        #endregion

        #region " Class members "

        /// <summary>
        /// Face Value
        /// </summary>
        public FrenchFaceValue FaceValue { get; set; }

        /// <summary>
        /// Suit
        /// </summary>
        public FrenchSuit Suit { get; set; }

        #endregion

        #region " Class builder "

        /// <summary>
        /// Creates a new <see cref="FrenchCard"/>
        /// </summary>
        /// <param name="faceValue">Facevalue</param>
        /// <param name="suit">Suit</param>
        public FrenchCard(FrenchFaceValue faceValue, FrenchSuit suit)
        {
            FaceValue = faceValue;
            Suit = suit;
        }

        #endregion

        #region " Public methods "

        /// <summary>
        /// Returns this object's properties as a string
        /// </summary>
        /// <returns>Object as a string</returns>
        public override string ToString()
        {
            return String.Format("{0} of {1}", FaceValue, Suit);
        }

        /// <summary>
        /// Compare method (Implementing <see cref="IComparable"/>)
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>-1 if current object precedes <paramref name="obj"/>, 
        /// 0 if they are equal and 1 if <paramref name="obj"/> precedes 
        /// current object </returns>
        public int CompareTo(object obj)
        {

            if (obj == null)
            {
                return 1;
            }
            else
            {
                FrenchCard otherCard = (FrenchCard)obj;

                if (FaceValue < otherCard.FaceValue)
                {
                    return -1;
                }
                else
                {
                    if (FaceValue > otherCard.FaceValue)
                    {
                        return 1;
                    }
                    else
                    {
                        return Suit.CompareTo(otherCard.Suit);
                    }
                }
            }

        }

        /// <summary>
        /// Returns if current object is equal to the object
        /// passed as parameter
        /// </summary>
        /// <param name="other">Item to compare</param>
        /// <returns>True if they are equal, false otherwise</returns>
        public bool Equals(ICard other)
        {
            FrenchCard otherCard = (FrenchCard)other;
            return other != null && otherCard.FaceValue == this.FaceValue
                   && otherCard.Suit == this.Suit;

        }

        /// <summary>
        /// Calculates HashCode
        /// </summary>
        /// <returns>Calculates HashCode</returns>
        public override int GetHashCode()
        {
            return (this.FaceValue.GetHashCode() + this.Suit.GetHashCode()*2281);
        }

        #endregion

    }
}
