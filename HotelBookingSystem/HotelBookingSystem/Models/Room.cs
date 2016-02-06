namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using HotelBookingSystem.Interfaces;

    public class Room : IDbEntity
    {
        private int numberOfPlaces;
        private decimal pricePerDay;

        public Room(int numberOfPlaces, decimal pricePerDay)
        {
            this.NumberOfPlaces = numberOfPlaces;
            this.PricePerDay = pricePerDay;
            this.Bookings = new List<Booking>();
            this.AvailableDates = new List<AvailableDate>();
        }

        public int Id { get; set; }

        public int NumberOfPlaces
        {
            get
            {
                return this.numberOfPlaces;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The places must not be less than 0.");
                }

                this.numberOfPlaces = value;
            }
        }

        public decimal PricePerDay
        {
            get
            {
                return this.pricePerDay;
            }

            //changed setter to private. No need to be internal - class does not have any inheritors
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price per day must not be less than 0.");
                }

                this.pricePerDay = value;
            }
        }

        //changed setter to private. No need to be protected - class does not have any inheritors
        public ICollection<AvailableDate> AvailableDates { get; private set; }

        //changed setter to private. 
        public ICollection<Booking> Bookings { get; private set; }
    }
}