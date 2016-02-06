namespace VehicleParkingSystemTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehicleParkingSystemApp.Core;
    using VehicleParkingSystemApp.Interfaces;
    using VehicleParkingSystemApp.Models;

    [TestClass]
    public class ExitVehicleTests
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
        public void ExitVehicle_ExitVehicleWithValidData_ShouldExitAndReturnSuccessMessage()
        {
            var licensePlate = "CA2345RE";
            var vehicle = new Car(licensePlate, "Car Owner", 2);
            var sector = 1;
            var place = 3;
            var startDate = new DateTime(2016, 1, 3, 10, 30, 00);
            var endDate = new DateTime(2016, 1, 3, 12, 30, 00);
            this.parkingSystem.InsertVehicle(vehicle, sector, place, startDate);

            var expected = this.PrintTicket(4.0M, vehicle, 2, sector, place);
            var result = this.parkingSystem.ExitVehicle(licensePlate, endDate, 4.0M);

            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void ExitVehicle_ExitVehicleWithValidOverRatedData_ShouldExitAndReturnSuccessMessage()
        {
            var licensePlate = "CA2345RE";
            var vehicle = new Car(licensePlate, "Car Owner", 2);
            var sector = 1;
            var place = 3;
            var startDate = new DateTime(2016, 1, 3, 10, 30, 00);
            var endDate = new DateTime(2016, 1, 3, 13, 30, 00);
            this.parkingSystem.InsertVehicle(vehicle, sector, place, startDate);

            var expected = this.PrintTicket(30M, vehicle, 3, sector, place);
            var result = this.parkingSystem.ExitVehicle(licensePlate, endDate, 30M);

            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void ExitVehicle_ExitNonExistingVehicleWith_ShouldReturnErrorMessage()
        {
            var licensePlate = "CA2345RE";
            var vehicle = new Car(licensePlate, "Car Owner", 2);
            var sector = 1;
            var place = 3;
            var startDate = new DateTime(2016, 1, 3, 10, 30, 00);
            var endDate = new DateTime(2016, 1, 3, 13, 30, 00);
            this.parkingSystem.InsertVehicle(vehicle, sector, place, startDate);
            var newLicensePlate = "CB2345RE";

            var errorMessage = string.Format("There is no vehicle with license plate {0} in the park", newLicensePlate);
            var result = this.parkingSystem.ExitVehicle(newLicensePlate, endDate, 30M);

            Assert.AreEqual(errorMessage, result);
        }

        private StringBuilder PrintTicket(decimal paidMoney, IVehicle vehicle, int parkingHours, int sector, int place)
        {
            var totalDueSum = (vehicle.ReservedHours * vehicle.RegularRate) +
                (parkingHours > vehicle.ReservedHours ?
                (parkingHours - vehicle.ReservedHours) *
                vehicle.OvertimeRate : 0);
            var change = paidMoney -
                         ((vehicle.ReservedHours * vehicle.RegularRate) +
                          (parkingHours > vehicle.ReservedHours
                              ? (parkingHours - vehicle.ReservedHours) * vehicle.OvertimeRate
                              : 0));
            var overtimeRtae = parkingHours > vehicle.ReservedHours
                ? (parkingHours - vehicle.ReservedHours) * vehicle.OvertimeRate
                : 0;

            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString()).AppendLine()
                .AppendFormat("at place ({0},{1})", sector, place).AppendLine()
                .AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate).AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", overtimeRtae).AppendLine()
                .AppendLine(
                new string('-', 20))
                .AppendFormat("Total: ${0:F2}", totalDueSum).AppendLine()
                .AppendFormat("Paid: ${0:F2}", paidMoney).AppendLine().AppendFormat(
                "Change: ${0:F2}", change).AppendLine().Append(new string('*', 20));
            return ticket;
        }
    }
}
