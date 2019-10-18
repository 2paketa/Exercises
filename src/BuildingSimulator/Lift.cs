using System;
using System.Linq;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Lift
    {
        public List<Visitor> Visitors { get; set; }
        ILocation currentFloor { get { return LocationFactory.GetLocation(floorNumber); } }
        private int maxCapacity;
        public bool GoingDown 
        { get 
            { if (floorNumber != 0)
                GoingDown = true;
                else GoingDown = false; 
              return GoingDown; 
            } 
            set {} 
        }
        public int CurrentCapacity { get {return Visitors.Count;} }
        private int cycles;
        public int MaxCapacity { get {return maxCapacity;} }
        public int floorNumber;
        public bool IsThereSpace { get {if (CurrentCapacity < maxCapacity) return true; else return false;}}
        public Lift()
        {
            //var capacities = Capacities.Instance();
            Visitors = new List<Visitor>();
            // maxCapacity = capacities.Get("Lift");
            // cycles = capacities.Get("Cycles");
            maxCapacity = 100;
            cycles = 10;
        }

        public void Operate()
        {
            while (cycles > 0)
            {
                moveUp();
                moveDown();
                cycles--;
            }
        }

        public void Enter(Visitor visitor)
        {
            Visitors.Add(visitor);
        }
        
        public Visitor Exit()
        {
            Visitor visitor = Visitors.TakeWhile(x => x.FloorNumber == floorNumber).FirstOrDefault();
            Visitors.Remove(visitor);
            return visitor;
        }

        private void moveUp()
        {
            
            while (currentFloor != null)
            {
                if (currentFloor is GroundFloor) 
                {
                    while (IsThereSpace && currentFloor.CurrentCapacity > 0)
                    {
                        Enter(currentFloor.Exit());
                    }
                }
                else
                {
                    while (currentFloor.IsThereSpace && CurrentCapacity != 0)
                    {
                        Visitor visitor = Exit();
                        if (visitor == null)
                        {
                            break;
                        }
                        else
                        {
                            currentFloor.Enter(visitor);
                        }
                        
                    }
                }   
             floorNumber++;
            }
            floorNumber--;
        }

        private void moveDown()
        {
            while (floorNumber >= 0)
            {
                if (currentFloor is GroundFloor)
                {
                    while (IsThereSpace && currentFloor.CurrentCapacity > 0)
                    {
                        Enter(currentFloor.Exit());
                    }
                }
                else
                {
                    while (currentFloor.IsThereSpace && CurrentCapacity != 0)
                    {
                        Visitor visitor = Exit();
                        if (visitor == null)
                        {
                            break;
                        }
                        else
                        {
                            currentFloor.Enter(visitor);
                        }

                    }
                }
                floorNumber--;
            }
            floorNumber++;
        }
    }
}