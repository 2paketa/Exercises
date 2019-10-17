using System;

namespace BuildingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var capacities = Capacities.Instance();
            //Building building = new Building(capacities.Get("Building"));
            //building.Main();

            Random random = new Random();
            Lift lift = new Lift();
            EFloor[] eFloor = new EFloor[4];
            int o = 1;
            while (o < eFloor.Length)
            {
                var newFloor = LocationFactory.GetLocation(o) as EFloor;
                eFloor[o - 1] = newFloor;
                o++;
            }
            var gFloor = LocationFactory.GetLocation(0) as GroundFloor;
            for (int i = 0; i < 5; i++)
                gFloor.Enter(new Visitor(random.Next(1, 4), random.Next(0, 9)));

            lift.Operate();

        }
    }
}
