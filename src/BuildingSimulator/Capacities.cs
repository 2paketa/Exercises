using BuildingCommon;
using System;
using System.Collections.Generic;

namespace BuildingSimulator
{
    public class Capacities
    {
        static Capacities instance = null;
        static Dictionary<string, int> dict;
        static int Building;
        static int GroundFloor;
        static int Office;
        static int Floor;
        static int Lift;
        static int Cycles;
        static int Visitors;
        static int numberOfFloors;

        private Capacities()
        {
            Set();
            dict = new Dictionary<string, int>
            {
                { "Building", Building },
                { "Groundfloor", GroundFloor },
                { "Floor", Floor },
                { "Office", Office },
                { "Lift", Lift },
                { "Cycles", Cycles },
                { "Visitors", Visitors },
                { "NumberOfFloors", numberOfFloors }
            };
        }

        public static Capacities Instance()
        {
            if (instance == null)
            {
                instance = new Capacities();
            }
            return instance;
        }

        public static int Get(string location)
        {
            return dict[location];
        }

        private static void Set()
        {
            Console.WriteLine("Enter building capacity: ");
            Building = BuildingCommon.BuildingCommon.UserInput("Building capacity should be more than 33", (x) => x < 30);

            Console.WriteLine("Enter Groundfloor capacity: ");
            GroundFloor = BuildingCommon.BuildingCommon.UserInput(Building / 2, "Groundfloor capacity should be between 1 and ");

            Console.WriteLine("Enter number of Floors");
            numberOfFloors = Console.ReadLine().GetValidInt();

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
