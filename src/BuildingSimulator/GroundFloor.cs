using System;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class GroundFloor: ILocation
    {
        private int maxCapacity;

        public GroundFloor()
        {
            var capacities = Capacities.Instance();
            this.maxCapacity = capacities.Get("Groundfloor");
        }

        public List<Visitor> Visitors { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get {return maxCapacity;} }

        public int Number => 0;

        public bool IsThereSpace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}