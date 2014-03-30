using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverKata.UnitTest
{
    [TestClass]
    public class MarsRoverKataApiTest
    {
        [TestMethod]
        public void MarsRoverKataApiTest_InitializeConstructorWithStartingPosition()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, startingLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_ForwardCommand()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N);
            Location expectedLocation = new Location(1, 2, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("F");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_BackwardCommand()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N);
            Location expectedLocation = new Location(1, 0, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("B");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_RotateLeftCommand()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N);
            Location expectedLocation = new Location(1, 1, CardinalPoint.W);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("L");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_RotateRightCommand()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N);
            Location expectedLocation = new Location(1, 1, CardinalPoint.E);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("R");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_GoNorthUntilHeCirclesThePlanet_ReturnToStartingPoint()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("FFFFF");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_GoEastUntilHeCirclesThePlanet_ReturnToStartingPoint()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.E);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("RFFFFF");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_GoWestUntilHeCirclesThePlanet_ReturnToStartingPoint()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.W);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("LFFFFF");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_GoSouthBackwardUntilHeCirclesThePlanet_ReturnToStartingPoint()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("BBBBB");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_GoSouthUntilHeCirclesThePlanet_ReturnToStartingPoint()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.S);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("LLFFFFF");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_RotateLeftInOnePlace_RemainsInStartingPoint()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("LLLL");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }
        
        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_RotateRightInOnePlace_RemainsInStartingPoint()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("RRRR");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }


        [TestMethod]
        [ExpectedException(typeof(ObstacleFound))]
        public void MarsRoverKataApiTest_SendRoverCommand_GoNorthOnly_EncountersObstacle()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation, true);

            roverApi.SendCommand("FFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        }

        [TestMethod]
        [ExpectedException(typeof(ObstacleFound))]
        public void MarsRoverKataApiTest_SendRoverCommand_GoWestOnly_EncountersObstacle()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.W);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation, true);

            roverApi.SendCommand("LFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ObstacleFound))]
        public void MarsRoverKataApiTest_SendRoverCommand_GoEastOnly_EncountersObstacle()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.E);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation, true);

            roverApi.SendCommand("RFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        }

        [TestMethod]
        [ExpectedException(typeof(ObstacleFound))]
        public void MarsRoverKataApiTest_SendRoverCommand_GoSouthOnly_EncountersObstacle()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.S);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation, true);

            roverApi.SendCommand("RRFFFFFFFFFFFFFFFFFFFFFFFF");
        }


        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand_RandomPattern()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N, 5);
            Location expectedLocation = new Location(1, 1, CardinalPoint.S);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation, false);

            roverApi.SendCommand("RFBLRLBFRFFFLFFRFFFRFFFFFFLBLR");
        }
    }
}
