using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    /// <summary>
    /// 
    /// </summary>
    public class Location
    {
        public Location(int x, int y, MarsRoverKata.CardinalPoint cardinalPoint)
        {
            this.X = x;
            this.Y = y;
            this.CardinalPoint = cardinalPoint;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public CardinalPoint CardinalPoint { get; private set; }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.
        /// </returns>
        public override bool Equals(System.Object obj)
        {
            if (!(obj is Location))
                return false;
            Location other = obj as Location;
            return (X == other.X && Y == other.Y && CardinalPoint == other.CardinalPoint);
        }

        internal void MoveForward()
        {
            switch (this.CardinalPoint)
            {
                case MarsRoverKata.CardinalPoint.N:
                case MarsRoverKata.CardinalPoint.S:
                    Y = Y + 1;
                    break;
                case MarsRoverKata.CardinalPoint.E:
                case MarsRoverKata.CardinalPoint.W:
                    X = X + 1;
                    break;
            }
        }

        internal void MoveBackward()
        {
            switch (this.CardinalPoint)
            {
                case MarsRoverKata.CardinalPoint.N:
                case MarsRoverKata.CardinalPoint.S:
                    Y = Y - 1;
                    break;
                case MarsRoverKata.CardinalPoint.E:
                case MarsRoverKata.CardinalPoint.W:
                    X = X - 1;
                    break;
            }
        }

        internal void RotateLeft()
        {
            switch (this.CardinalPoint)
            {
                case MarsRoverKata.CardinalPoint.N:
                    this.CardinalPoint = CardinalPoint.W;
                    break;
                case MarsRoverKata.CardinalPoint.W:
                    this.CardinalPoint = CardinalPoint.S;
                    break;
                case MarsRoverKata.CardinalPoint.S:
                    this.CardinalPoint = CardinalPoint.E;
                    break;
                case MarsRoverKata.CardinalPoint.E:
                    this.CardinalPoint = CardinalPoint.N;
                    break;
            }
        }

        internal void RotateRight()
        {
            switch (this.CardinalPoint)
            {
                case MarsRoverKata.CardinalPoint.N:
                    this.CardinalPoint = CardinalPoint.E;
                    break;
                case MarsRoverKata.CardinalPoint.E:
                    this.CardinalPoint = CardinalPoint.S;
                    break;
                case MarsRoverKata.CardinalPoint.S:
                    this.CardinalPoint = CardinalPoint.W;
                    break;
                case MarsRoverKata.CardinalPoint.W:
                    this.CardinalPoint = CardinalPoint.N;
                    break;
            }
        }
    }
}
