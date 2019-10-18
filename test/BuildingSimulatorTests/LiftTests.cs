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
        public void TestName()
        {
            //Arrange
            var lift = new Lift();
            EFloor[] eFloor = new EFloor[4];
            int i = 1;
            while (i <= eFloor.Length)
            {
                var newFloor = LocationFactory.GetLocation(i) as EFloor;
                eFloor[i - 1] = newFloor;
                i++;
            }
            int expected = 0;

            //Act



            //Assert

        }
    }
}
