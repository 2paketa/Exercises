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
        }

        public List<Visitor> Visitors { get {return Visitors;} set {} }
        public int CurrentCapacity { get { return Visitors.Count;}}
        public int MaxCapacity { get {return maxCapacity;} }

        public bool IsThereSpace { get {if (CurrentCapacity < maxCapacity) return true; else return false;} set{}}

        public void Enter(Visitor visitor)
        {
            Visitors.Add(visitor);
        }
        
        public Visitor Exit()
        {
            Visitor visitor = Visitors.First();
            Visitors.Remove(visitor);
            return visitor;
        }

    }
}