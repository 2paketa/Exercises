using System;

namespace BuildingSimulator
{
    public class LocationFactory
    {
        static GroundFloor gFloor;
        static EFloor[] eFloors = new EFloor[4];
        public static ILocation GetLocation(int floorNumber)
        {
            switch (floorNumber)
            {
                case 0:
                 if (gFloor == null)
                 {
                     gFloor = new GroundFloor();
                 }
                 return gFloor;
                case var d when floorNumber > eFloors.Length:
                 return null;
                default:
                if (eFloors[floorNumber - 1] == null)
                {
                    for (int i = 0; i < eFloors.Length; i++)
                    {
                        eFloors[i] = new EFloor();
                    }
                }
                 return eFloors[floorNumber - 1];
            }
        }

    }
}