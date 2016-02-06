namespace VehicleParkingSystemApp.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private string licensePlate;
        private string owner;
        private int reservedHours;
        private decimal regularRate;
        private decimal overtimeRate;

        protected Vehicle(string licensePlate, string owner, int reservedHours, decimal regularRate, decimal overtimeRate)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reservedHours;
            this.OvertimeRate = overtimeRate;
            this.ReservedHours = reservedHours;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public decimal RegularRate { get; protected set; }

        public decimal OvertimeRate
        {
            get; 
            protected set;
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                } 
                
                this.reservedHours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder(); 
            vehicle.AppendFormat("{0} [{1}], " + "owned by {2}", GetType().Name, this.LicensePlate, this.Owner); 
            return vehicle.ToString();
        }
    }
}
