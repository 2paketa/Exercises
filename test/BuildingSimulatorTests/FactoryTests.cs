using System;
using Xunit;
using BuildingCommon;
using BuildingSimulator;

namespace BuildingSimulatorTests
{
    public class FactoryTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var expected = new EFloor();
            //Act
            var actual = LocationFactory.GetLocation(6);
            //Assert
            Assert.Null(actual);
        }
    }
}
