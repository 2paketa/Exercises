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
        private int number;
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
        public int MaxCapacity { get {return maxCapacity;}}

        public bool IsThereSpace { get {if (CurrentCapacity < maxCapacity) return true; else return false;} set{}}

        public EFloor()
        {
            // var capacities = Capacities.Instance();
            // this.maxCapacity = capacities.Get("Floor");
            WelcomeRoom = new List<Visitor>();
            maxCapacity = 99;
            int i = 0;
            while (i < 10)
            {
                offices[i] = new Office();
                i++;
            }
        }

        public void Enter(Visitor visitor)
        {
            Office officeToEnter = offices[visitor.OfficeNumber];

            if (officeToEnter.IsThereSpace)
            {
                officeToEnter.Enter(visitor);
            }
            else
            {
                WelcomeRoom.Add(visitor);
            }
             
        }
        
        public Visitor Exit()
        {
            Visitor visitor = offices[random.Next(offices.Length - 1)].Exit();
            return visitor;
        }
    }
}