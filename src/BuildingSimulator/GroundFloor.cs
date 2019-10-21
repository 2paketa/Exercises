using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSimulator
{
    public class GroundFloor : ILocation
    {
        private int maxCapacity;
        private static GroundFloor instance;
        private int GetPriorityNumber;
        public List<Visitor> WelcomeRoom { get; set; }
        Queue<Visitor> waitingRoom;

        public static GroundFloor Get()
        {
            if (instance == null)
            {
                instance = new GroundFloor();
            }
            return instance;
        }

        private GroundFloor()
        {
            this.maxCapacity = Capacities.Get("Groundfloor");
            WelcomeRoom = new List<Visitor>();
            waitingRoom = new Queue<Visitor>();
        }

        public int CurrentCapacity { get { return WelcomeRoom.Count; } }

        public bool IsThereSpace { get { if (CurrentCapacity < maxCapacity) return true; else return false; } set { } }

        public void Enter(Visitor visitor)
        {
            if (visitor.Served)
            {
                Console.WriteLine($"I can't believe I finished, priority number {visitor.PriorityNumber}");
            }
            else if (IsThereSpace == false)
            {
                waitingRoom.Enqueue(visitor);
            }
            else if (visitor.PriorityNumber == null)
            {
                visitor.PriorityNumber = GetPriorityNumber;
                GetPriorityNumber++;
                WelcomeRoom.Add(visitor);
            }

        }

        public Visitor Exit()
        {
            Visitor visitor = WelcomeRoom.FirstOrDefault();
            WelcomeRoom.Remove(visitor);
            if (waitingRoom.Count > 0)
            {
                Enter(waitingRoom.Dequeue());
            }
            return visitor;
        }

    }
}