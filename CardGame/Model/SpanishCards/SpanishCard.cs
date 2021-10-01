using System;

using CardGame.Model.Interfaces;

namespace CardGame.Model.SpanishCards
{
    /// <summary>
    /// Represents a Spanish <see cref="ICard"/>
    /// </summary>
    public class SpanishCard : ICard
    {

        #region " Public Enums "

        /// <summary>
        /// Face values used in Spanish cards
        /// </summary>
        public enum SpanishFaceValue:int
        {
            As = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Sota = 10,
            Caballo = 11,
            Rey = 12
        }

        /// <summary>
        /// Suits used in Spanish cards
        /// </summary>
        public enum SpanishSuit : int
        { 
            Oros = 1,
            Copas = 2,
            Espadas = 3,
            Bastos = 4
        }

        #endregion

        #region " Class members "

        /// <summary>
        /// Face Value
        /// </summary>
        public SpanishFaceValue FaceValue { get; set; }

        /// <summary>
        /// Suit
        /// </summary>
        public SpanishSuit Suit { get; set; }

        #endregion

        #region " Class builder "

        /// <summary>
        /// Creates a new <see cref="SpanishCard"/>
        /// </summary>
        /// <param name="faceValue">Facevalue</param>
        /// <param name="suit">Suit</param>
        public SpanishCard(SpanishFaceValue faceValue, SpanishSuit suit)
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
                SpanishCard otherCard = (SpanishCard)obj;

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
            SpanishCard otherCard = (SpanishCard)other;
            return other != null && otherCard.FaceValue == this.FaceValue
                   && otherCard.Suit == this.Suit;
        }

        /// <summary>
        /// Calculates HashCode
        /// </summary>
        /// <returns>Calculates HashCode</returns>
        public override int GetHashCode()
        {
            return (this.FaceValue.GetHashCode() + this.Suit.GetHashCode() * 2281);
        }

        #endregion

    }
}
