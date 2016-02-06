namespace VehicleParkingSystemApp.Core
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Wintellect.PowerCollections;

    public class VehicleSystemData
    {
        public VehicleSystemData(int numberOfSectors)
        {
            this.CarsInPark = new Dictionary<IVehicle, string>();
            this.OccupiedParkingPlaces = new Dictionary<string, IVehicle>();
            this.VehiclesByPlate = new Dictionary<string, IVehicle>();
            this.VehiclesParkingStartDate = new Dictionary<IVehicle, DateTime>();
            this.CarsByOwner = new MultiDictionary<string, IVehicle>(false);
            this.OccupiedPlacesBySector = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> CarsInPark { get; private set; }

        public Dictionary<string, IVehicle> OccupiedParkingPlaces { get; private set; }

        public Dictionary<string, IVehicle> VehiclesByPlate { get; private set; }

        public Dictionary<IVehicle, DateTime> VehiclesParkingStartDate { get; private set; }

        public MultiDictionary<string, IVehicle> CarsByOwner { get; private set; }

        public int[] OccupiedPlacesBySector { get; private set; }
    }
}
