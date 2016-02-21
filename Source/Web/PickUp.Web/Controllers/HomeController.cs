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
                .Where(x => x.Roles.Any(r => r.RoleId == "fdb554c1-6ed0-47b9-bd4f-cb6925868ef0"))
                .To<DriverViewModel>()
                .ToList();

            var topTenDrivers = allDrivers
                .OrderByDescending(x => x.Rating)
                .Take(10);

            var allPassengers = this.users
                .GetAll()
                .Where(x => x.Roles.Any(r => r.RoleId == "3d08fbe7-3e67-4493-8170-59a25c8dfb6c"))
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
