using BuildingSimulator;
using Xunit;

namespace BuildingSimulatorTests
{
    public class FactoryTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var expected = LocationSingletory.GetLocation(1);
            //Act
            var actual = LocationSingletory.GetLocation(6);
            //Assert
            Assert.Null(actual);
        }
    }
}
