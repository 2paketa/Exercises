using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Lift
    {
        private int maxCapacity;
        private int floorNumber;
        public Lift()
        {
            var capacities = Capacities.Instance();
            maxCapacity = capacities.Get("Lift");
            cycles = capacities.Get("Cycles");
        }

        public List<Visitor> Visitors { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get {return maxCapacity;} }

        readonly int cycles;

        public void Operate(ILocation[] Floors)
        {
            while (cycles > 0)
            {
                for 
                Floors.Visitors.AddRange(Visitors
                .TakeWhile(x =>Floors.IsThereSpace == true)
                .Where(x => x.FloorNumber == Floors.Number)
                .OrderBy(x => x.PriorityNumber));


                

            }
        }



    }
}