using System;

namespace BuildingSimulator
{
    public class Visitor
    {
        public int FloorNumber { get; set; }
        public int OfficeNumber { get; set; }
        public int PriorityNumber { get; set; }

        static int priorityNumber;

        Random random = new Random();

        public Visitor(int floorNumber, int officeNumber)
        {
            this.FloorNumber = floorNumber;
            this.OfficeNumber = officeNumber;
            this.PriorityNumber = priorityNumber;
            priorityNumber++;
        }

    }
}