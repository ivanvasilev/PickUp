namespace PickUp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    //using Services.Data;

    using ViewModels.Home;
    using Services.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using ViewModels.Users;

    public class HomeController : BaseController
    {
        private ITripsService trips;
        private IUsersService users;

        public HomeController(ITripsService trips, IUsersService users)
        {
            this.trips = trips;
            this.users = users;
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

            var allDrivers = this.users
                .GetAll()
                .Where(x => x.Roles.Any(r => r.RoleId == "e60b64aa-5191-4b63-bc85-c5580c51f3b1"))
                .To<DriverViewModel>()
                .ToList();

            var topTenDrivers = allDrivers
                .OrderByDescending(x => x.Rating)
                .Take(10);

            var allPassengers = this.users
                .GetAll()
                .Where(x => x.Roles.Any(r => r.RoleId == "5bca68d7-298a-4137-9c2e-b51470726ab7"))
                .To<PassengerViewModel>()
                .ToList();

            var topTenPassengers = allPassengers
                .OrderByDescending(x => x.Rating)
                .Take(10);

            var indexViewModel = new IndexViewModel()
            {
                Trips = tripsToShow,
                TopDrivers = topTenDrivers,
                TopPassengers = topTenPassengers
            };

            return this.View(indexViewModel);
        }
    }
}
