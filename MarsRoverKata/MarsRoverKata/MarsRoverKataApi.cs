using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class MarsRoverKataApi
    {
        private Location startingLocation;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarsRoverKataApi"/> class.
        /// </summary>
        /// <param name="location">The starting location of the rover on Mars surface</param>
        public MarsRoverKataApi(Location location)
        {
            this.startingLocation = location;
        }


        public Location GetCurrentLocation()
        {
            return this.startingLocation;
        }

        public void SendCommand(string commandLine)
        {
            if (!string.IsNullOrEmpty(commandLine))
            {
                foreach (char c in commandLine)
                {
                    switch (c)
                    {
                        case 'F':
                            moveForward();
                            break;
                        case 'B':
                            moveBackward();
                            break;
                        case 'L':
                            rotateLeft();
                            break;
                        case 'R':
                            rotateRight();
                            break;
                    }
                }
            }
        }

        private void rotateRight()
        {
            throw new NotImplementedException();
        }

        private void rotateLeft()
        {
            throw new NotImplementedException();
        }

        private void moveBackward()
        {
            throw new NotImplementedException();
        }

        private void moveForward()
        {
            throw new NotImplementedException();
        }
    }
}
