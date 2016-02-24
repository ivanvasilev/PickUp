namespace PickUp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.MyTrips;
    using ViewModels.Trips;

    [Authorize]
    public class MyTripsController : BaseController
    {
        private ITripsService trips;

        public MyTripsController(ITripsService trips)
        {
            this.trips = trips;
        }

        // GET: MyTrips
        public ActionResult Index()
        {
            var allTrips = this.trips
                .GetAll()
                .ToList();
            this.ViewBag.IsDriver = false;

            var attendedTrips = new List<Trip>();
            var createdTrips = new List<Trip>();

            foreach (var trip in allTrips)
            {
                foreach (var passenger in trip.Passengers)
                {
                    if (passenger.Email == this.User.Identity.Name)
                    {
                        attendedTrips.Add(trip);
                    }
                }
            }

            if (this.User.IsInRole("Driver"))
            {
                this.ViewBag.IsDriver = true;

                foreach (var trip in allTrips)
                {
                    if (trip.Driver.UserName == this.User.Identity.Name)
                    {
                        createdTrips.Add(trip);
                    }
                }
            }

            var viewModel = new MyTripsViewModel()
            {
                AttendedTrips = attendedTrips,
                CreatedTrips = createdTrips
            };

            return this.View(viewModel);
        }
    }
}
