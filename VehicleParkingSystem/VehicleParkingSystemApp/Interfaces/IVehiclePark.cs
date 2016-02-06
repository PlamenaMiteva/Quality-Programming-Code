namespace VehicleParkingSystemApp.Interfaces
{
    using System;

    /// <summary>
    /// Contains methods for working with a vehicle parking system.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Registers a vehicle in the parking system.
        /// </summary>
        /// <param name="vehicle">The vehicle to register</param>
        /// <param name="sector">The parking system sector where the vehicle will be parked.</param>
        /// <param name="place">The parking system sector place where the vehicle will be parked.</param>
        /// <param name="startTime">Indicates start time of the vehicle's stay on the parking system.</param>
        /// <returns>Returns success message in case vehicle has been successfully registered and 
        /// an error message otherwise.</returns>
        string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime startTime);

        /// <summary>
        /// Registers a vehicle leaving in the parking system.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="endTime">Indicates end time of the vehicle's stay on the parking system.</param>
        /// <param name="paidMoney">Fee to be paid for the parking stay.</param>
        /// <returns>Returns info on the vehicle's parking stay.</returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal paidMoney);

        /// <summary>
        /// Provides current information about the free places in the parking system.
        /// </summary>
        /// <returns>Returns information about parking places by sector.</returns>
        string GetStatus();

        /// <summary>
        /// Finds a vehicle by a given license plate number.
        /// </summary>
        /// <param name="licensePlate">License plate's number of the vehicle to be found.</param>
        /// <returns>Returns information about the found vehicle 
        /// and an error message in case the vehicle with the given number is not registerd in the system.</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Finds a vehicle by its owner's names.
        /// </summary>
        /// <param name="owner">Owner's names of the vehicle to be found.</param>
        /// <returns>Returns information about the found vehicle 
        /// and an error message in case the vehicle with the given owner's names is not registerd in the system.</returns>
        string FindVehiclesByOwner(string owner);
    }
}
