namespace PickUp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using PickUp.Common;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;
    using PickUp.Web.ViewModels.Trips;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.DriverRoleName)]
    public class CreateTripController : Controller
    {
        private ITripsService trips;
        private ILocationsService locations;

        public CreateTripController(ITripsService trips, ILocationsService locations)
        {
            this.trips = trips;
            this.locations = locations;
        }

        // GET: CreateTrips
        public ActionResult Index()
        {
            var locations = this.locations.GetAll().ToList();
            this.ViewBag.Locations = new SelectList(locations, "Id", "Name");

            return this.View();
        }

        [HttpPost]
        public ActionResult CreateTrip(CreateTripViewModel tripToRegister)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(tripToRegister);
            }

            var locations = this.locations.GetAll().ToList();
            this.ViewBag.Locations = new SelectList(locations, "Id", "Name");

            var tripToCreate = new Trip()
            {
                Description = tripToRegister.Description,
                StartDate = tripToRegister.StartDate,
                AvailableSeats = tripToRegister.AvailableSeats,
                FromId = tripToRegister.From,
                ToId = tripToRegister.To,
                DriverId = this.User.Identity.GetUserId()
            };

            this.trips.Create(tripToCreate);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
