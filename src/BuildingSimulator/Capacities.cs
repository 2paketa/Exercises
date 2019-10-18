using System;
using System.Collections.Generic;
using BuildingCommon;

namespace BuildingSimulator
{
    public class Capacities
    {
        private static Capacities instance = null;
        static Dictionary<string,int> dict;
        static int Building;
        static int GroundFloor;
        static int Office;
        static int Floor;
        static int Lift;
        static int Cycles;
        static int Visitors;

        private Capacities(){
            Set();
            dict = new Dictionary<string, int>();
            dict.Add("Building", Building);
            dict.Add("Groundfloor",GroundFloor);
            dict.Add("Floor", Floor);
            dict.Add("Office", Office);
            dict.Add("Lift", Lift);
            dict.Add("Cycles", Cycles);
            dict.Add("Visitors", Visitors);
        }

        public static Capacities Instance()
        {               
            if (instance == null)
              {
                  instance = new Capacities();
              }
            return instance;
        }

        public int Get(string location) 
        {
            return dict[location];
        }

        public static void Set()
        {
            Console.WriteLine("Enter building capacity: ");
            Building = BuildingCommon.BuildingCommon.UserInput("Building capacity should be more than 33", (x) => x < 30);

            Console.WriteLine("Enter Groundfloor capacity: ");
            GroundFloor = BuildingCommon.BuildingCommon.UserInput(Building / 2, "Groundfloor capacity should be between 1 and ");
            
            Console.WriteLine("Enter floor capacity: ");
            Floor = BuildingCommon.BuildingCommon.UserInput(Building / 3, "floor capacity should be between 1 and ");

            Console.WriteLine("Enter office capacity: ");
            Office = BuildingCommon.BuildingCommon.UserInput("Office capacity should be less than " + Floor + ": ", (x) => x >= Floor);

            Console.WriteLine("Enter lift capacity: ");
            Lift = BuildingCommon.BuildingCommon.UserInput("lift capacity should be more than " + Office + ": ", (x) => x < Office);

            Console.WriteLine("Enter lift operating cycles: ");
            Cycles = Console.ReadLine().GetValidInt();

            Console.WriteLine("Enter number of visitors: ");
            Visitors = Console.ReadLine().GetValidInt();
        }
    }
}
