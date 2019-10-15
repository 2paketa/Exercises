using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class EFloor: ILocation
    {
        public List<Visitor> Visitors { get; set; }
        public Office[] offices;
        private int maxCapacity;
        private int number = 1;

        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get {return maxCapacity;}}

        public int Number {get {return number;}}

        public bool IsThereSpace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EFloor()
        {
            var capacities = Capacities.Instance();
            this.maxCapacity = capacities.Get("Floor");

            number ++;
            int i = 0;
            while (i < 10)
            {
                offices[i] = new Office();
            }
        }

    }
}