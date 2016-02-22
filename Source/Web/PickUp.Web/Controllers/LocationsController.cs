namespace PickUp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using PickUp.Services.Data.Contracts;

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
