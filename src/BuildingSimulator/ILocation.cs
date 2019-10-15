using System;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public interface ILocation
    {
        List<Visitor> Visitors { get; set; }
        int CurrentCapacity { get; set; }
        int MaxCapacity { get; }
        int Number { get; }

        bool IsThereSpace { get; set; }
    }    
}