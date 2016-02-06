namespace VehicleParkingSystemApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class VehiclePark : IVehiclePark
    {
        private Layout layout;
        private VehicleSystemData data;

        public VehiclePark(int sectors, int placesPerSector)
        {
            this.layout = new Layout(sectors, placesPerSector);
            this.data = new VehicleSystemData(sectors);
        }

        public string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime startTime)
        {
            if (sector > this.layout.SectorsCount)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.SectorPlacesNumber)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.OccupiedParkingPlaces.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.VehiclesByPlate.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", vehicle.LicensePlate);
            }

            this.data.CarsInPark[vehicle] = string.Format("({0},{1})", sector, place);
            this.data.OccupiedParkingPlaces[string.Format("({0},{1})", sector, place)] = vehicle;
            this.data.VehiclesByPlate[vehicle.LicensePlate] = vehicle;
            this.data.VehiclesParkingStartDate[vehicle] = startTime;
            this.data.CarsByOwner[vehicle.Owner].Add(vehicle);
            this.data.OccupiedPlacesBySector[sector - 1]++;
            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
        }

        public string ExitVehicle(string licensePlate, DateTime endDate, decimal paidMoney)
        {
            var vehicle = this.data.VehiclesByPlate.ContainsKey(licensePlate) ? this.data.VehiclesByPlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var startDate = this.data.VehiclesParkingStartDate[vehicle];
            int parkingHours = (int)Math.Round((endDate - startDate).TotalHours);
            var ticket = this.PrintTicket(paidMoney, vehicle, parkingHours);

            int sector = int.Parse(this.data.CarsInPark[vehicle].Split(
                new[]
            {
                "(", ",", ")"
            },
            StringSplitOptions.RemoveEmptyEntries)[0]);
            this.data.OccupiedParkingPlaces.Remove(this.data.CarsInPark[vehicle]);
            this.data.CarsInPark.Remove(vehicle);
            this.data.VehiclesByPlate.Remove(vehicle.LicensePlate);
            this.data.VehiclesParkingStartDate.Remove(vehicle);
            this.data.CarsByOwner.Remove(vehicle.Owner, vehicle);
            this.data.OccupiedPlacesBySector[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = this.data.OccupiedPlacesBySector.Select((seat, index) => string.Format(
                "Sector {0}: {1} / {2} ({3}% full)",
                index + 1,
                seat,
                this.layout.SectorPlacesNumber,
                Math.Round((double)seat / this.layout.SectorPlacesNumber * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.data.VehiclesByPlate.ContainsKey(licensePlate) ? this.data.VehiclesByPlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return this.FoundVehicles(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (this.data.OccupiedParkingPlaces.Values.All(v => v.Owner != owner))
            {
                return string.Format("No vehicles by {0}", owner);
            }

            var vehicles = this.data.OccupiedParkingPlaces.Values.Where(v => v.Owner == owner).ToList();

            return string.Join(Environment.NewLine, this.FoundVehicles(vehicles));
        }

        private string FoundVehicles(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(
                Environment.NewLine,
                vehicles.Select(vehicle => string.Format(
                    "{0}{1}Parked at {2}",
                    vehicle.ToString(),
                    Environment.NewLine,
                    this.data.CarsInPark[vehicle])));
        }

        private StringBuilder PrintTicket(decimal paidMoney, IVehicle vehicle, int parkingHours)
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
                .AppendFormat("at place {0}", this.data.CarsInPark[vehicle]).AppendLine()
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
