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
            // eFloor = new EFloor();
            // groundFloor = new GroundFloor();
            lift = new Lift();

            
        }

        EFloor eFloor;
        GroundFloor groundFloor;
        Lift lift;


    }
}