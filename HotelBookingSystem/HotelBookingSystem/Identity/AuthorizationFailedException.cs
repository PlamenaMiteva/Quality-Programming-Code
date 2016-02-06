namespace HotelBookingSystem.Identity
{
    using System;

    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message) : base(message)
        {
            //this.User = user;
        }

        //public User User { get; set; }
    }
}
