namespace PickUp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    //using Services.Data;

    using ViewModels.Home;
    using Services.Data.Contracts;

    public class HomeController : BaseController
    {
        private ITripsService trips;

        public HomeController(ITripsService trips)
        {
            this.trips = trips;
        }

        public ActionResult Index()
        {
            var tripsToShow = this.trips
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Take(10)
                .To<TripViewModel>()
                .ToList();

            var indexViewModel = new IndexViewModel()
            {
                Trips = tripsToShow
            };

            return this.View(indexViewModel);
        }
    }
}
