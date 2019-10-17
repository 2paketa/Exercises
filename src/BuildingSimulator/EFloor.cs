using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class EFloor: ILocation
    {
        public List<Visitor> Visitors { get {return Visitors;} set {Visitors.OrderBy(x => x.PriorityNumber);} }
        public Office[] offices;
        private int maxCapacity;
        private int number;

        public int CurrentCapacity { get; }
        public int MaxCapacity { get {return maxCapacity;}}

        public bool IsThereSpace { get {if (CurrentCapacity < maxCapacity) return true; else return false;} set{}}

        public EFloor()
        {
            // var capacities = Capacities.Instance();
            // this.maxCapacity = capacities.Get("Floor");
            maxCapacity = 250;
            int i = 0;
            while (i < 10)
            {
                offices[i] = new Office();
            }
        }

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