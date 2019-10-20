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
                    if (gFloor == null)
                    {
                        gFloor = GroundFloor.Get();
                    }
                    return gFloor;
                case var d when floorNumber > eFloors.Length || floorNumber < 0:
                    return null;
                default:
                    if (eFloors[floorNumber - 1] == null)
                    {
                        eFloors[floorNumber - 1] = EFloor.Get();
                    }
                    return eFloors[floorNumber - 1];
            }
        }

    }
}