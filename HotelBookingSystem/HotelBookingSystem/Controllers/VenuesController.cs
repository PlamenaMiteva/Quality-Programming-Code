namespace HotelBookingSystem.Controllers
{
    using HotelBookingSystem.Infrastructure;
    using HotelBookingSystem.Interfaces;
    using HotelBookingSystem.Models;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.VenuesRepository.GetAll();
            return View(venues);
        }

        public IView Details(int id)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var venue = this.Data.VenuesRepository.Get(id);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
            }

            return View(venue);
        }

        public IView Rooms(int id)
        {
            //this.Authorize(Roles.User, Roles.VenueAdmin);
            var venue = this.Data.VenuesRepository.Get(id);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
            }
            
            return View(venue);
        }

        public IView Add(string name, string address, string description)
        {
            //BUG only admin can add venues
            this.Authorize(Roles.VenueAdmin);
            var newVenue = new Venue(name, address, description, CurrentUser);
            this.Data.VenuesRepository.Add(newVenue);
            return View(newVenue);
        }
    }
}