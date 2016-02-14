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
    public class TripsController : Controller
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
    }
}