using System;
using Xunit;
using BuildingCommon;
using BuildingSimulator;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSimulatorTests
{
    public class LiftTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Lift lift = new Lift();
            var gFloor = LocationFactory.GetLocation(0);
            for (int i = 0; i < 50; i++)
                gFloor.Enter(new Visitor());
            int expected = 0;
            //Act
            lift.moveUp();
            int actual = lift.floorNumber;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
