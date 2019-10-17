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
            ILocation expected = null;
            //Act
            var actual = LocationFactory.GetLocation(5);
            //Assert
            ILocation.ReferenceEquals(expected, actual);
        }
    }
}
