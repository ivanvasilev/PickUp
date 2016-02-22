namespace PickUp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Vehicles;

    public class VehiclesGridController : Controller
    {
        private IVehiclesService vehicles;

        public VehiclesGridController(IVehiclesService vehicles)
        {
            this.vehicles = vehicles;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Vehicles_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.vehicles
                .GetAll()
                .To<VehicleGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Vehicles_Create([DataSourceRequest]DataSourceRequest request, VehicleGridInputModel vehicle)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Vehicle()
                {
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    Year = vehicle.Year,
                    Color = vehicle.Color
                };

                this.vehicles.Create(entity);
                newId = entity.Id;
            }

            var vehicleToDisplay = this.vehicles
                .GetAll()
                .To<VehicleGridViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { vehicleToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Vehicles_Update([DataSourceRequest]DataSourceRequest request, VehicleGridInputModel vehicle)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.vehicles.GetAll().FirstOrDefault(x => x.Id == vehicle.Id);
                entity.Brand = vehicle.Brand;
                entity.Model = vehicle.Model;
                entity.RegistrationNumber = vehicle.RegistrationNumber;
                entity.Year = vehicle.Year;
                entity.Color = vehicle.Color;
                this.vehicles.Update(entity);
            }

            return this.Json(new[] { vehicle }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Vehicles_Destroy([DataSourceRequest]DataSourceRequest request, Vehicle vehicle)
        {
            var tripToDelete = this.vehicles.GetById(vehicle.Id);
            this.vehicles.Delete(tripToDelete);

            return this.Json(new[] { vehicle }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
