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
            Random random = new Random();
            Lift lift = new Lift();
            var gFloor = LocationFactory.GetLocation(0) as GroundFloor;
            for (int i = 0; i < 50; i++)
                gFloor.Enter(new Visitor(random.Next(0, 3), random.Next(0, 9)));
            int expected = 1;
            //Act
            lift.Operate();
            int actual = lift.floorNumber;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
