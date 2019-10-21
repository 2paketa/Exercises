namespace BuildingSimulator
{
    public class LocationSingletory
    {
        public static ILocation GetLocation(int floorNumber)
        {
            switch (floorNumber)
            {
                case 0:
                    return GroundFloor.Get();
                default:
                    return EFloor.Get(floorNumber);
            }
        }

    }
}