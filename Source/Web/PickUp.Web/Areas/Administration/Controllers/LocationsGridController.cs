namespace PickUp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Locations;

    public class LocationsGridController : Controller
    {
        private ILocationsService locations;

        public LocationsGridController(ILocationsService locations)
        {
            this.locations = locations;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Locations_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.locations
                .GetAll()
                .To<LocationGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Locations_Create([DataSourceRequest]DataSourceRequest request, LocationGridInputModel location)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Location()
                {
                    Name = location.Name
                };

                this.locations.Create(entity);
                newId = entity.Id;
            }

            var locationToDisplay = this.locations
                .GetAll()
                .To<LocationGridViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { locationToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Locations_Update([DataSourceRequest]DataSourceRequest request, LocationGridInputModel location)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.locations.GetAll().FirstOrDefault(x => x.Id == location.Id);
                entity.Name = location.Name;
                this.locations.Update(entity);
            }

            return this.Json(new[] { location }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Locations_Destroy([DataSourceRequest]DataSourceRequest request, Location location)
        {
            var tripToDelete = this.locations.GetById(location.Id);
            this.locations.Delete(tripToDelete);

            return this.Json(new[] { location }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
