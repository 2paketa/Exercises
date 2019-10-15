using System;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class GroundFloor: ILocation
    {
        public GroundFloor(int MaxCapacity)
        {
            this.MaxCapacity = MaxCapacity;
        }

        public List<Visitor> Visitor { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
    }
}