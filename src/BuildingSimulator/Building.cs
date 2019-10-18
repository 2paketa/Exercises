using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Building
    {
        
        public int CurrentCapacity { get; set; }
        readonly int MaxCapacity;
        Capacities capacities;
        public Building()
        {
            capacities = Capacities.Instance();
            this.MaxCapacity = capacities.Get("Building");
        }

        public  void Main()
        {
            Random random = new Random();
            groundFloor = LocationFactory.GetLocation(0) as GroundFloor;
            int i = 1;
            while (i <= eFloor.Length)
            {
                var newFloor = LocationFactory.GetLocation(i) as EFloor;
                eFloor[i - 1] = newFloor;
                i++;
            }

            var kVisitors = capacities.Get("Visitors");

            while (kVisitors < 0)
            {
                if (CurrentCapacity < MaxCapacity)
                {
                    groundFloor.Enter(new Visitor(random.Next(1, eFloor.Length), random.Next(0, 9)));
                }
                
            }
            lift = new Lift();
            lift.Operate();
        }


        EFloor[] eFloor = new EFloor[4];
        GroundFloor groundFloor;
        Lift lift;

    }
}