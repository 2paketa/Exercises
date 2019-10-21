using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSimulator
{
    public class EFloor : ILocation
    {
        public List<Visitor> WelcomeRoom { get; set; }
        public Office[] offices = new Office[10];
        private int maxCapacity;
        Random random = new Random();
        static EFloor[] eFloors;
        public int CurrentCapacity
        {
            get
            {
                return WelcomeRoom.Count + officesCurrentCapacity;
            }
        }
        public int officesCurrentCapacity
        {
            get
            {
                int officesCurrentCapacity = 0;
                for (int i = 0; i < offices.Length; i++)
                    officesCurrentCapacity += offices[i].CurrentCapacity;
                return officesCurrentCapacity;
            }
        }

        public bool IsThereSpace { get { if (CurrentCapacity < maxCapacity) return true; else return false; } set { } }

        private EFloor()
        {
            this.maxCapacity = Capacities.Get("Floor");
            WelcomeRoom = new List<Visitor>();
            int i = 0;
            while (i < 10)
            {
                offices[i] = new Office();
                i++;
            }
        }

        public static EFloor Get(int floorNumber)
        {
            eFloors = new EFloor[Capacities.Get("NumberOfFloors")];
            if  (floorNumber > eFloors.Length || floorNumber < 0) { return null; }
            if (eFloors[floorNumber - 1] == null)
            {
                eFloors[floorNumber - 1] = new EFloor();
            }
            return eFloors[floorNumber - 1];
        }

        //private int[] generateOfficesCapacity(int nOffice)
        //{
        //    random = new Random();
        //    var getCapacities = new int[10];
        //    while (getCapacities.Min() == 0)
        //    {
        //        int maxCap = nOffice;
        //        for (int i = 0; i < getCapacities.Length; i++)
        //        {
        //            getCapacities[i] = random.Next(maxCap);
        //            maxCap -= getCapacities[i];
        //        }
        //    }
        //    return getCapacities;
        //}

        public void Enter(Visitor visitor)
        {
            Office officeToEnter = offices[visitor.OfficeNumber];

            if (officeToEnter.IsThereSpace)
            {
                officeToEnter.Enter(visitor);
                //Console.WriteLine($"Entering office {officeToEnter}");
            }
            else
            {
                WelcomeRoom.Add(visitor);
            }

        }

        private void welcomeRoomtoOfficeNumber(int officeNumber)
        {
            var welcomeRoomToOffice = WelcomeRoom.Where(x => x.OfficeNumber == officeNumber);
            if (WelcomeRoom.Count > 0 && welcomeRoomToOffice != null)
            {
                Visitor visitor = WelcomeRoom.FirstOrDefault();
                WelcomeRoom.Remove(visitor);
                offices[officeNumber].Enter(visitor);
            }
        }

        public Visitor Exit()
        {
            var currentVisitors = offices.Where(x => x.CurrentCapacity > 0).ToList();
            if (currentVisitors.Count == 0)
            {
                return null;
            }
            Visitor visitor = currentVisitors.ElementAt(random.Next(currentVisitors.Count)).Exit();
            welcomeRoomtoOfficeNumber(visitor.OfficeNumber);
            return visitor;
        }
    }
}