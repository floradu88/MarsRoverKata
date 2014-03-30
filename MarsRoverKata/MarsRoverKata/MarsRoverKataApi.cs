using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class MarsRoverKataApi
    {
        //simulate obstacle found by using random
        // we don't really now what can we expect to find on mars
        private Random randomNumberGenerator = new Random();

        private Location currentLocation;
        private int range;
        private bool simulateObstacles;
        /// <summary>
        /// Initializes a new instance of the <see cref="MarsRoverKataApi"/> class.
        /// </summary>
        /// <param name="location">The starting location of the rover on Mars surface</param>
        public MarsRoverKataApi(Location location, bool simulateObstacles = false)
        {
            this.currentLocation = location;
            this.simulateObstacles = simulateObstacles;
        }


        public Location GetCurrentLocation()
        {
            return this.currentLocation;
        }

        public void SendCommand(string commandLine)
        {
            if (!string.IsNullOrEmpty(commandLine))
            {
                for (int i = 0; i < commandLine.Length; i++)
                {
                    char c = commandLine[i];
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
            checkForObstacle('F');
            this.currentLocation.MoveForward();
        }

        private void checkForObstacle(char command)
        {
            if (simulateObstacles)
            {
                int randomNumber = randomNumberGenerator.Next(10);
                //will presume that if the number is above 8 this is most likely an obstacle 
                if (randomNumber >= 8)
                {
                    throw new ObstacleFound("Obstacle Found near location {0}, cannot move {1}", currentLocation, command);
                }
            }
        }
    }
}
