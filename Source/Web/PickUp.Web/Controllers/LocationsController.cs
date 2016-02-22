using PickUp.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickUp.Web.Controllers
{
    public class LocationsController : BaseController
    {
        private ILocationsService locations;

        public LocationsController(ILocationsService locations)
        {
            this.locations = locations;
        }

        // GET: Locations
        public ActionResult GetAllLocations()
        {
            var allLocations = this.locations
                .GetAll()
                .ToList();

            return this.View(allLocations);
        }
    }
}