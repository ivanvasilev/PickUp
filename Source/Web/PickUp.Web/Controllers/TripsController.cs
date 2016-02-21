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

        public TripsController(ITripsService trips)
        {
            this.trips = trips;
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
    }
}