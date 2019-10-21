namespace BuildingSimulator
{
    public class LocationSingletory
    {
        static GroundFloor gFloor;
        static EFloor[] eFloors = new EFloor[4];
        public static ILocation GetLocation(int floorNumber)
        {
            switch (floorNumber)
            {
                case 0:
                    gFloor = GroundFloor.Get();
                    return gFloor;
                default:
                    return EFloor.Get(floorNumber);
            }
        }

    }
}