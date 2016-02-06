namespace VehicleParkingSystemTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkingSystemApp.Core;
    using VehicleParkingSystemApp.Interfaces;
    using VehicleParkingSystemApp.Models;

    [TestClass]
    public class GetStatusTests
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
        public void GetStatus_GetStatusWithValidData_ShouldReturnStatusCorrectly()
        {
            this.parkingSystem.InsertVehicle(new Car("CA1234ZX", "Owner", 2), 1, 1, new DateTime(2016, 1, 1, 12, 30, 00));
            this.parkingSystem.InsertVehicle(new Truck("CB1234ZU", "Ivan", 2), 1, 2, new DateTime(2016, 1, 1, 12, 30, 00));
            this.parkingSystem.InsertVehicle(new Motorbike("CV1234ZY", "Petar", 2), 1, 3, new DateTime(2016, 1, 1, 12, 30, 00));
            this.parkingSystem.InsertVehicle(new Truck("CC1234ZT", "Marian", 12), 2, 2, new DateTime(2016, 1, 1, 12, 30, 00));
            var firstSectorOccupiedPlaces = 3;
            var secondSectorOccupiedPlaces = 1;
            var expected = new StringBuilder();
            expected.AppendFormat(
                "Sector 1: {0} / {1} ({2}% full)", 
                firstSectorOccupiedPlaces, 
                placesPerSector, 
                Math.Round((double)firstSectorOccupiedPlaces/placesPerSector*100))
                .AppendLine();
            expected.AppendFormat(
                "Sector 2: {0} / {1} ({2}% full)", 
                secondSectorOccupiedPlaces,
                placesPerSector, 
                Math.Round((double)secondSectorOccupiedPlaces / placesPerSector * 100));
            
            var result = this.parkingSystem.GetStatus();

            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void GetStatus_GetStatusEmptyPark_ShouldReturnStatusCorrectly()
        {
            var firstSectorOccupiedPlaces = 0;
            var secondSectorOccupiedPlaces = 0;
            var expected = new StringBuilder();
            expected.AppendFormat(
                "Sector 1: {0} / {1} ({2}% full)",
                firstSectorOccupiedPlaces,
                placesPerSector,
                Math.Round((double)firstSectorOccupiedPlaces / placesPerSector * 100))
                .AppendLine();
            expected.AppendFormat(
                "Sector 2: {0} / {1} ({2}% full)",
                secondSectorOccupiedPlaces,
                placesPerSector,
                Math.Round((double)secondSectorOccupiedPlaces / placesPerSector * 100));

            var result = this.parkingSystem.GetStatus();

            Assert.AreEqual(expected.ToString(), result);
        }
    }
}
