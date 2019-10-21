using System.Collections.Generic;

namespace BuildingSimulator
{
    public interface ILocation
    {
        List<Visitor> WelcomeRoom { get; set; }
        int CurrentCapacity { get; }
        bool IsThereSpace { get; set; }

        Visitor Exit();
        void Enter(Visitor visitor);
    }
}