namespace PickUp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Home;
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
                .OrderByDescending(x => x.Id)
                .Take(10)
                .To<TripViewModel>()
                .ToList();

            // var topTenDrivers =
            //     this.Cache.Get(
            //         "topTenDrivers",
            //         () => this.users
            //     .GetAll()
            //     .Where(x => x.Roles.Any(r => r.RoleId == "fdb554c1-6ed0-47b9-bd4f-cb6925868ef0"))
            //     .To<DriverViewModel>()
            //     .OrderByDescending(x => x.Rating)
            //     .ThenBy(x => x.UserName)
            //     .Take(10)
            //     .ToList(),
            //         24 * 60 * 60);

            // var topTenPassengers =
            //     this.Cache.Get(
            //         "topTenPassengers",
            //         () => this.users
            //     .GetAll()
            //     .Where(x => x.Roles.Any(r => r.RoleId == "3d08fbe7-3e67-4493-8170-59a25c8dfb6c"))
            //     .To<PassengerViewModel>()
            //     .OrderByDescending(x => x.Rating)
            //     .ThenBy(x => x.UserName)
            //     .Take(10)
            //     .ToList(),
            //         24 * 60 * 60);ss
            var allDrivers = this.users
                .GetAll()
                .Where(x => x.Roles.Any(r => r.RoleId == "fdb554c1-6ed0-47b9-bd4f-cb6925868ef0"))
                .To<DriverViewModel>()
                .ToList();

            var topTenDrivers = allDrivers
                .OrderByDescending(x => x.Rating)
                .ThenBy(x => x.UserName)
                .Take(10);

            var allPassengers = this.users
                .GetAll()
                .Where(x => x.Roles.Any(r => r.RoleId == "3d08fbe7-3e67-4493-8170-59a25c8dfb6c"))
                .To<PassengerViewModel>()
                .ToList();

            var topTenPassengers = allPassengers
                .OrderByDescending(x => x.Rating)
                .ThenBy(x => x.UserName)
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
