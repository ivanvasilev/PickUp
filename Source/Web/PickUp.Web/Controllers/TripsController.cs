﻿namespace PickUp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using PickUp.Services.Data.Contracts;
    using PickUp.Web.Infrastructure.Mapping;
    using PickUp.Web.ViewModels.Trips;

    [Authorize]
    public class TripsController : BaseController
    {
        private ITripsService trips;
        private IUsersService users;

        public TripsController(ITripsService trips, IUsersService users)
        {
            this.trips = trips;
            this.users = users;
        }

        // GET: Trips
        public ActionResult Index()
        {
            var trips = this.trips.GetAll().To<ListTripsViewModel>().ToList();
            return this.View(trips);
        }

        public ActionResult ById(string id)
        {
            var trip = this.trips.GetById(id);
            var viewModel = this.Mapper.Map<TripDetailsViewModel>(trip);
            this.ViewBag.IsCurrentUserJoinedTheTrip = false;
            this.ViewBag.IsCurrentUserTheDriver = false;
            if (this.User.Identity.Name == viewModel.Driver)
            {
                this.ViewBag.IsCurrentUserTheDriver = true;
            }

            foreach (var passenger in viewModel.Passengers)
            {
                if (passenger.Email == this.User.Identity.Name)
                {
                    this.ViewBag.IsCurrentUserJoinedTheTrip = true;
                }

                if (passenger.Email == viewModel.Driver)
                {
                    this.ViewBag.IsCurrentUserTheDriver = true;
                }
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Join(string tripId)
        {
            var passengerId = this.User.Identity.GetUserId();
            var passenger = this.users.GetById(passengerId);
            this.trips.Join(tripId, passenger);
            var availableSeats = this.trips.GetById(tripId).AvailableSeats;

            return this.Json(new { PassengerName = passenger.UserName, AvailableSeats = availableSeats });
        }
    }
}
