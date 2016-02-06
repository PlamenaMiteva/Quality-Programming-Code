namespace VehicleParkingSystemApp.Core
{
    using System;
    using Interfaces;
    using Models;

    public class CommandExecutor
    {
        public VehiclePark VehiclePark { get; set; }

        public string ExecuteCommand(ISystemCommand command)
        {
            if (command.Name != "SetupPark" && VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            // BUG In case of incorrect command, the engine should throw an InvalidOperationException
            switch (command.Name)
            {
                case "SetupPark":
                    VehiclePark = new VehiclePark(
                        int.Parse(command.Params["sectors"]),
                        int.Parse(command.Params["placesPerSector"]));
                    return "Vehicle OccupiedParkingPlaces created";
                case "Park":
                    switch (command.Params["type"])
                    {
                        case "car":
                            return
                                VehiclePark.InsertVehicle(
                                    new Car(command.Params["licensePlate"], command.Params["owner"], int.Parse(command.Params["hours"])),
                                        int.Parse(command.Params["sector"]),
                                        int.Parse(command.Params["place"]),
                                        DateTime.Parse(command.Params["time"], null, System.Globalization.DateTimeStyles.RoundtripKind));
                        case "motorbike":
                            return
                                VehiclePark.InsertVehicle(
                                    new Motorbike(
                                        command.Params["licensePlate"],
                                        command.Params["owner"],
                                        int.Parse(command.Params["hours"])),
                                        int.Parse(command.Params["sector"]),
                                        int.Parse(command.Params["place"]),
                                        DateTime.Parse(command.Params["time"], null, System.Globalization.DateTimeStyles.RoundtripKind));
                        case "truck":
                            return
                                VehiclePark.InsertVehicle(
                                    new Truck(
                                        command.Params["licensePlate"],
                                        command.Params["owner"],
                                        int.Parse(command.Params["hours"])),
                                        int.Parse(command.Params["sector"]),
                                        int.Parse(command.Params["place"]),
                                        DateTime.Parse(command.Params["time"], null, System.Globalization.DateTimeStyles.RoundtripKind));
                    }

                    break;
                case "Exit":
                    return VehiclePark.ExitVehicle(
                        command.Params["licensePlate"],
                        DateTime.Parse(command.Params["time"], null, System.Globalization.DateTimeStyles.RoundtripKind),
                        decimal.Parse(command.Params["paid"]));
                case "Status":
                    return VehiclePark.GetStatus();
                case "FindVehicle":
                    return VehiclePark.FindVehicle(command.Params["licensePlate"]);
                case "VehiclesByOwner":
                    return VehiclePark.FindVehiclesByOwner(command.Params["owner"]);
                default:
                    throw new InvalidOperationException("Invalid command.");
            }

            return string.Empty;
        }
    }
}
