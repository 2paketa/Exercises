using System;
using System.Collections.Generic;

namespace BuildingSimulator
{
    interface ILocation
    {
        public List<Visitor> Visitor { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
    }    
}