namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Utilities;

    public class User : IDbEntity
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Roles role)
        {
            Username = username;
            PasswordHash = password;
            Role = role;
            Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            //changed to private
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    var message = string.Format("The username must be at least {0} symbols long.",
                        Constants.MinUsernameLenght);
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    var message = string.Format("The password must be at least {0} symbols long.",
                        Constants.MinPasswordLenght);
                    throw new ArgumentException(message);
                }

                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
    }
}
