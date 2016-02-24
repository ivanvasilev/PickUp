namespace PickUp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Trips;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class TripsGridController : Controller
    {
        private ITripsService trips;
        private ILocationsService locations;

        public TripsGridController(ITripsService trips, ILocationsService locations)
        {
            this.trips = trips;
            this.locations = locations;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Trips_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.trips
                .GetAll()
                .To<TripGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Trips_Create([DataSourceRequest]DataSourceRequest request, TripGridInputModel trip)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var from = this.locations.GetAll().FirstOrDefault(x => x.Name == trip.From);
                var to = this.locations.GetAll().FirstOrDefault(x => x.Name == trip.To);

                var entity = new Trip
                {
                    FromId = from.Id,
                    ToId = to.Id,
                    AvailableSeats = trip.AvailableSeats,
                    StartDate = trip.StartDate,
                    Description = trip.Description
                };

                this.trips.Create(entity);
                newId = entity.Id;
            }

            var tripToDisplay = this.trips
                .GetAll()
                .To<TripGridViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { tripToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Trips_Update([DataSourceRequest]DataSourceRequest request, TripGridInputModel trip)
        {
            if (this.ModelState.IsValid)
            {
                var from = this.locations.GetAll().FirstOrDefault(x => x.Name == trip.From);
                var to = this.locations.GetAll().FirstOrDefault(x => x.Name == trip.To);

                var entity = this.trips.GetAll().FirstOrDefault(x => x.Id == trip.Id);
                entity.FromId = from.Id;
                entity.ToId = to.Id;
                entity.AvailableSeats = trip.AvailableSeats;
                entity.Description = trip.Description;
                entity.StartDate = trip.StartDate;
                this.trips.Update(entity);
            }

            return this.Json(new[] { trip }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Trips_Destroy([DataSourceRequest]DataSourceRequest request, Trip trip)
        {
            var tripToDelete = this.trips.GetByIntId(trip.Id);
            this.trips.Delete(tripToDelete);

            return this.Json(new[] { trip }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
