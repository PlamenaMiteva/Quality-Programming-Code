using HotelBookingSystem.Utilities;

namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using HotelBookingSystem.Interfaces;

    public class Venue : IDbEntity
    {
        private string name;
        private string address;

        public Venue(string name, string address, string description, User owner)
        {
            //added this to properties and initialize list
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
            this.Rooms = new List<Room>();
        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    var message = string.Format("The venue name must be at least {0} symbols long.",
                        Constants.MinVanueNameLenght);
                    throw new ArgumentException(message);
                }

                //name was not set
                this.name = value;
            }
        }
        public string Address
        {
            get
            {
                return this.address;
            }

            private set
            {
                //missing brackets in if clause
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    var message = string.Format("The venue address must be at least {0} symbols long.",
                        Constants.MinVanueAddressLenght);
                    throw new ArgumentException(message);
                }

                this.address = value;
            }
        }

        public string Description { get; private set; }

        public User Owner { get; private set; }

        public ICollection<Room> Rooms { get; private set; }
    }
}
