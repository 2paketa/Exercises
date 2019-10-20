using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class EFloor: ILocation
    {
        public List<Visitor> WelcomeRoom { get; set; }
        public Office[] offices = new Office[10];
        private int maxCapacity;
        Random random = new Random();
        public int CurrentCapacity {
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

        public bool IsThereSpace { get {if (CurrentCapacity < maxCapacity) return true; else return false;} set{}}

        private EFloor()
        {
            var capacities = Capacities.Instance();
            this.maxCapacity = capacities.Get("Floor");
            WelcomeRoom = new List<Visitor>();
            int i = 0;
            while (i < 10)
            {
                offices[i] = new Office();
                i++;
            }
        }

        public static EFloor Get()
        {
            return new EFloor();
        }

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
            if (WelcomeRoom.Count > 0 &&  welcomeRoomToOffice != null)
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