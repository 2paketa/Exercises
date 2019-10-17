using System;
using System.Collections.Generic;
using System.Linq; 

namespace BuildingSimulator
{
    public class Office
    {
        public Office()
        {
            Visitors = new Queue<Visitor>();
        }

        Queue<Visitor> Visitors { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsThereSpace { get { if (CurrentCapacity < MaxCapacity) return true; else return false; } }

        public void Enter(Visitor visitor)
        {
           Visitors.Enqueue(visitor);
        }

        public Visitor Exit()
        {
           return Visitors.Dequeue();
        }
    }
}