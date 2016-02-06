namespace VehicleParkingSystemTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkingSystemApp.Core;
    using VehicleParkingSystemApp.Interfaces;
    using VehicleParkingSystemApp.Models;

    [TestClass]
    public class FindVehicleByOwnerTests
    {
        private const int numberOfSectors = 2;
        private const int placesPerSector = 3;
        private IVehiclePark parkingSystem;


        [TestInitialize]
        public void TestInit()
        {
            this.parkingSystem = new VehiclePark(numberOfSectors, placesPerSector);
        }

        [TestMethod]
        public void FindVehiclesByOwner_FindExistingVehicle_ShouldReturnVehicle()
        {
            var car = new Car("CA1234ZX", "Owner", 2);
            var carSector = 1;
            var carPlace = 1;
            var truck = new Truck("CC1234ZT", "Owner", 12);
            var truckSector = 2;
            var truckPlace = 2;
            var date = new DateTime(2016, 1, 1, 12, 30, 00);
            this.parkingSystem.InsertVehicle(car, carSector, carPlace, date);
            this.parkingSystem.InsertVehicle(new Truck("CB1234ZU", "Ivan", 2), 1, 2, date);
            this.parkingSystem.InsertVehicle(new Motorbike("CV1234ZY", "Petar", 2), 1, 3, date);
            this.parkingSystem.InsertVehicle(truck, truckSector, truckPlace, date);
            var expected = new StringBuilder();
            expected.AppendLine(
                string.Format(
                "{0}{1}Parked at ({2},{3})",
                car.ToString(),
                Environment.NewLine,
                carSector,
                carPlace));
            expected.AppendLine(
                string.Format(
                "{0}{1}Parked at ({2},{3})",
                truck.ToString(),
                Environment.NewLine,
                truckSector,
                truckPlace));

            var result = this.parkingSystem.FindVehiclesByOwner("Owner");

            Assert.AreEqual(expected.ToString().Trim(), result);
        }

        [TestMethod]
        public void FindVehiclesByOwner_FindOwnerWithoutVehicle_ShouldReturnErrorMessage()
        {
            var car = new Car("CA1234ZX", "Owner", 2);
            var carSector = 1;
            var carPlace = 1;
            var truck = new Truck("CC1234ZT", "Owner", 12);
            var truckSector = 2;
            var truckPlace = 2;
            var date = new DateTime(2016, 1, 1, 12, 30, 00);
            this.parkingSystem.InsertVehicle(car, carSector, carPlace, date);
            this.parkingSystem.InsertVehicle(truck, truckSector, truckPlace, date);
            var owner = "Petar";

            var expected = string.Format("No vehicles by {0}", owner);
            var result = this.parkingSystem.FindVehiclesByOwner(owner);

            Assert.AreEqual(expected, result);
        }
    }
}
