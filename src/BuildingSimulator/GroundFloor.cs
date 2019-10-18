using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSimulator
{
    public class GroundFloor: ILocation
    {
        private int maxCapacity;
        public List<Visitor> WelcomeRoom { get; set; }
        public GroundFloor()
        {
            // var capacities = Capacities.Instance();
            // this.maxCapacity = capacities.Get("Groundfloor");
            maxCapacity = 50;
            WelcomeRoom = new List<Visitor>();
        }

        public int CurrentCapacity { get { return WelcomeRoom.Count;}}

        public bool IsThereSpace { get {if (CurrentCapacity < maxCapacity) return true; else return false;} set{}}

        public void Enter(Visitor visitor)
        {
            if (IsThereSpace)
            {
                
            }
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