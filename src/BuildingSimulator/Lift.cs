using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Lift: ILocation
    {
        public Lift()
        {
            Capacities capacities = Capacities.Instance();
            MaxCapacity = capacities.Get("Lift");
            Console.WriteLine(MaxCapacity);
        }

        public List<Visitor> Visitor { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }

    }
}