using System;

namespace BuildingSimulator
{
    public class Visitor
    {
        public int FloorNumber { get; set; }
        public int OfficeNumber { get; set; }
        public int? PriorityNumber { get; set; }
        public bool Served { get; set; }

        Random random = new Random();

        public Visitor(int floorNumber, int officeNumber)
        {
            this.FloorNumber = floorNumber;
            this.OfficeNumber = officeNumber;
        }

        public override string ToString()
        {
            return $"{PriorityNumber} Floor: {FloorNumber}, Office: {OfficeNumber}";
        }
    }
}