namespace HotelBookingSystem.Controllers
{
    using System;
    using System.Linq;
    using HotelBookingSystem.Infrastructure;
    using HotelBookingSystem.Interfaces;
    using HotelBookingSystem.Models;

    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        /// <summary>
        /// Adds a new room to the venue with the specified id. Only users in administrator role have the right to do it.
        /// </summary>
        /// <param name="venueId">The id of the venue to which the room will be added.</param>
        /// <param name="places">Number of room's places.</param>
        /// <param name="pricePerDay">Room's price per day.</param>
        /// <returns>View with a success message in case the room was successfully added to the venue, 
        /// not found in case the venue does not exist or 
        /// throws exception in case there is not a logged in user or loggedin user is not an administrator.</returns>
        public IView Add(int venueId, int places, decimal pricePerDay)
        {
            Authorize(Roles.VenueAdmin);
            var venue = Data.VenuesRepository.Get(venueId);
            //wrong check
            if (venue == null)
            {
                var message = string.Format("The venue with ID {0} does not exist.", venueId);
                return NotFound(message);
            }

            var newRoom = new Room(places, pricePerDay);
            venue.Rooms.Add(newRoom);
            Data.RoomsRepository.Add(newRoom);
            return View(newRoom);
        }

        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            Authorize(Roles.VenueAdmin);
            var room = Data.RoomsRepository.Get(roomId);
            if (room == null)
            {
                return NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            //start dater should be before end date
            //if (startDate > endDate)
            //{
            //    throw new ArgumentException("The date range is invalid.");
            //}
            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return View(room);
        }

        public IView ViewBookings(int id)
        {
            Authorize(Roles.User, Roles.VenueAdmin);
            var room = Data.RoomsRepository.Get(id);
            if (room == null)
            {
                return NotFound(string.Format("The room with ID {0} does not exist.", id));
            }

            return View(room.Bookings);
        }

        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            Authorize(Roles.User, Roles.VenueAdmin);
            var room = Data.RoomsRepository.Get(roomId);
            if (room == null)
            {
                return NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            //if (endDate < startDate) throw new ArgumentException("The date range is invalid.");
            var availablePeriod = room.AvailableDates.FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);
            if (availablePeriod == null)
            {
                throw new ArgumentException(string.Format("The room is not available to book in the period {0:dd.MM.yyyy} - {1:dd.MM.yyyy}.", startDate, endDate));
            }

            decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
            var booking = new Booking(CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            CurrentUser.Bookings.Add(booking);
            UpdateRoomAvailability(startDate, endDate, room, availablePeriod);
            return View(booking);
        }

        private void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}
