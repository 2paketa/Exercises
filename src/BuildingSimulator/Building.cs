using System;

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
        EFloor[] eFloor;
        GroundFloor groundFloor;
        Lift lift;
        public Building()
        {
            this.MaxCapacity = Capacities.Get("Building");
        }

        public void Main()
        {
            eFloor = new EFloor[Capacities.Get("NumberOfFloors")];
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

        private void getVisitors()
        {
            Random random = new Random();
            var kVisitors = Capacities.Get("Visitors");
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
        }


        private void printStats()
        {
            Console.WriteLine("Visitors in the building = " + CurrentCapacity + ", Visitors in Groundfloor = " + groundFloor.CurrentCapacity + ", Visitors in the Lift = " + lift.CurrentCapacity);
            //Console.WriteLine("Visitors served = " + VisitorsServed + ", Remaining visitors = " + buildingVisitors.Count);
            for (var i = 0; i < eFloor.Length; i++)
            {
                Console.WriteLine($"Visitors in floor number {i + 1} = {eFloor[i].CurrentCapacity}");
                Console.WriteLine($"Visitors in floor number {i + 1} offices = {eFloor[i].officesCurrentCapacity}");
                Console.WriteLine($"Visitors in floor Welcome room = {eFloor[i].WelcomeRoom.Count}");
            }
        }
    }
}