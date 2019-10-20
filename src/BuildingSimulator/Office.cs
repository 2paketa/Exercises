using System;
using System.Collections.Generic;
using System.Linq; 

namespace BuildingSimulator
{
    public class Office
    {
        public Office()
        {
            var capacities = Capacities.Instance();
            Visitors = new Queue<Visitor>();
            this.MaxCapacity = capacities.Get("Office");
        }

        Queue<Visitor> Visitors { get; set; }
        public int CurrentCapacity { get { return Visitors.Count; } }
        public int MaxCapacity { get; set; }
        public bool IsThereSpace { get { if (CurrentCapacity < MaxCapacity) return true; else return false; } }

        public void Enter(Visitor visitor)
        {
           Visitors.Enqueue(visitor);
        }

        public Visitor Exit()
        {
           Visitor visitor = Visitors.Dequeue();
           visitor.Served = true;
           return visitor;
        }
    }
}