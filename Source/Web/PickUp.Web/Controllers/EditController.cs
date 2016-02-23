namespace PickUp.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using PickUp.Services.Data.Contracts;
    using PickUp.Web.ViewModels.Users;
    using ViewModels.Trips;
    using System.Linq;

    public class EditController : BaseController
    {
        private IUsersService users;
        private ITripsService trips;
        private ILocationsService locations;

        public EditController(IUsersService users, ITripsService trips, ILocationsService locations)
        {
            this.users = users;
            this.trips = trips;
            this.locations = locations;
        }

        [HttpPost]
        public ActionResult EditProfile(UserDetailsViewModel user)
        {
            var userId = this.User.Identity.GetUserId();
            var userToUpdate = this.users.GetById(userId);
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Age = user.Age;
            this.users.Update(userToUpdate);

            return this.Redirect("/Users/Details");
        }

        [HttpGet]
        public ActionResult EditTrip(int id)
        {
            var trip = this.trips.GetByIntId(id);
            var viewModel = this.Mapper.Map<TripDetailsViewModel>(trip);

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult EditTrip(TripDetailsViewModel trip)
        {
            var tripToUpdate = this.trips.GetByIntId(trip.Id);
            var from = this.locations.GetAll().FirstOrDefault(x => x.Name == trip.From);
            var to = this.locations.GetAll().FirstOrDefault(x => x.Name == trip.To);
            tripToUpdate.FromId = from.Id;
            tripToUpdate.ToId = to.Id;
            tripToUpdate.AvailableSeats = trip.AvailableSeats;
            tripToUpdate.Description = trip.Description;
            tripToUpdate.StartDate = trip.StartDate;
            this.trips.Update(tripToUpdate);

            return this.RedirectToAction("Index", "MyTrips");
        }
    }
}
