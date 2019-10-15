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
            eFloor = new EFloor();
            groundFloor = new GroundFloor();
            lift = new Lift();

            
        }

        EFloor eFloor;
        GroundFloor groundFloor;
        Lift lift;

        public ILocation getFloor(int numberOfWheels)
        {
            switch (numberOfWheels)
            {
                case 1:
                    return eFloor[0];
                case 2:
                    return eFloor[1];
                case 3:
                    return eFloor[2];
                case 4:
                    return eFloor[3];
                default :
                    return groundFloor;
            }
        }

    }
}