using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSimulator
{
    public class GroundFloor: ILocation
    {
        private int maxCapacity;

        public GroundFloor()
        {
            // var capacities = Capacities.Instance();
            // this.maxCapacity = capacities.Get("Groundfloor");
            maxCapacity = 50;
            WelcomeRoom = new List<Visitor>();
        }

        public List<Visitor> WelcomeRoom { get; set; }
        public int CurrentCapacity { get { return WelcomeRoom.Count;}}
        public int MaxCapacity { get {return maxCapacity;} }

        public bool IsThereSpace { get {if (CurrentCapacity < maxCapacity) return true; else return false;} set{}}

        public void Enter(Visitor visitor)
        {
            WelcomeRoom.Add(visitor);
        }
        
        public Visitor Exit()
        {
            Visitor visitor = WelcomeRoom.FirstOrDefault();
            WelcomeRoom.Remove(visitor);
            return visitor;
        }

    }
}