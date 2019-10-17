using System;
using System.Collections.Generic;
using System.Linq; 

namespace BuildingSimulator
{
    public class Office
    {
        Queue<Visitor> Visitors { get; set; }
        Random random;
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }

        public void Enter(Visitor visitor)
        {
           Visitors.Enqueue(visitor);
        }

        public Visitor getServedVisitor()
        {
           return Visitors.Dequeue();
        }
    }
}