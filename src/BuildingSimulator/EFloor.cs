using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class EFloor: ILocation
    {
        public List<Visitor> Visitor { get; set; }
        public Office[] offices;
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }

        public EFloor(int MaxCapacity)
        {
            this.MaxCapacity = MaxCapacity;
            int i = 0;
            while (i < 10)
            {
                offices[i] = new Office();
            }
        }

    }
}