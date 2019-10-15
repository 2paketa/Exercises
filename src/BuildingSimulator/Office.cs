using System;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Office
    {
        List<Visitor> Visitor { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
    }
}