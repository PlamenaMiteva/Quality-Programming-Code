namespace VehicleParkingSystemTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkingSystemApp.Core;
    using VehicleParkingSystemApp.Interfaces;
    using VehicleParkingSystemApp.Models;

    [TestClass]
    public class InsertVehicleTests
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
        public void InsertVehicle_InsertNewVehicleWithValidData_ShouldInsertAndReturnSuccessMessage()
        {
            var vehicle = new Car("CA2345RE", "Car Owner", 2);
            var sector = 1;
            var place = 3;
            var startDate = new DateTime(2016, 1, 3, 10, 30, 00);

            var successMessage = string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
            var result = this.parkingSystem.InsertVehicle(vehicle, sector, place, startDate);

            Assert.AreEqual(successMessage, result);
        }

        [TestMethod]
        public void InsertVehicle_InsertNewVehicleWithInvalidSector_ShouldReturnErrorMessage()
        {
            var vehicle = new Car("CA2345RE", "Car Owner", 2);
            var sector = 13;
            var place = 3;
            var startDate = new DateTime(2016, 1, 3, 10, 30, 00);

            var errorMessage = string.Format("There is no sector {0} in the park", sector);
            var result = this.parkingSystem.InsertVehicle(vehicle, sector, place, startDate);

            Assert.AreEqual(errorMessage, result);
        }

        [TestMethod]
        public void InsertVehicle_InsertNewVehicleWithInvalidPlace_ShouldReturnErrorMessage()
        {
            var vehicle = new Car("CA2345RE", "Car Owner", 2);
            var sector = 1;
            var place = 36;
            var startDate = new DateTime(2016, 1, 3, 10, 30, 00);

            var errorMessage = string.Format("There is no place {0} in sector {1}", place, sector);
            var result = this.parkingSystem.InsertVehicle(vehicle, sector, place, startDate);

            Assert.AreEqual(errorMessage, result);
        }

        [TestMethod]
        public void InsertVehicle_InsertNewVehicleOnOccupiedPlace_ShouldReturnErrorMessage()
        {
            var vehicle1 = new Car("CA2345RE", "Car Owner 1", 2);
            var vehicle2 = new Car("CA4790FY", "Car Owner 2", 3);
            var sector = 1;
            var place = 3;
            var startDate = new DateTime(2016, 1, 3, 10, 30, 00);
            this.parkingSystem.InsertVehicle(vehicle1, sector, place, startDate);

            var errorMessage = string.Format("The place ({0},{1}) is occupied", sector, place);
            var result = this.parkingSystem.InsertVehicle(vehicle2, sector, place, startDate);

            Assert.AreEqual(errorMessage, result);
        }
    }
}
