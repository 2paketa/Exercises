namespace BuildingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacities = Capacities.Instance();
            Building building = new Building();
            building.Main();
        }
    }
}
