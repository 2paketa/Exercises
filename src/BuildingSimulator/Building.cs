using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Building
    {
        List<Visitor> visitors;
        public int CurrentCapacity { get; set; }
        readonly int MaxCapacity;
        public Building(int MaxCapacity)
        {
            this.MaxCapacity = MaxCapacity;
        }

        public  void Main()
        {
            int i = 1;
            while (i < eFloor.Length)
            {
                var newFloor = LocationFactory.GetLocation(i) as EFloor;
                eFloor[i - 1] = newFloor;
                i++;
            }
            groundFloor = LocationFactory.GetLocation(0) as GroundFloor;
            lift = new Lift();
            // lift.Operate();
            
        }

        EFloor[] eFloor = new EFloor[4];
        GroundFloor groundFloor;
        Lift lift;

    }
}