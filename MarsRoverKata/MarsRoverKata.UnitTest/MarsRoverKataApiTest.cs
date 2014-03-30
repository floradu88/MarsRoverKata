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
        public void MarsRoverKataApiTest_SendRoverCommand()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N);
            Location expectedLocation = new Location(1, 2, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("F");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }

        [TestMethod]
        public void MarsRoverKataApiTest_SendRoverCommand()
        {
            Location startingLocation = new Location(1, 1, CardinalPoint.N);
            Location expectedLocation = new Location(1, 0, CardinalPoint.N);
            MarsRoverKataApi roverApi = new MarsRoverKataApi(startingLocation);

            roverApi.SendCommand("B");

            Location location = roverApi.GetCurrentLocation();

            Assert.AreEqual(location, expectedLocation);
        }
    }
}
