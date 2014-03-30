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
    public class Location : IComparable<Location>
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
        public int CompareTo(Location other)
        {
            if (other == null)
                return -1;
            return (X == other.X && Y == other.Y && CardinalPoint == other.CardinalPoint) ? 0 : 1;
        }
    }
}
