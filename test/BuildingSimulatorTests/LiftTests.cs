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
            EFloor[] efloor = new EFloor[4];
            Visitor visitor = new Visitor(5, 0);
            int expected = 4;
            //Act
            lift.Operate();
            int actual = efloor.Length;
            
            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestName()
        {
            Random random = new Random();
            Lift lift = new Lift();
            EFloor[] eFloor = new EFloor[4];
            int o = 1;
            while (o < eFloor.Length)
            {
                var newFloor = LocationFactory.GetLocation(o) as EFloor;
                eFloor[o - 1] = newFloor;
                o++;
            }
            var gFloor = LocationFactory.GetLocation(0) as GroundFloor;
            for (int i = 0; i < 5; i++)
                gFloor.Enter(new Visitor(random.Next(1, eFloor.Length), random.Next(0, 9)));

            lift.Operate();
        }
    }
}
