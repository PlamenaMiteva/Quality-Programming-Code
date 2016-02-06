namespace HotelBookingSystem.Models
{
    using System;

    public class AvailableDate
    {
        public AvailableDate(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ValidateDateRange(this.StartDate, this.EndDate);
        }

        public DateTime StartDate
        {
            get;
            //changed to private setter
            private set;
        }

        public DateTime EndDate
        {
            get;
            //changed to private setter
            private set;
        }

        private void ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
        }
    }
}