using System;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Building
    {

        public int CurrentCapacity
        {
            get
            {
                int eFloorsCurrentCapacity = 0;
                for (int i = 0; i < eFloor.Length; i++)
                    eFloorsCurrentCapacity += eFloor[i].CurrentCapacity;
                return groundFloor.CurrentCapacity + lift.CurrentCapacity + eFloorsCurrentCapacity;
            }
            set { }
        }
        readonly int MaxCapacity;
        public bool IsThereSpace { get { if (CurrentCapacity < MaxCapacity) return true; else return false; } set { } }
        Capacities capacities;
        EFloor[] eFloor = new EFloor[4];
        GroundFloor groundFloor;
        Lift lift;
        public Building()
        {
            capacities = Capacities.Instance();
            this.MaxCapacity = capacities.Get("Building");
        }

        public void Main()
        {
            lift = new Lift();
            groundFloor = LocationSingletory.GetLocation(0) as GroundFloor;
            int i = 1;
            while (i <= eFloor.Length)
            {
                var newFloor = LocationSingletory.GetLocation(i) as EFloor;
                eFloor[i - 1] = newFloor;
                i++;
            }
            getVisitors();
            lift.Operate();
            printStats();
        }

        public void getVisitors()
        {
            Random random = new Random();
            var kVisitors = capacities.Get("Visitors");
            while (kVisitors > 0)
            {
                Visitor visitor = new Visitor(random.Next(1, (eFloor.Length + 1)), random.Next(0, 9));
                if (IsThereSpace)
                {
                    groundFloor.Enter(visitor);
                }
                else
                {
                    Console.WriteLine("Please come again tomorrow");
                }
                kVisitors--;
            }
            Console.WriteLine($"Visitors waiting to enter lift: {groundFloor.CurrentCapacity}");
        }


        public void printStats()
        {
            Console.WriteLine("Visitors in the building = " + CurrentCapacity + ", Visitors in Groundfloor = " + groundFloor.CurrentCapacity + ", Visitors in the Lift = " + lift.CurrentCapacity);
            //Console.WriteLine("Visitors served = " + VisitorsServed + ", Remaining visitors = " + buildingVisitors.Count);
            for (var i = 0; i < eFloor.Length; i++)
            {
                Console.WriteLine($"Visitors in floor number {i + 1} = {eFloor[i].CurrentCapacity}");
                Console.WriteLine($"Visitors in floor Welcome room = {eFloor[i].WelcomeRoom.Count}");
            }
        }
    }
}