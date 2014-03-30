using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class MarsRoverKataApi
    {
        private Location currentLocation;
        private int range;
        /// <summary>
        /// Initializes a new instance of the <see cref="MarsRoverKataApi"/> class.
        /// </summary>
        /// <param name="location">The starting location of the rover on Mars surface</param>
        public MarsRoverKataApi(Location location)
        {
            this.currentLocation = location;
        }


        public Location GetCurrentLocation()
        {
            return this.currentLocation;
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
            this.currentLocation.RotateRight();
        }

        private void rotateLeft()
        {
            this.currentLocation.RotateLeft();
        }

        private void moveBackward()
        {
            this.currentLocation.MoveBackward();
        }

        private void moveForward()
        {
            this.currentLocation.MoveForward();
        }
    }
}
