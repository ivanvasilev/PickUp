﻿using Microsoft.AspNet.Identity;
using PickUp.Services.Data.Contracts;
using PickUp.Web.Infrastructure.Mapping;
using PickUp.Web.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickUp.Web.Controllers
{
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
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Join(string tripId)
        {
            var tripToJoin = this.trips.GetById(tripId);
            var passengerId = this.User.Identity.GetUserId();
            var passenger = this.users.GetById(passengerId);
            tripToJoin.Passengers.Add(passenger);
            this.trips.Update(tripToJoin);

            return this.Json(new { PassengerName = passenger.UserName });
        }
    }
}