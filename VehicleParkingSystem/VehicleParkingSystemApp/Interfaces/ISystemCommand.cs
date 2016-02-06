namespace VehicleParkingSystemApp.Interfaces
{
    using System.Collections.Generic;

    public interface ISystemCommand
    {
        string Name { get; }
        
        IDictionary<string, string> Params { get; }
    }
}
